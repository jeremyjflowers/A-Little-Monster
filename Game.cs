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
        int k = 0;
        bool Key = false;
        bool ExitKey = false;
        bool mainstoryStarted = false;
        static int goodKarma = 0;
        static int badKarma = 0;
        int karmaPoints = goodKarma - badKarma;
        private bool gameOver = false;
        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;

        public virtual void Start()
        {
            Prologue();
        }

        public virtual void Update()
        {
            MainStory();
        }

        public virtual void End()
        {
            if(player.GetIsAlive() && karmaPoints > 4)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You awoke from the terrible nightmare you just had only to discover that your head was resting on a steering wheel. You look over towards your hand and spot a bottle being held. You committed a grave mistake.");
                Console.WriteLine("You look up and see another car has crashed into you, a little girl and a woman are passed out inside. You slowly but surely got out of the truck and head towards the car.");
                Console.WriteLine("You pulled the woman out and put her onto the side of the road and noticed how she was breathing so you decided to get the girl. You pulled the little girl out and noticed she was wearing the school uniform for Babinsky Elementary.");
                Console.WriteLine("She coughs a bit and opens her eyes. ‘Where am I? Where’s mommy? It hurts!’ you try calming her down and spot her I.D ‘Your name’s Charcot Wilkins, right? Calm down. Your mom’s right next to you.");
                Console.WriteLine("You try looking for your phone and you eventually find it. You call 911 and wait for the dispatcher. ‘Minister.. Your bleeding..’ your consciousness begins to fade out.");
                Console.ReadKey();
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You got the [Can’t Be All Bad] ending!");
            }
            else if(player.GetIsAlive() && karmaPoints < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You go through the exit and find yourself leaning against a steering wheel and a bottle in your hand. You look up and see that you crashed into another car in your drunken haze.");
                Console.WriteLine("In the back of that car you see a little girl with a name tag saying Charcot, you DID this, this was your fault. You couldn’t accept that this happened and you STILL can’t accept. You start your car up and drive away. Away from your mistake. Never looking back.");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("You got the [Monster] ending!");
            }
        }

        public void Run()
        {
            Start();

            while (gameOver == false)
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

        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.Write("> \n ");

            input = ' ';
            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3')
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

        public void BattleStart(Entity player, Entity enemy)
        {
            while(player.GetIsAlive() && enemy.GetIsAlive())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                char input;
                GetInput(out input, "Attack", "Dodge", "A rabid rat attacks. What will you do?");
                if(input == '1')
                {
                    float TakeDamage = player.Attack(enemy);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\nI dealt " + TakeDamage + " damage to " + enemy.GetName());

                    TakeDamage = enemy.Attack(player);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n" + enemy.GetName() + " dealt " + TakeDamage + " damage to " + player.GetName());
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("I dodged " + enemy.GetName() + " attack.");

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
            player = new Entity(name, 100, 10);

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

            while(gameOver == false)
            {
                GetInput(out input, "The Kitchen", "The Front Desk", "The Stairway", "Exit", "In the room you see a door with a plank that says ‘the Kitchen’, a front hotel desk, a long stairway, and A big door that has a neon exit sign. Where do you go?");
                if (input == '1' && mainstoryStarted == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou enter the Kitchen, there's thrown dishes everywhere, there's especially a lot of empty alcohol bottles everywhere. All of the sudden you hear a clatter.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("It’s a rat...yet, there seems to be off, especially the size seems to be much larger than even the rats in parks. The foam coming out of its mouth seems to be a sign that it's not in the right state of mind.");
                    Continue();
                    enemy = new Entity("Rabid Rat", 3, 2);
                    BattleStart(player, enemy);
                    Console.Clear();

                }
                else if (input == '2' && mainstoryStarted == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou walk up to the desk and find some pamphlets, too old and faded to actually read, well other than the giant name that's somewhat readable. It reads ‘Babinsky Resort’ a weird name that you don’t even dare to say allowed in fear of mispronouncing it. you spot a drawer. you reach your hand out towards the drawer and try to open it, but you unfortunately couldn’t.");
                    Continue();
                }
                else if (input == '2' && Key == true && mainstoryStarted == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou're back to where you started, yet this time, you’ve learned that whoever you are, you're a terrible person. You take the keys out of your pocket and unlock the drawer. Inside it you see a set of car keys…...they exit keys");
                    ExitKey = true;
                    Continue();
                }
                else if (input == '2' && mainstoryStarted == true && Key == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You go to the locked drawer and realize that, you haven’t found a key, it felt as if what you went through was meaningless.");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("You haven’t learned one bit, you shall not remember who you are, and you have yet to learn of your mistake.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You will retake the test. Hopefully you will learn this time. I do not wish for pain however you haven’t learned of the pain you gave to others.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Restarting.........");
                    Continue();
                    MainStory();
                }
                else if(input == '3' && mainstoryStarted == false)
                {
                    mainstoryStarted = true;
                    MainStory();
                }
                else if(input == '3' && mainstoryStarted == true && Key == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Everything felt like you’ve done everything before yet you do not care. Everything felt like you’ve done everything before yet you do not care.");
                    Console.WriteLine("Everything felt like you’ve done everything before yet you do not care. Everything felt like you’ve done everything before yet you do not care.");
                    Console.WriteLine("Everything felt like you’ve done everything before yet you do not care. Everything felt like you’ve done everything before yet you do not care.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Everything felt like you’ve done everything before yet you do not care.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("I’m sorry, but you did not learn. You have not learned from your mistake.");
                    Continue();
                    MainStory();
                }
                else if(input == 4 && k == 0 && mainstoryStarted == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You spot a door with a neon sign that's off with the words ‘Exit’ on it. You rush to the door and go to open it…..yet it’s locked");
                    Continue();
                }
                else if(input == '4' && Key == true && ExitKey == true)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("I walked to the door with key in hand, prepared to face what's beyond it. I'm scared, yet I realize I must face the truth... I open the door and leave.");
                    gameOver = true;
                }
            }
        }

        public void MainStory()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You walk up to the stairs, and look up towards the long stairway You walk up....... And up.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("My head is hurting. I look to the side and see a picture. It’s a Nii-san Front-Tire. Yet it looks like it had crashed into something.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("What were you thinking that night");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What is that? A bottle?");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("....");
            Continue();

            Console.ForegroundColor = ConsoleColor.Red;
            char input;
            GetInput(out input, "Pick it up", "Don't pick it up", "Should you pick it up?");
            if(input == '1')
            {
                badKarma += 1;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("You haven't changed a bit.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("....");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The liquid in the bottle slished around. The liquid had a strong smell to it yet it was recognizable. All of the sudden it started bubbling. The liquid flew out towards you!");
                enemy = new Entity("Drunked Slime", 20, 5);
                BattleStart(player, enemy);
            }
            else
            {
                goodKarma += 1;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("You.. So it must have been a one time thing?");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("I... You did good " + player.GetName());
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have arrived to the [First Floor]");
            Console.WriteLine("You see a total of 3 rooms.");
            Continue();

            while(gameOver == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                GetInput(out input, "Room 1", "Room2", "Room 3", "Which room will you enter?");
                if(input == '1')
                {
                    goodKarma += 1;
                    Console.WriteLine("You walk into the room and notice that it's a little girls room, a pain of guilt hits you");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Charcot...What type of person was I?");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("I do not know, but I assume you were a . . .great person!");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(" wouldn’t say that, I’d claim the opposite.");
                }
                else if(input == '2')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You walk into a room and it seems to resemble a bar, your head begins to hurt, you look at the bar and see a refreshing drink lay there. You feel a pressure once more, yet you feel the need to drink it.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Why would you do this?");

                    GetInput(out input, "Drink", "Don't drink", "What will you do?");
                    if(input == '1')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("I can’t believe you did that!");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("You haven't changed at ALL!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Health decreased by 10%");
                        float TakeDamage = player.Attack(player);
                        Console.WriteLine("\n" + player.GetName() + " recieved " + 10 + " points of damage.");
                        badKarma += 3;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("I see... Thank you!");
                        goodKarma += 3;
                        Continue();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You go inside and see that the room matched with the hospital room, moldy and damp. In the middle of the room you see a woman in the middle.");
                    GetInput(out input, "Approach the woman", "Leave her alone", "What will you do?");
                    if(input == '1')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYou approach the woman and notice that she’s crying. You feel a pain of regret in your heart. You have no memories of this woman and feel no connection to her yet you know, this woman has something to do with your memory.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Can you help her?");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You nod, and walk up to the woman, you gently put your hand on her shoulder. She turns around to you and stops crying. She sniffles a bit.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("What is your name?");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("‘Lataja Wilkins’ the woman whispered to you ‘you don’t remember me but that's fine...Don’t run away.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You look at her face and notice blood dripping down her head, her arms wrapping around her swollen belly.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("What's your child's name?");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Ikea, weird name right? But it holds so much meaning for me. My family grew to four and I can never be prouder... You don't remember what happened?");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nShe walked over to a draw with a limp, you start noticing how pale and...transparent she is. She opens the drawer and retrieves a ball of light.");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Thank you for talking to me, what you did was a mistake but you can make up for it.");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The light drifted towards you and you feel a weight has lifted somewhat. You look back at the woman only to realize that she is gone. You walk back out of the room wondering what type of person you were.");
                        goodKarma += 6;
                        Continue();
                        gameOver = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n...why?");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You walk away from the woman in fear, what is it that is fearing you, you do not know but you do know that the woman might be the reason why you're here.");
                        Console.WriteLine("You notice blood dripping down onto the floor and see the woman turn to you. Her dress bloody, her skin pale and transparent, and most of all the hatred on her face terrifies you.");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("You do not learn! You leave others behind after the mess you made yet you only care for yourself!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("She rushed towards you and ripped a light from you, the weight on your shoulder grew and the pain on your skull worsened.");
                        badKarma += 6;
                        Continue();
                        gameOver = true;
                    }
                }
            }
        }
    }
}
