using System;
using System.Reflection;

namespace easy_http_server
{
    public class DefaultParameters
    {
        [Parameter("-h", "--help", "Show help message.")]
        public static void HelpParam(string value)
        {
            MethodInfo[] methods = Params.FindMethods();

            foreach (var method in methods)
            {
                var att = method.GetCustomAttribute(typeof(Parameter), false);
                
                if (att is Parameter)
                {
                    Parameter parameter = (Parameter) att;
                    Console.WriteLine("\t{0}\t{1}\t{2}", parameter.key, parameter.fullKey, parameter.description);
                }
            }

            Environment.Exit(0);
        }
    }
}