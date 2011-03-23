using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
namespace Merbla.IPhone.Web
{
	[HandleError]
	public class ServiceController : Controller
	{
		public JsonResult GetData ()
		{
			var people = new List<Person>();
			people.Add(new Person{FirstName="Joe", Surname ="Smith"});
			people.Add(new Person{FirstName="Larry", Surname ="Jones"});
			people.Add(new Person{FirstName="Amy", Surname ="Johnston"});
			
			return  Json(people); 
		}
	}
}

