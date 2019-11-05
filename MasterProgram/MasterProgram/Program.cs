using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MasterProgram
{
    class Program
    {
        //GLOBAL VARIABLES INITIALIZATION
        public static Random rand = new Random();
        public static bool firstWhileCondition = true, secondWhileCondition = true, thirdWhileCondition = true, anythingElseCondition = true;
        public static bool inventoryCheck = false; //Auxiliar boolean to check whether the inventory is empty or not
        public static bool Bill = false, Francisco = false, Mitchell = false, Nabeel = false; // These values decide the route of the game
        public static string separator; //Helps to orginize the text files
        public static int x = 0, y = 0, z = 0;  //COORDINATES
        public static int savingX = 0, savingY = 0, savingZ = 0;  //SAVED COORDINATES
        //INVENTORY
        public static string[] inventory = new string[10];
        //LOCATION BOOLEANS
        public static bool introduction = true;
        public static bool messageSeen = false;
        public static bool phoneCharged = false; //Available
        public static bool firsTimeMCTurnsPhoneOn = true; //Available
        public static bool boolean5 = false; //Available
        public static bool boolean6 = false; //Available
        public static bool boolean7 = false; //Available
        public static bool boolean8 = false; //Available
        public static bool boolean9 = false; //Available
        public static bool boolean10 = false; //Available


        // LOCATION ARRAYS CREATION
        public static string[] location001 = new string[10];
        public static string[] location101 = new string[10];
        public static string[] location1n11 = new string[10];
        public static string[] location111 = new string[10];
        public static string[] location102 = new string[10];
        public static string[] location1n12 = new string[10];
        public static string[] location100 = new string[10];
        public static string[] location110 = new string[10];
        public static string[] location120 = new string[10];




        //METHODS
        public static void DisplayCoordinates(string answer)
        {
            switch (answer)
            {
                case "c":
                case "coordinates":
                    Console.WriteLine($"Current location: ({x},{y},{z})");
                    anythingElseCondition = false;
                    break;
            }
        } //This method is like a development tool to display the current coordinates
        public static void SavingCoordinates()
        {
            savingX = x;
            savingY = y;
            savingZ = z;
        }
        public static void LoadSavedCoordinates()
        {
            x = savingX;
            y = savingY;
            z = savingZ;
        }
        public static void ReadingNewGameSettings()
        {
            StreamReader sr = new StreamReader("newGameSettings.txt");
            separator = sr.ReadLine();//COORDINATES
            x = Convert.ToInt32(sr.ReadLine());
            y = Convert.ToInt32(sr.ReadLine());
            z = Convert.ToInt32(sr.ReadLine());

            separator = sr.ReadLine();//BOOLEANS
            introduction = Convert.ToBoolean(sr.ReadLine());
            messageSeen = Convert.ToBoolean(sr.ReadLine());
            phoneCharged = Convert.ToBoolean(sr.ReadLine());
            firsTimeMCTurnsPhoneOn = Convert.ToBoolean(sr.ReadLine());
            boolean5 = Convert.ToBoolean(sr.ReadLine());
            boolean6 = Convert.ToBoolean(sr.ReadLine());
            boolean7 = Convert.ToBoolean(sr.ReadLine());
            boolean8 = Convert.ToBoolean(sr.ReadLine());
            boolean9 = Convert.ToBoolean(sr.ReadLine());
            boolean10 = Convert.ToBoolean(sr.ReadLine());

            separator = sr.ReadLine();//INVENTORY
            for (int i = 0; i < inventory.Length; i++)
            {
                inventory[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 001
            for (int i = 0; i < location001.Length; i++)
            {
                location001[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 101
            for (int i = 0; i < location101.Length; i++)
            {
                location101[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 1n11
            for (int i = 0; i < location1n11.Length; i++)
            {
                location1n11[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 111
            for (int i = 0; i < location111.Length; i++)
            {
                location111[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 102
            for (int i = 0; i < location102.Length; i++)
            {
                location102[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 1n12
            for (int i = 0; i < location1n12.Length; i++)
            {
                location1n12[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 100
            for (int i = 0; i < location100.Length; i++)
            {
                location100[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 110
            for (int i = 0; i < location110.Length; i++)
            {
                location110[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 120
            for (int i = 0; i < location120.Length; i++)
            {
                location120[i] = sr.ReadLine();
            }
            sr.Close();
        }  //This method must be updated every time a new location is created
        public static void ReadingSavedGameSettings()
        {
            StreamReader sr = new StreamReader("save.txt");
            separator = sr.ReadLine();//COORDINATES
            x = Convert.ToInt32(sr.ReadLine());
            y = Convert.ToInt32(sr.ReadLine());
            z = Convert.ToInt32(sr.ReadLine());

            separator = sr.ReadLine();//BOOLEANS
            introduction = Convert.ToBoolean(sr.ReadLine());
            messageSeen = Convert.ToBoolean(sr.ReadLine());
            phoneCharged = Convert.ToBoolean(sr.ReadLine());
            firsTimeMCTurnsPhoneOn = Convert.ToBoolean(sr.ReadLine());
            boolean5 = Convert.ToBoolean(sr.ReadLine());
            boolean6 = Convert.ToBoolean(sr.ReadLine());
            boolean7 = Convert.ToBoolean(sr.ReadLine());
            boolean8 = Convert.ToBoolean(sr.ReadLine());
            boolean9 = Convert.ToBoolean(sr.ReadLine());
            boolean10 = Convert.ToBoolean(sr.ReadLine());

            separator = sr.ReadLine();//INVENTORY
            for (int i = 0; i < inventory.Length; i++)
            {
                inventory[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 001
            for (int i = 0; i < location001.Length; i++)
            {
                location001[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 101
            for (int i = 0; i < location101.Length; i++)
            {
                location101[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 1n11
            for (int i = 0; i < location1n11.Length; i++)
            {
                location1n11[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 111
            for (int i = 0; i < location111.Length; i++)
            {
                location111[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 102
            for (int i = 0; i < location102.Length; i++)
            {
                location102[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 1n12
            for (int i = 0; i < location1n12.Length; i++)
            {
                location1n12[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 100
            for (int i = 0; i < location100.Length; i++)
            {
                location100[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 110
            for (int i = 0; i < location110.Length; i++)
            {
                location110[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 120
            for (int i = 0; i < location120.Length; i++)
            {
                location120[i] = sr.ReadLine();
            }
            sr.Close();
        }  //This method must be updated every time a new location is created
        public static void SaveGame(string answer)
        {
            if (answer == "save")
            {
                StreamWriter sw = new StreamWriter("save.txt");
                sw.WriteLine("Coordinates");//COORDINATES
                sw.WriteLine(x);
                sw.WriteLine(y);
                sw.WriteLine(z);
                sw.WriteLine("Booleans");//BOOLEANS
                sw.WriteLine(introduction);
                sw.WriteLine(messageSeen);
                sw.WriteLine(phoneCharged);
                sw.WriteLine(firsTimeMCTurnsPhoneOn);
                sw.WriteLine(boolean5);
                sw.WriteLine(boolean6);
                sw.WriteLine(boolean7);
                sw.WriteLine(boolean8);
                sw.WriteLine(boolean9);
                sw.WriteLine(boolean10);
                sw.WriteLine("Inventory");//INVENTORY
                for (int i = 0; i < inventory.Length; i++)
                {
                    sw.WriteLine(inventory[i]);
                }
                sw.WriteLine("LOCATION 001 D201");
                for (int i = 0; i < location001.Length; i++)
                {
                    sw.WriteLine(location001[i]);
                }
                sw.WriteLine("LOCATION 101 OUTSIDE D201");
                for (int i = 0; i < location101.Length; i++)
                {
                    sw.WriteLine(location101[i]);
                }
                sw.WriteLine("LOCATION 1n11 COMMON ROOM");
                for (int i = 0; i < location1n11.Length; i++)
                {
                    sw.WriteLine(location1n11[i]);
                }
                sw.WriteLine("LOCATION 111 ROB");
                for (int i = 0; i < location111.Length; i++)
                {
                    sw.WriteLine(location111[i]);
                }
                sw.WriteLine("LOCATION 102 THIRD FLOOR");
                for (int i = 0; i < location102.Length; i++)
                {
                    sw.WriteLine(location102[i]);
                }
                sw.WriteLine("LOCATION 1n12 ELISE's OFFICE");
                for (int i = 0; i < location1n12.Length; i++)
                {
                    sw.WriteLine(location1n12[i]);
                }
                sw.WriteLine("LOCATION 100 FIRST FLOOR");
                for (int i = 0; i < location100.Length; i++)
                {
                    sw.WriteLine(location100[i]);
                }
                sw.WriteLine("LOCATION 110 OUTSIDE OF D BLOCK");
                for (int i = 0; i < location110.Length; i++)
                {
                    sw.WriteLine(location110[i]);
                }
                sw.WriteLine("LOCATION 120");
                for (int i = 0; i < location120.Length; i++)
                {
                    sw.WriteLine(location120[i]);
                }
                sw.WriteLine("Placeholder");
                sw.Close();
                Console.WriteLine("Game saved.");
                anythingElseCondition = false;
            }
        }  //This method must be updated every time a new location is created
        public static void Navigation(string answer)
        {
            switch (answer)
            {
                case "n":
                case "north":
                    y++;
                    secondWhileCondition = false;
                    anythingElseCondition = false;
                    break;
                case "w":
                case "west":
                    x--;
                    secondWhileCondition = false;
                    anythingElseCondition = false;
                    break;
                case "e":
                case "east":
                    x++;
                    secondWhileCondition = false;
                    anythingElseCondition = false;
                    break;
                case "s":
                case "south":
                    y--;
                    secondWhileCondition = false;
                    anythingElseCondition = false;
                    break;
                case "up":
                case "u":
                    if (z < 2)
                    {
                        z++;
                        secondWhileCondition = false;
                        anythingElseCondition = false;
                    }
                    else
                    {
                        Console.WriteLine("You can't go up");
                        anythingElseCondition = false;
                    }
                    break;
                case "down":
                case "d":
                    if (0 < z)
                    {
                        z--;
                        secondWhileCondition = false;
                        anythingElseCondition = false;
                    }
                    else
                    {
                        Console.WriteLine("You can't go down");
                        anythingElseCondition = false;
                    }
                    break;
            }
        }
        public static void LookingAround(string answer, string[] location)
        {
            switch (answer)
            {
                case "l":
                case "look":
                    if (location.Contains("keys"))
                    {
                        //Custom Dscription for location 001
                        if (x == 0 && y == 0 && z == 1) Console.WriteLine("There is a desk with some keys on it here");
                        //Generic Description for anywhere else
                        else
                        {
                            int randomNumber = rand.Next(4);
                            if (randomNumber == 0) Console.WriteLine("There are some keys nearby");
                            else if (randomNumber == 1) Console.WriteLine("There are some keys on the floor here");
                            else if (randomNumber == 2) Console.WriteLine("There are some keys on the ground here");
                            else if (randomNumber == 3) Console.WriteLine("You can see some keys here");
                        }
                    }
                    if (location.Contains("phone"))
                    {
                        //Generic Description
                        int randomNumber = rand.Next(4);
                        if (randomNumber == 0) Console.WriteLine("There is a phone nearby");
                        else if (randomNumber == 1) Console.WriteLine("There is a phone on the floor here");
                        else if (randomNumber == 2) Console.WriteLine("There is a phone on the ground here");
                        else if (randomNumber == 3) Console.WriteLine("You can see a phone here");

                    }
                    if (location.Contains("bottle"))
                    {
                        //Generic Description
                        int randomNumber = rand.Next(4);
                        if (randomNumber == 0) Console.WriteLine("There is a bottle nearby");
                        else if (randomNumber == 1) Console.WriteLine("There is a bottle on the floor here");
                        else if (randomNumber == 2) Console.WriteLine("There is a bottle on the ground here");
                        else if (randomNumber == 3) Console.WriteLine("You can see a bottle here");

                    }
                    if (location.Contains("photo"))
                    {
                        //Generic Description
                        int randomNumber = rand.Next(4);
                        if (randomNumber == 0) Console.WriteLine("There is a photo nearby");
                        else if (randomNumber == 1) Console.WriteLine("There is a photo on the floor here");
                        else if (randomNumber == 2) Console.WriteLine("There is a photo on the ground here");
                        else if (randomNumber == 3) Console.WriteLine("You can see a photo here");

                    }
                    if (location.Contains("charger"))
                    {
                        //Generic Description
                        int randomNumber = rand.Next(4);
                        if (randomNumber == 0) Console.WriteLine("There is a charger nearby");
                        else if (randomNumber == 1) Console.WriteLine("There is a charger on the floor here");
                        else if (randomNumber == 2) Console.WriteLine("There is a charger on the ground here");
                        else if (randomNumber == 3) Console.WriteLine("You can see a charger here");
                    }

                    bool empty = true; //This is an auxiliar boolean to help us determine if there are items in this location or not, if it remain true the location is empty
                    for (int i = 0; i < location.Length; i++)
                    {
                        if (location[i] != "") empty = false;
                    }
                    if (empty) Console.WriteLine("There is nothing interesting to look at here.");
                    anythingElseCondition = false;
                    break;
            }
        }//This has to be updated with when any new item is added to the game
        public static void DisplayInventory(string answer)
        {
            switch (answer)
            {
                case "i":
                case "inventory":
                    inventoryCheck = false;
                    //This foor-loop evaluates whether the inventory is empty or not, if it has at least one item, it activates "inventoryCheck"
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        if (inventory[i] != "") inventoryCheck = true;
                    }
                    //If "inventoryCheck" is activated, the contents are displayed
                    if (inventoryCheck)
                    {
                        Console.WriteLine("You currently have the following items:");
                        for (int i = 0; i < inventory.Length; i++)
                        {
                            if (inventory[i] != "")
                            {
                                Console.WriteLine(inventory[i]);
                            }
                        }
                    }
                    //If "inventoryCheck" is not activated, a message is displayed instead
                    else Console.WriteLine("You don't have any items yet.\n");
                    anythingElseCondition = false;
                    break;
            }
        }
        public static void AddItemToInventory(string item)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == "")
                {
                    inventory[i] = item;
                    break;
                }
            }
        }
        public static void RemoveItemFromInventory(string item)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == item)
                {
                    inventory[i] = "";
                    break;
                }
            }
        }
        public static void AddItemToCurrentLocation(string item, string[] location)
        {
            for (int i = 0; i < location.Length; i++)
            {
                if (location[i] == "")
                {
                    location[i] = item;
                    break;
                }
            }
        }
        public static void RemoveItemFromCurrentLocation(string item, string[] location)
        {
            for (int i = 0; i < location.Length; i++)
            {
                if (location[i] == item)
                {
                    location[i] = "";
                    break;
                }
            }
        }
        public static void GetDrop(string answer, string[] location)
        {
            if (answer.Contains(" ")) //This condition makes sure that the string can be split into two words
            {
                string[] answerSplit = answer.Split(' ');  //Splitting string

                // GET, TAKE, GRAB
                if (answer == "get " + answerSplit[1] || answer == "take " + answerSplit[1] || answer == "grab " + answerSplit[1] || answer == "pick " + answerSplit[1])
                {
                    if (location.Contains(answerSplit[1]))  //Searches second word in the current location items, if true, it adds it
                    {
                        Console.WriteLine("Understood");
                        AddItemToInventory(answerSplit[1]);
                        RemoveItemFromCurrentLocation(answerSplit[1], location);
                    }
                    else if (inventory.Contains(answerSplit[1]))  //Searches second word in the inventory, if true, it tells player it has it already
                    {
                        Console.WriteLine("You already have this item");
                    }
                    else // This case is run when the item is neither in the current location nor the inventory
                    {
                        Console.WriteLine("You can't add this item");
                    }
                    anythingElseCondition = false;
                }

                //DROP, DISCARD, REMOVE
                if (answer == "drop " + answerSplit[1] || answer == "discard " + answerSplit[1] || answer == "remove " + answerSplit[1])
                {
                    if (location.Contains(answerSplit[1]))  //Searches second word in the current location items, if true, it tells playe that doesn't have it
                    {
                        Console.WriteLine("You don't have this item...");
                    }
                    else if (inventory.Contains(answerSplit[1]))  //Searches second word in the inventory, if true, drops the item
                    {
                        Console.WriteLine("Understood");
                        RemoveItemFromInventory(answerSplit[1]);
                        AddItemToCurrentLocation(answerSplit[1], location);
                    }
                    else // This case is run when the item is neither in the current location nor the inventory (Same phrase as in the "if" above)
                    {
                        Console.WriteLine("You don't have this item...");
                    }
                    anythingElseCondition = false;
                }
            }
        }
        public static void WAT(string answer)
        {
            switch (answer)
            {
                ///////////////////////////////////////
                case "get":
                    Console.WriteLine("get what?");
                    anythingElseCondition = false;
                    break;
                case "take":
                    Console.WriteLine("take what?");
                    anythingElseCondition = false;
                    break;
                case "grab":
                    Console.WriteLine("grab what?");
                    anythingElseCondition = false;
                    break;
                case "pick":
                    Console.WriteLine("pick what?");
                    anythingElseCondition = false;
                    break;
                ////////////////////////////////////////
                case "drop":
                    Console.WriteLine("drop what?");
                    anythingElseCondition = false;
                    break;
                case "discard":
                    Console.WriteLine("discard what?");
                    anythingElseCondition = false;
                    break;
                ///////////////////////////////
                case "nothing":
                    Console.WriteLine("Ok");
                    anythingElseCondition = false;
                    break;
                case "love":
                    Console.WriteLine("If only our love could last forever <3");
                    anythingElseCondition = false;
                    break;
                case "kappa":
                    Console.WriteLine("This is not a twitch stream");
                    anythingElseCondition = false;
                    break;
            }
        }
        public static void ItemDetails(string answer, string[] location)
        {
            if (inventory.Contains(answer) || location.Contains(answer))
            {
                for (int i = 0; i < inventory.Length; i++)
                {
                    if (answer == inventory[i])
                    {
                        Console.WriteLine("What do you want to do with the {0}?", inventory[i]);
                        anythingElseCondition = false;
                    }
                    if (answer == location[i])
                    {
                        Console.WriteLine("What do you want to do with the {0}?", location[i]);
                        anythingElseCondition = false;
                    }
                }
            }
        } // When they input just the name of an item
        public static void InspectItem(string answer, string[] location)
        {
            if (answer.Contains(" ")) //This condition makes sure that the string can be split into two words
            {
                string[] answerSplit = answer.Split(' ');  //Splitting string

                // INSPECT, EXAMINE
                if (answer == "inspect " + answerSplit[1] || answer == "examine " + answerSplit[1])
                {
                    if (location.Contains(answerSplit[1]) || inventory.Contains(answerSplit[1]))  //Searches second word in the items of the current location or in the inventory, if true, it tells the player a description of it
                    {
                        switch (answerSplit[1])
                        {
                            //Here all the items in the game appear
                            case "keys":
                                Console.WriteLine("Some keys that unlock some door.");
                                break;
                            case "phone":
                                Console.WriteLine("Your mobile phone, probably you can use it if it's charged.");
                                break;
                            case "bottle":
                                Console.WriteLine("An empty plastic bottle.");
                                break;
                            case "photo":
                                Console.WriteLine("A photo of Rob the IT guy, looking adorable :3");
                                break;
                            case "charger":
                                Console.WriteLine("A charger that you can use to charge up your phone.");
                                break;
                        }
                    }
                    else // This case is run when the item is neither in the current location nor the inventory
                    {
                        Console.WriteLine("Find it first lol.");
                    }
                    anythingElseCondition = false;
                }
            }
        }    //Offers a description of the item to the player
        public static void UseItem(string answer)  //USE + ITEM PLUS ESPECIAL COMMANDS
        {
            if (answer.Contains(" ")) //This condition makes sure that the string can be split into two words
            {
                string[] answerSplit = answer.Split(' ');  //Splitting string

                // USE
                if (answer == "use " + answerSplit[1] || answer == "utilize " + answerSplit[1])
                {
                    if (inventory.Contains(answerSplit[1]))  //You can only use items you have in your inventory
                    {
                        switch (answerSplit[1])
                        {
                            //Here all the items in the game appear
                            case "keys":
                                Console.WriteLine("Placeholder");
                                break;
                            case "phone":
                                Console.WriteLine("Placeholder");
                                break;
                            case "bottle":
                                Console.WriteLine("Placeholder");
                                break;
                            case "photo":
                                Console.WriteLine("How?");
                                break;
                            case "charger":
                                Console.WriteLine("How?");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have that");
                    }
                    anythingElseCondition = false;
                }

                //SPECIAL INPUTS//////////////////////////////////////////////////////////////////////////////////////////////

                //CHARGE PHONE
                if (answer == "charge phone")
                {
                    if ((x == 1 && y == -1 && z == 2) && inventory.Contains("phone") && inventory.Contains("charger"))
                    {
                        Console.WriteLine("You have charged your phone");
                        phoneCharged = true;
                    }
                    else if (inventory.Contains("phone") && inventory.Contains("charger"))
                    {
                        Console.WriteLine("You need a power source");
                    }
                    else Console.WriteLine("That's not possible");
                    anythingElseCondition = false;
                }
                //TURN PHONE ON
                if (answer == "turn on phone" || answer == "turn phone on" || answer == "power on phone" || answer == "power phone on")
                {
                    if (phoneCharged && inventory.Contains("phone") && firsTimeMCTurnsPhoneOn)
                    {
                        firsTimeMCTurnsPhoneOn = false;
                        messageSeen = true;
                        Console.WriteLine("You have received a new message: \"With Spark you can auto-renew your PrePaid Value Plan via credit card…\"");
                        Console.WriteLine("You: These %#^&^* ads!!!");
                        Console.WriteLine("As you look into your messages, you notice 50 unread messages from the same person from 3 days ago.");
                        Console.WriteLine("They all say that the University is the nearest safe zone.");
                    }
                    else if (phoneCharged && inventory.Contains("phone")) Console.WriteLine("It's already on");
                    else Console.WriteLine("That's not possible");
                    anythingElseCondition = false;
                }
            }
        }    //Makes use of the items as long as they are in the inventory
        public static void ExitGame(string answer)
        {
            switch (answer)
            {
                case "exit":
                case "quit":
                    Console.WriteLine("Are you sure you want to quit the game? (Y/N):");

                    thirdWhileCondition = true;
                    while (thirdWhileCondition)
                    {
                        Console.Write("\n>");
                        string yesNoAnswer = Console.ReadLine();

                        if (yesNoAnswer != "")
                        {
                            yesNoAnswer = yesNoAnswer.ToLower();
                            if (yesNoAnswer[0] == 'y')
                            {
                                firstWhileCondition = false;
                                secondWhileCondition = false;
                                thirdWhileCondition = false;
                            }
                            else if (yesNoAnswer[0] == 'n')
                            {
                                secondWhileCondition = false;
                                thirdWhileCondition = false;
                            }
                            else Console.WriteLine("Please enter a valid input");
                        }
                        else Console.WriteLine("Please enter a valid input");
                    }
                    anythingElseCondition = false;
                    break;
            }
        }
        public static void AnythingElse()
        {
            int randomNumber = rand.Next(4);
            if (randomNumber == 0) Console.WriteLine("What?");
            else if (randomNumber == 1) Console.WriteLine("Pardon?");
            else if (randomNumber == 2) Console.WriteLine("Nani?");
            else if (randomNumber == 3) Console.WriteLine("I don't understand that");
            else if (randomNumber == 4) Console.WriteLine("I don't know that expression");
        }
        public static void CollectionOfMethods(string answer, string[] location)
        {
            answer = answer.ToLower(); // This instruction is important, it converts the input into lower case so that the rest of the methods can work with only lowercase inputs
            //Methods
            DisplayCoordinates(answer);
            ExitGame(answer);
            Navigation(answer);
            LookingAround(answer, location);
            ItemDetails(answer, location);
            InspectItem(answer, location);
            UseItem(answer);
            GetDrop(answer, location);
            DisplayInventory(answer);
            SaveGame(answer);
            WAT(answer);
        }
        public static void CommandAnalysis(string[] location)
        {
            secondWhileCondition = true;
            while (secondWhileCondition) //SECOND WHILE
            {
                anythingElseCondition = true; // If this boolean remains true it activates "AnythingElse()" which tells the user that it doesn't know the command they entered
                Console.Write("\n>");
                string answer = Console.ReadLine();
                if (answer != "") // This if-statement avoids getting an error if the user presses enter accidentally
                {
                    CollectionOfMethods(answer, location);
                    if (anythingElseCondition) AnythingElse();  //Here is "AnythingElse()"
                }
                else Console.WriteLine("Please enter a valid command");
            }
        }
        //MAIN GAME
        public static void MainGAME(int inputFromMenu)
        {
            if (inputFromMenu == 1) ReadingNewGameSettings();    // NEW GAME
            if (inputFromMenu == 2) ReadingSavedGameSettings();  // RESUME GAME

            //INSTRUCTIONS
            Console.WriteLine("SEVERAL LINES WITH INSTRUCTIONS IN THIS PART");

            Console.Write("Press enter to start:");
            Console.ReadLine();
            Console.Clear();

            //Main While-Loop
            firstWhileCondition = true;
            while (firstWhileCondition) //FIRST WHILE
            {
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (x == 0 && y == 0 && z == 1) //LOCATION 001 D201
                {
                    SavingCoordinates();
                    if (introduction)
                    {
                        Console.WriteLine("You wake up in the middle of D201 and don’t remember anything at all. The lights seem");
                        Console.WriteLine("to be off for some reason. Outside, a cold and dark evening lies upon Dunedin.");
                        introduction = false;
                    }
                    else Console.WriteLine("You are in the D201 classroom you once loved.");
                    CommandAnalysis(location001);
                } //LOCATION 001 D201
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 0 && z == 1) //LOCATION 101 OUTSIDE D201
                {
                    SavingCoordinates();
                    Console.WriteLine("You are in the second floor. \nYou can see the stairs and some rooms");
                    CommandAnalysis(location101);
                }//LOCATION 101 OUTSIDE D201
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == -1 && z == 1) //LOCATION 1n11 COMMON ROOM
                {
                    if (savingX == 1 && savingY == -1 && savingZ == 2) //If the saved coordinates match with Elise's office coordinates then it displays that you can't go that way
                    {
                        Console.WriteLine("You can't go this way\n");
                        LoadSavedCoordinates();
                    }
                    else
                    {
                        SavingCoordinates();
                        Console.WriteLine("You are in the common room.");
                        CommandAnalysis(location1n11);
                    }
                }//LOCATION 1n11 COMMON ROOM
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 1 && z == 1) //LOCATION 111 ROB
                {
                    if (savingX == 1 && savingY == 1 && savingZ == 0) //If the saved coordinates match with the common room coordinates then it displays that you can't go that way
                    {
                        Console.WriteLine("You can't go this way\n");
                        LoadSavedCoordinates();
                    }
                    else
                    {
                        SavingCoordinates();
                        Console.WriteLine("You are in ROB's office, you wonder if you can find anything useful here.");
                        CommandAnalysis(location111);
                    }
                }//LOCATION 111 ROB
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 0 && z == 2) //LOCATION 102 THIRD FLOOR
                {
                    SavingCoordinates();
                    Console.WriteLine("You are in the third floor. \nYou can see the stairs and a weak light comming out of one of the rooms");
                    CommandAnalysis(location102);
                }//LOCATION 102 THIRD FLOOR
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == -1 && z == 2) //LOCATION 1n12 ELISE's OFFICE
                {
                    if (savingX == 1 && savingY == -1 && savingZ == 1) //If the saved coordinates match with the common room coordinates then it displays that you can't go that way
                    {
                        Console.WriteLine("You can't go this way\n");
                        LoadSavedCoordinates();
                    }
                    else
                    {
                        SavingCoordinates();
                        Console.WriteLine("When you step into Elise's office, you see that the light was comming from one of the computers which seems to be still turned on thanks to a UPS.");
                        Console.WriteLine("Apparently it is the only source of energy available in this building.");
                        Console.WriteLine("Suddenly, you turn your head to your left and see a corpse lying on the floor. After this you realize that \"the shit has hit the fan\".");
                        CommandAnalysis(location1n12);
                    }

                }//LOCATION 1n12 ELISE's OFFICE
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 0 && z == 0) //LOCATION 100 FIRST FLOOR
                {
                    SavingCoordinates();
                    Console.WriteLine("You are in the first floor. \nYou can see the stairs and an exit.");
                    CommandAnalysis(location100);
                }//LOCATION 100 FIRST FLOOR
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 1 && z == 0) //LOCATION 110 OUTSIDE OF D BLOCK
                {
                    if (savingX == 1 && savingY == 1 && savingZ == 1) //If the saved coordinates match with the common room coordinates then it displays that you can't go that way
                    {
                        Console.WriteLine("You can't go this way\n");
                        LoadSavedCoordinates();
                    }
                    else
                    {
                        if (messageSeen)
                        {
                            SavingCoordinates();
                            Console.WriteLine("You are outside the D block, the hostile atmosphere chills your blood.");
                            CommandAnalysis(location110);
                        }
                        else
                        {
                            Console.WriteLine("You cannot leave the building yet.\n");
                            LoadSavedCoordinates();
                        }
                    }
                }//LOCATION 110 OUTSIDE OF D BLOCK
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 2 && z == 0) //LOCATION 120
                {
                    SavingCoordinates();
                    Console.WriteLine("You are in location 120");
                    CommandAnalysis(location100);
                }//LOCATION 110 OUTSIDE OF D BLOCK
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                //RED ZONES SECOND FLOOR DBLOCK
                else if (x == 0 && y == 1 && z == 1) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); }  //0,1,1
                else if (x == -1 && y == 0 && z == 1) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); } //-1,0,1
                else if (x == 0 && y == -1 && z == 1) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); } //0,-1,1
                else if (x == 1 && y == -2 && z == 1) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); } //1,-2,1
                else if (x == 2 && y == 0 && z == 1) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); } //2,0,1
                else if (x == 2 && y == -1 && z == 1) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); } //2,-1,1
                else if (x == 1 && y == 2 && z == 1) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); } //1,2,1
                else if (x == 2 && y == 1 && z == 1) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); } //2,1,1

                //RED ZONES THIRD FLOOR DBLOCK
                else if (x == 1 && y == 1 && z == 2) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); }  //1,1,2
                else if (x == 0 && y == 0 && z == 2) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); }  //0,0,2
                else if (x == 2 && y == 0 && z == 2) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); }  //2,0,2
                else if (x == 0 && y == -1 && z == 2) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); }  //0,-1,2
                else if (x == 2 && y == -1 && z == 2) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); }  //2,-1,2
                else if (x == 1 && y == -2 && z == 2) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); }  //1,-2,2

                //RED ZONES FIRST FLOOR D BLOCK
                else if (x == 2 && y == 0 && z == 0) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); }
                else if (x == 1 && y == -1 && z == 0) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); }
                else if (x == 0 && y == 0 && z == 0) { Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); }
            }
        }
        public static void decisionRoutes()
        {
            if (Bill && Mitchell)
            {

            }
            else if (Bill && Francisco)
            {

            }
            else if (Nabeel && Mitchell)
            {

            }
            else if (Nabeel && Francisco)
            {

            }
        }
        static void Main()
        {
            Console.WriteLine("New Game press 1");
            Console.WriteLine("Resume Game press 2");
            Console.Write("Answer: ");
            MainGAME(Convert.ToInt32(Console.ReadLine()));
        }
    }
}
