namespace Domain.Utils
{
    public static class UtilsTools
    {
        public static bool ValidateEmail(string email)
        {
            if (email.Length > 0 && email.Contains("@") && email.Contains(".com")) return true;
            
            return false;
        }
    }
}
