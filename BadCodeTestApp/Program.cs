using Autofac;
using BadCodeTestApp.Service;
using BadCodeTestApp.Commands;
using BadCodeTestApp.Commands.FileCommands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadCodeTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No parameters specified.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            IContainer container = ContainerIoC.GetContainerIoC();

            string command = args[0];

            if (!ContainerIoC.SearchRegisteredCommand(container, command)) //можно ли здесь сделать проверку более просто и избавится от if
            {
                Console.WriteLine("Command {0} is illegal!", command);
            }
            else
            {
                ICommand ins = container.ResolveNamed<ICommand>(command);
                ins.execute(args);
            }

            Console.ReadLine();
        }
    }
}
