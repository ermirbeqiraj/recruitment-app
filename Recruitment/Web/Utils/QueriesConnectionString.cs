namespace Web.Utils
{
    public class QueriesConnectionString
    {
        public string Value { get; }
        public QueriesConnectionString(string connectionString)
        {
            Value = connectionString;
        }
    }
}
