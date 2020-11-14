using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _2020GameJam
{
    class Adventure : Game
    {
        public void Continue()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPress [Enter] to continue");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void GetInput(out char input, string option1, string option2, string option3, string option4, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.WriteLine("4. " + option4);
            Console.WriteLine("> \n");

            input = ' ';
            while(input != '1' && input != '2' && input != '3' && input != '4')
            {
                input = Console.ReadKey().KeyChar;
                if(input != '1' && input != '2' && input != '3' && input != '4')
                {
                    Console.WriteLine("Please try again");
                }
            }
        }

        public override void Update()
        {

            base.Update();
        }
    }
}
