using System.Text.RegularExpressions;
namespace SearchParty.Core
{
    public static class ModelHelper
    {
        public static string UnwrapCommas(this string tags)
        {
            string pattern = "^(,*)([^,])(.*)([^,])(,*)$";

            Regex r = new Regex(pattern);
            tags = r.Replace(tags, "$2$3$4");

            return tags;
        }

        public static string WrapCommas(this string tags)
        {
            if (!tags.StartsWith(","))
            {
                tags = "," + tags;
            }
            if (!tags.EndsWith(","))
            {
                tags = tags + ",";
            }
            return tags;
        }
    }
}