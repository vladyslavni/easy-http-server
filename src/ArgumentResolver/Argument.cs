namespace easy_http_server
{
    public struct Argument
    {
        public readonly string key;
        public readonly string value;

        public Argument(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}