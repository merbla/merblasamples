
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TinyIoC;
using TinyMessenger;
using Merbla.Core;

namespace Merbla.IPad
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}

	public partial class AppDelegate : UIApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			BootStrap ();
			
	 		MessageHub.Subscribe<PeopleMessage>((m) =>{
		 
				Dispatch(()=>{
					
					var message = "People message received @ " + DateTime.Now; 
					message += ": " + m.Content
						.Select(p=> p.Surname)
							.Aggregate((text, item) =>
								text + " Surname: " + item);
		 
					UIAlertView alert = new UIAlertView();
					alert.Title = "Service Call returned";
					alert.AddButton("Ok");
					alert.Message = message;
					alert.Show();		 
				});
			});
			
			Repo.GetPeople();
			
			
			
			window.MakeKeyAndVisible ();
			return true;
			
		}

		public TinyIoC.TinyIoCContainer Container { get; private set; }

		private IRepository Repo 
		{get
			{
				return Container.Resolve<IRepository>();
			}
		}
		
		private ITinyMessengerHub MessageHub
		
		{
			get{
				return 	Container.Resolve<ITinyMessengerHub>();
				
			}
		}
		
		private void BootStrap ()
		{
			Container = TinyIoCContainer.Current;
			Container.Register<ITinyMessengerHub, TinyMessengerHub> ().AsSingleton();
			Container.Register<IRepository, WebRepository> ();
			
		}
		
		
		
	}
}

