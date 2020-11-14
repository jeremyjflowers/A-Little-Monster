using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _2020GameJam
{
    class Game
    {
        private Entity player;
        private Entity enemy;
        private int k = 0;
        private bool Key = false;
        private bool ExitKey = false;
        private bool mainstoryStarted = false;
        private bool gameOver = false;
        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        public virtual void Start()
        {
            Entity enemy = new Entity();
            Prologue();
        }

        public virtual void Update()
        {
            MainStory();
        }

        public virtual void End()
        {

        }

        public void Run()
        {
            Start();

            while (!gameOver)
            {
                Update();
            }

            End();
        }

        public void Continue()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPress [Enter] to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public void GetInput(out char input, string option1, string option2, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("> \n");

            input = ' ';
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("Please try again");
                }
            }
        }

        public void GetInput(out char input, string option1, string option2, string option3, string option4, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.WriteLine("4. " + option4);
            Console.Write("> \n ");

            input = ' ';
            while (input != '1' && input != '2' && input != '3' && input != '4')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3' && input != '4')
                {
                    Console.WriteLine("Please try again");
                }
            }
        }

        public void Prologue()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            char input;
            GetInput(out input, "Left", "Right", "You are trapped in a box-like place. Where should you go?");
            if (input == '2')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nOh? You poor thing~");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("LEAVE #### ALONE!!! Why must you always toy with people?");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAfter some time, you manage to free yourself.");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n'Congrats on escaping, ####!', cheers a bland voice");;
                Console.ReadKey();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("As you escape, you begin to ponder everything up until now.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Who are you? Where am I? And......Who am I");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You don't remember us? We're you!");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Sadly...");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("What is my name?");

            string name = Console.ReadLine();
            player = new Entity(name, 100, 3);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nSilly! It's " + player.GetName() + ".");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Okay. Then what are you all names then?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Charcot!");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(".....DID.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You are in a moldy hallway, the smell of disinfectants and mold make you nauseous. It seemed to be a hospital of sorts, perhaps abandoned. But with this information, this would mean that the possibility is low");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("We call him Narrator.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("He's annoying");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You feel a pressure in your skull. It’s as if something is trying to burst out.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Ignore it.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("....");
            Console.ReadKey();
            Continue();

            Console.ForegroundColor = ConsoleColor.Red;
            GetInput(out input, "Door you just came from", "Left Door", "Right Door", "End Door", "You look dow the hallway and see some doors.");
            if(input == '1')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nI'd advise you to not go back to that cage.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You decide to head for the door at the end of the hallway.");
            }
            else if(input == '2')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou feel slightly tired, the pressure on your skull grows. You hurriedly exit the room. Your sanity at stake.");
                Console.WriteLine("Both your physical and mental health has dropped by 4%");
                float damageTaken = player.Attack(player);
                Console.WriteLine("\n" + player.GetName() + " recieved " + 4 + " points of damage.");
                Console.WriteLine("\nYou decide to head for the door at the end of the hallway.");
            }
            else if(input == '3')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou enter the room cautiously. The room seems to be much more moldy than the hallway. Seeing as there is nothing here for you, you leave.");
                Console.WriteLine("You decide to head for the door at the end of the hallway.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou go through the door at the end of the hallway.");
            }

            Console.WriteLine("\nThe room you enter seems to be somewhat grand, like a hotel yet there is litle to no signs of life. The air fells thick and each time you breathe, the back of your throat stings");

        }

        public void MainStory()
        {

        }
    }
}
