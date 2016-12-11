namespace Infrastructure.Extensions
{
    public static class StringExtension
    {
        public static bool StringIsNullEmptyWhiteSpace(this string obj)
        {
            if (string.IsNullOrEmpty(obj) || (string.IsNullOrWhiteSpace(obj)))
                return true;
            return false;
        }
    }
}
