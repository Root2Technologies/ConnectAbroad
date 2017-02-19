using System;
using System.Threading.Tasks;

namespace ConnectAbroad
{
	public interface IAuthenticationService
	{
		
			Task InitializeAsync();
			string GetAccessToken();

	}
}
