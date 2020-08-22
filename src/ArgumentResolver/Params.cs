using System.Reflection;
using System;
using System.Linq;
namespace easy_http_server
{
    public class Params
    {
        public static void ApplyParameters(string[] args)
        {   
            Argument[] arguments = ParseArguments(args);
            MethodInfo[] methods = FindMethods();

            foreach (var argument in arguments)
            {
                foreach (var method in methods)
                {
                    var att = method.GetCustomAttribute(typeof(Parameter), false);
                
                    Parameter parameter = (Parameter) att;
                    if (parameter.key == argument.key || parameter.fullKey == argument.key)
                    {
                        if (argument.value != null)
                        {
                            method.Invoke(null, new string[]{argument.value});
                        } else {
                            method.Invoke(null, null);
                        }
                    }
                }
            }
        }

        public static MethodInfo[] FindMethods()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => x.IsClass)
                    .SelectMany(x => x.GetMethods())
                    .Where(x => x.GetCustomAttributes(typeof(Parameter), false).FirstOrDefault() != null)
                    .ToArray();
        }

        private static Argument[] ParseArguments(string[] args)
        {
            Argument[] arguments = new Argument[args.Length];

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Contains("="))
                {
                    string[] valuedArg = args[i].Split("=");
                    arguments[i] = new Argument(valuedArg[0], valuedArg[1]);
                } else {
                    arguments[i] = new Argument(args[i], null);
                }
            }

            return arguments;
        }
    }
}