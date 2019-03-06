using BadCodeTestApp.Commands;
using log4net;
using System;
using System.IO;

namespace BadCodeTestApp.Service
{

    abstract class ExeptionService : ICommand
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void execute(string[] prms)
        {
            try //перехватывается много разных исключений, 
            //возможно стоит сделать отдельно валидатор который будет проверять входные параметры и ронять различные типы исключений
            //здесь перехватывать только кастомные типы и общий эксепшн (тем более всеравно на все исключения ты просто пишеш месседж)
            
            {
                Log.Info("Start command");
                CommandExecute(prms);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Log.Error("End command", ex);
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public abstract void CommandExecute(string[] prms);
    }
}
