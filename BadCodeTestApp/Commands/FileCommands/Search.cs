using BadCodeTestApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BadCodeTestApp.Commands.FileCommands
{
    class Search : ExeptionService
    {
        public override void CommandExecute(string[] prms)
        {

            string path = prms[1];// нужно ли объявлять эту переменную??
               //так код выглядит понятнее. Очевиднее при чтении что ты ожидаешь получить.
            if (prms.Length > 2)// или лучше довавлять маску "*" в массив и всегда передавать 2 параметра в search()? или и то и то глупости?
            {
                search(path, prms[2]).ForEach(n => Console.WriteLine(n));
            }
            else
            {
                search(path).ForEach(n => Console.WriteLine(n));
            }
            //я думаю что можно обойтись тут без проверки. Валидацию можно организовать отдельно - на занятии обсуждалось 
        }

        List<string> search(string path, string pattern = "*")
        {
            return Directory.GetFiles(path, pattern, SearchOption.AllDirectories).ToList();
        }

        class InfalidMask : Exception
        {
            public InfalidMask(string message)
                : base(message)
            { }
        }
    }

}
