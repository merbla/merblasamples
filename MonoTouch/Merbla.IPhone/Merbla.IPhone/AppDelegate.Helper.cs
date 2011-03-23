
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Threading;
 using System.Drawing;
namespace Merbla.IPhone
{
	public partial class AppDelegate
	{
		public void Dispatch (Action action)
		{
			InvokeOnMainThread (delegate { action.Invoke (); });
		}
 
		public void ExecuteAsync (Action actionToExecute, Action callBack)
		{
			ExecuteAsync (() =>
			{
				actionToExecute ();
				Dispatch (callBack);
			});
		}
		 
		
		public void ExecuteAsync (Action actionToExecute)
		{
			Action<object> asyncProcess = obj =>
			{
				try {
					actionToExecute ();
				} catch (Exception ex) {
					Dispatch (() =>
					{
						throw new Exception ("Error occured in async process", ex);
					});
				}
			};
			 
			ThreadPool.QueueUserWorkItem (new WaitCallback (asyncProcess));
		}
	}
}

