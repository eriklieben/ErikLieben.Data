namespace ErikLieben.Tests.ProjectExpression.To
{
    using System.Text.RegularExpressions;

    public class Query
    {
        public static string FixMarkupOf(string query)
        {
            return Regex.Replace(query, "(\r|\n| )+", " ");
        }
    }
}
