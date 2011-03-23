using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using TinyMessenger;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
namespace Merbla.Core
{
	public class MerblaBaseView :UIView
	{
		public MerblaBaseView (ITinyMessengerHub messageHub, IRepository repo)
		{
			_messageHub = messageHub;
			_repo= repo;
			
			_messageHub.Subscribe<PeopleMessage>((m) =>{
		 
				var label = new UILabel(new RectangleF(20,20,100,100));
				label.Text = "People message received @ " + DateTime.Now;
				
				label.Text += ": " + m.Content
					.Select(p=> p.Surname)
						.Aggregate((text, item) =>
							text + " Surname: " + item);
			 
				AddSubview(label);				                               
			});
			
			var button = new UIButton(new RectangleF(10,10, 100,100));
			
			button.SetTitle( "Make Service Call", UIControlState.Normal);
			button.TouchDown += delegate(object sender, EventArgs e) {
				_repo.GetPeople();
			};
			
			AddSubview(button);
			
		}
		
		private ITinyMessengerHub _messageHub;
		private IRepository _repo;
		
		 
		
	}
}

