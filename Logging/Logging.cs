﻿namespace Rstfulapi.Logging

{
    public class Logging : ILogging
    {
        public void Log(string message, string type)
        {
            if(type== "error")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Error - "+message);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            if(type=="Warning"){
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Error - " + message);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}
