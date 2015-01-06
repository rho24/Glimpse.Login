using System;
using System.Configuration;
using Glimpse.Core.Extensibility;

namespace Glimpse.Login
{
    public class LoginPolicy : IRuntimePolicy
    {
        private const string ControlCookieName = "Glimpse.Login";
        private const string AppSettingKey = "Glimpse.Login.Password";

        public RuntimePolicy Execute(IRuntimePolicyContext policyContext)
        {
            var cookie = policyContext.RequestMetadata.GetCookie(ControlCookieName);

            if (string.IsNullOrEmpty(cookie))
            {
                return RuntimePolicy.Off;
            }

            if (CredentialsAreValid(cookie))
                return RuntimePolicy.On;

            return RuntimePolicy.Off;
        }

        private bool CredentialsAreValid(string password)
        {
            var expectedPassword = ConfigurationManager.AppSettings[AppSettingKey];

            if (expectedPassword == null)
                return false;

            return password.Equals(expectedPassword, StringComparison.InvariantCulture);
        }

        public RuntimeEvent ExecuteOn
        {
            get { return RuntimeEvent.BeginRequest; }
        }
    }
}