using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Logman
{
    public enum LogLevel
    {
        Info,
        Warnings,
        Errors,
        Debug
    }

    static class Logger
    { 
        public static LogLevel Level = LogLevel.Debug;
        public static void Log(LogLevel level, params object[] args)
        {
            if(level <= Level)
            {
                Console.WriteLine(string.Format("[{0}:{1}:{2}] [{3}] {4}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, level.ToString(), string.Join(" ", args)));
            }
        }
    }
}
