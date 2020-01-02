namespace Web.Utils
{
    public class ConnectionString
    {
        public string Value { get; }
        public ConnectionString(string connectionString)
        {
            Value = connectionString;
        }
    }
}
