using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5SathlerDelfinoA {
    //Class with auxiliary methods to read user input
    internal class UserInput {
        //Method ReadString to read a input as string
        public static string ReadString(string prompt) {
            string input;

            Console.Write(prompt);

            Console.ForegroundColor = ConsoleColor.Yellow;  //Change color to yellow
            input = Console.ReadLine();
            Console.ResetColor(); //Reset color

            return input;
        }

        //Method ReadInt to read a input as int
        public static int ReadInt(string prompt) {
            int input;

            Console.Write(prompt);

            Console.ForegroundColor = ConsoleColor.Yellow;   //Change color to yellow
            input = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor(); //Reset color

            return input;
        }

        //Method Menu to read a input as a menu choice (char)
        public static char Menu(string prompt) {
            char menuChoice;

            menuChoice = ReadString(prompt)[0]; //Read the first letter of the input

            return menuChoice;
        }
    }
}
