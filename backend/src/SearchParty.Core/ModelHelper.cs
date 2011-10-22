namespace SearchParty.Core
{
    public static class ModelHelper
    {
        public static string Tagify(this string tags)
        {
            return tags.Replace(",", " ").Trim().Replace(" ", ",");
        }
    }
}