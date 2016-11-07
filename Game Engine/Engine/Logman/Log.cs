using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Logman
{
    public enum LogLevel
    {
        Info,
        Warnings,
        Errors,
        Debug
    }

    static public class Logger
    { 
        public static LogLevel Level = LogLevel.Debug;
        public static void Log(LogLevel level, params object[] args)
        {
            if(level <= Level)
            {
                Console.WriteLine(string.Format("[{0}:{1}:{2}] [{3}] {4}", DateTime.Now.Hour, DateTime.Now.Minute.ToString("D2"), DateTime.Now.Second.ToString("D2"), level.ToString(), string.Join(" ", args)));
            }
        }
    }
}
