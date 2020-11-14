| Cailey Marie Bianchini && |
| :---          	|
| Little Monster Documentation |
| https://github.com/jeremyjflowers/A-Little-Monster |
| Game jam 2020 |
|November 14, 2020|

## I. Requirements

1. Description of Problem

	- **Name**: Topia

	- **Problem Statement**: In 24 hours create a game within the prompt
	
	- **Problem Specifications**:  must be on console and the theme should be about "Within"
    

2. Input Information
- Get Input Numbers - Player will be asked to select things out of a list, can be two choices, some will have 6 choices.
- Name? - You will be asked to type in the name you want for the character you will be plaing.

1.  Output Information
- When you enter your choice, that choice will be the only one played and will effect how the game is played, this is in both versions that you can play.
- When you input your name, anywhere that requires to print players name, it will print the name that you inputed.
 
## II. Errors

    1. 



### Object Information

**File**: Program.cs

**Attributes**

         Name: Main(string[] args)
             Description: This will start the program in what ever is in Game()
             Type: static void


**File**: Game.cs

**Attributes**

         Name: Continue()
             Description: Allows for a simpler way to clear console while letting player time
             Type: public void
         Name: GetInput()
             Description: Allows for the player to input two choices and print why they need to choose options
             Type: public void
         Name: GetInput()
             Description: Allows for the player to input three choices and print why they need to choose options
             Type: public void
         Name: GetInput()
             Description: Allows for the player to input four choices and print why they need to choose options
             Type: public void
         Name: Run()
             Description: This will allow the program to runwhat is inside of it, and only that
             Type: public void
         Name: Start()
             Description: This will happen at the "Start" of Run. everything that is inside of this will run first
             Type: public void
         Name: Update()
             Description: Information inside of update will update the information needed for the game to run.
             Type: public void
         Name: End()
             Description: Anything that is put in this will always be played towards the end of the program before closing. This time around it will have story ends.
             Type: public void
	Name: Prologue()
             Description: This will hold the start of the story and introducing characters and gets players name
             Type: public void
	Name: MainStory()
             Description: This will hold the main game, this will hold what effects the ending.
             Type: public void
	Name: BattleStart()
             Description: Takes in 2 entities and performs battle between them.
             Type: public void

**File**: Entity.cs

**Attributes**

         Name: Entity()
             Description: gives _name, _health, and _damage a set value
             Type: public 
	Name: Entity(string nameVal, float healthVal, int damageVal)
             Description: gives _name, _health, and _damage a new name
             Type: public
	Name: TakeDamage(float damageVal)
             Description: this subtracts enemies/players damage from enemies/players health. If 
             Type: public  float
	Name: Attack()
             Description: with the use of TakeDamage() it applies it to an enemy, player can also be an enemy
             Type: public float
	Name: GetName()
             Description: returns _name
             Type: public string
	Name: GetIsAlive()
             Description: returns health over 0 if true;
             Type: public bool
	Name: GetIsNotAlive()
             Description: returns health under 1 if false;
             Type: public bool

        

