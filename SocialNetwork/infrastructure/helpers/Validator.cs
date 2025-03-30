using System.Text.RegularExpressions;

namespace SocialNetwork.infrastructure.helpers
{
    public static class Validator
    {
        public static bool IsEmailValid(string email) 
        {
            if(string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                             + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                             + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
    }
}
