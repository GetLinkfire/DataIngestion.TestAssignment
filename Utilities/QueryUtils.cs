namespace DataIngestion.TestAssignment.Utilities
{
    public static class QueryUtils
    {
        public static string GetQueryValue(string text)
        {
            string query = "confirm=";
            int start, end;
            start = text.IndexOf(query, 0) + query.Length;
            end = text.IndexOf("&", start);
            return text[start..end];
        }
    }
}
