using System.Text.RegularExpressions;
using System;

namespace easy_http_server
{
    public class ConfigParams
    {
        public static IRequest RequestType = new SyncRequest();
        public static string Port = "8080"; 
        public static IRandom RandomUrl = new RandomWithoutRepetitions();
        public static IUrlStorage UrlStorage = new UrlInMemoryStorage();


        [Parameter("-a", "--async", "Use Async for incamp18-qoute.")]
        public static void AsyncParam(string value)
        {
            ConfigParams.RequestType = new AsyncRequest();
        }


        [Parameter("--port", "Set the port on which the program will run.")]
        public static void PortParam(string value)
        {
            Regex regex = new Regex("\\d{3,6}");

            if(regex.IsMatch(value)) ConfigParams.Port = value;
        }


        [Parameter("-r", "--repeat-urls", "Enable links repetitions for queries.")]
        public static void RepeatParam(string value)
        {
            ConfigParams.RandomUrl = new RandomWithRepetitions();
        }

        
        [Parameter("--urls", "List of URLs for queries.Write URLs via ','.")]
        public static void UrlsParam(string value)
        {
            string[] urls = value.Split(",");
            ConfigParams.UrlStorage.AddAll(urls);
        }
    }
}