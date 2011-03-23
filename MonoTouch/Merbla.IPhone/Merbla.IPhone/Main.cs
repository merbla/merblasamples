
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading;
 using System.Drawing;

namespace Merbla.IPhone
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}
	 
	
	public partial class AppDelegate : UIApplicationDelegate,IHandle<MovementFinished>
	{
		protected IEventAggregator EventAggregator {get;set;}
		
		private ConsoleHandler Handler {get;set;}
		
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			//Initialise the aggregator
			EventAggregator = new EventAggregator();
			Handler = new ConsoleHandler(EventAggregator); 
			EventAggregator.Subscribe(this);
			
			///Create a ui view 
			var img = new MerblaImageView(EventAggregator,  new RectangleF(64,64,64,64));
			img.UserInteractionEnabled = true;
			img.BackgroundColor = UIColor.Red;
			img.Hidden = false;

			window.AddSubview(img);
			window.MakeKeyAndVisible ();
			
			return true;
		}
     
				
		public void HandleEvent(MovementFinished message)
		{
			dragWindowOutputLabel.Text += Environment.NewLine + message.FinishDateTime.ToShortTimeString();
		}
		

	}
	
	
}
 