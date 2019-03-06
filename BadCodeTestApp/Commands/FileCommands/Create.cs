using BadCodeTestApp.Service;
using System.IO;

namespace BadCodeTestApp.Commands.FileCommands
{
    class Create : ExeptionService
    {
        public override void CommandExecute(string[] prms)
        {
            CreateFile(prms[1]);
        }

        protected void CreateFile(string path)
        {
            File.Create(path + "\\test.txt");//такое статически заданное имя файла кажется не совсем корректным, напрашивается еще один параметр. верно?
       //конечно.
        }
    }
}
