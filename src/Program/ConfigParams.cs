using System;

namespace easy_http_server
{
    public class ConfigParams
    {
        public static IRequest RequestType = new RegularRequest();
        public static string Port = "5000"; 


        [Parameter("-a", "--async", "Use Async for incamp18-qoute.")]
        public static void AsyncParam()
        {
            ConfigParams.RequestType = new AsyncRequest();
        }

        [Parameter("--port", "Set the port on which the program will run.")]
        public static void PortParam(string port)
        {
            ConfigParams.Port = port;
        }

    }
}