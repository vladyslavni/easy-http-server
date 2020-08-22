namespace easy_http_server
{
    public interface IParameter
    {
        void Apply();

        bool IsValid(string arg);
    }
}