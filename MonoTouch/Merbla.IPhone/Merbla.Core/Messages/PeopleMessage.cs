using System;
using TinyMessenger;
using System.Collections.Generic;
using Merbla.IPhone.Web;

namespace Merbla.Core
{
	public class PeopleMessage : GenericTinyMessage<IEnumerable<Person>>
	{
		public PeopleMessage (object sender, IEnumerable<Person> content)
			:base(sender, content)
		{
		}
	}
}

