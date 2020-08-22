using System;
using System.Collections.Generic;

namespace easy_http_server
{
    public class Params
    {
        private static List<IParameter> parameters = new List<IParameter>();
        static Params()
        {
            Action helpFunc = () => {
                parameters.ForEach(p => Console.WriteLine(p));
                Environment.Exit(0);
            };
            Action asyncFunc = () => {
                ConfigParams.RequestType = new AsyncRequest();
            };
            Action<string> portFunc = (value) => {
                ConfigParams.Port = value;
                Console.WriteLine(ConfigParams.Port);
            };

            parameters.Add(new Parameter("-h", "--help", "Show help message", helpFunc));
            parameters.Add(new Parameter("-a", "--async", "Use Async for incamp18-qoute. (Accelerates work, but uses more system resources)", asyncFunc));
            parameters.Add(new ValuedParameter("--port", "Set the port on which the program will run", portFunc));

        }

        public static void ApplyParameters(string[] args)
        {
            foreach (var argument in args)
            {
                foreach (var parameter in parameters)
                {
                    if (parameter.IsValid(argument))
                    {
                        parameter.Apply();
                    }
                }
            }
        }
    }
}