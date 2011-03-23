
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
			window.MakeKeyAndVisible ();
			
			Container = TinyIoCContainer.Current;
			
			Container.Register<ITinyMessengerHub, TinyMessengerHub>();
			Container.Register<IRepository, WebRepository>();

			return true;
			
		}
		
		public TinyIoC.TinyIoCContainer Container {get; private set;}
		
	}
}

