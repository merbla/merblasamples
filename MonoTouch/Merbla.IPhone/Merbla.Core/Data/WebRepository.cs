using System;
using TinyMessenger;
using RestSharp;
using Merbla.IPhone.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace Merbla.Core
{
	public class WebRepository : IRepository
	{

		public WebRepository (ITinyMessengerHub messageHub)
		{
			_messageHub = messageHub;
		}

		private ITinyMessengerHub _messageHub;

		private IRestClient _client;
		
		private IRestClient Client {
			get {
				if (_client == null) {
					_client = new RestClient ("http://127.0.0.1:8080/");
					_client.Timeout = 20000;
				}
				return _client;
			}
		}
		
		public void GetPeople()
		{
			var request = new GetPeopleRequest ();
			
			Client.ExecuteAsync (request, x =>
			{ 
				var people = JsonConvert.DeserializeObject<List<Person>> (x.Content); 
				_messageHub.PublishAsync(new PeopleMessage(this, people));
			});
		}
	}



	public class GetPeopleRequest : RestRequest
	{
		public GetPeopleRequest () : base("service/getdata", Method.GET)
		{
			RequestFormat = DataFormat.Json;
		}
	}
}

