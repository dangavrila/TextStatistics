using Microsoft.AspNetCore.Authorization;

namespace TextWebServices.Security
{
	public class CognitoGroupAuthorizationRequirement: IAuthorizationRequirement
	{
		public string CognitoGroup { get; private set; }

		public CognitoGroupAuthorizationRequirement(string cognitoGroup)
		{
			CognitoGroup = cognitoGroup;
		}
	}
}
