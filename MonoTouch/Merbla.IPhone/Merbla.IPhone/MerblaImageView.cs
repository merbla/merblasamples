
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
namespace Merbla.IPhone
{ 
	public class MerblaImageView : UIImageView
	{
		private PointF Location;
		private PointF StartLocation;
		bool haveBeenTouchedOnce = false;
		private IEventAggregator _aggregator;
		
		public MerblaImageView (IEventAggregator eventAggregator, RectangleF frame)
		{ 
			_aggregator = eventAggregator;
			this.Frame = frame;
			StartLocation = this.Frame.Location;
		}
 
		public override void TouchesBegan (MonoTouch.Foundation.NSSet touches, MonoTouch.UIKit.UIEvent e)
		{
			Location = this.Frame.Location;
			
			var touch = (UITouch)e.TouchesForView (this).AnyObject;
			var bounds = Bounds;
			
			StartLocation = touch.LocationInView (this);
			this.Frame = new RectangleF (Location, bounds.Size);
			
		} 
		
		public override void TouchesMoved (MonoTouch.Foundation.NSSet touches, MonoTouch.UIKit.UIEvent e)
		{
			var bounds = Bounds;
			var touch = (UITouch)e.TouchesForView (this).AnyObject;
			Location.X += touch.LocationInView (this).X - StartLocation.X;
			Location.Y += touch.LocationInView (this).Y - StartLocation.Y;
			this.Frame = new RectangleF (Location, bounds.Size);
			haveBeenTouchedOnce = true;
		}

		public override void TouchesEnded (MonoTouch.Foundation.NSSet touches, MonoTouch.UIKit.UIEvent e)
		{
			StartLocation = Location; 
			//Publish to aggregator
			_aggregator.Publish(new MovementFinished {FinishDateTime =DateTime.Now});
		}
	}
	
	public class MovementFinished
	{
		public DateTime FinishDateTime {
			get;
			set;
		}
	}
	
}
