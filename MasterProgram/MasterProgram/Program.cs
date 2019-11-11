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
        public static Random rand = new Random();

        //VARIABLE DECLARATION
        public static bool firstWhileCondition = true, secondWhileCondition = true, thirdWhileCondition = true, anythingElseCondition = true, zombieLoop = true, zombieBoolean = false;
        public static bool inventoryCheck = false; //Auxiliar boolean to check whether the inventory is empty or not
        public static string separator; //Helps to orginize the text files
        
        //COORDINATES
        public static int x = 0, y = 0, z = 0; 
        public static int savingX = 0, savingY = 0, savingZ = 0;  //SAVED COORDINATES

        //INVENTORY
        public static string[] inventory = new string[10];

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
        public static string[] location1n10 = new string[10];
        public static string[] location202 = new string[10];
		public static string[] location0n20 = new string[10];
		public static string[] location1n40 = new string[10];
		public static string[] location2n30 = new string[10];
		public static string[] location2n20 = new string[10];
		public static string[] location1n30 = new string[10];
		public static string[] location1n20= new string[10];

		//LOCATION BOOLEANS
		public static bool Bill = false, Francisco = false, Mitchell = false, Nabeel = false; // These values decide the route of the game
        public static bool introduction = true;
        public static bool messageSeen = false;
        public static bool phoneCharged = false;
        public static bool firstTimeMCTurnsPhoneOn = true;
        public static bool passwordCheck = false;
        public static bool firstTimeEliseOffice = true;
        public static bool secondTimeEliseOffice = false; 
        public static bool unlockedDoor = false;
        public static bool knowingWhatIsGoingOn = false;
        public static bool firstTimeServerRoom = true;
        public static bool serverRoomLoop = true;


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
            //newGameSettings
            StreamReader sr = new StreamReader("newGameSettings.txt");
            separator = sr.ReadLine();//COORDINATES
            x = Convert.ToInt32(sr.ReadLine());
            y = Convert.ToInt32(sr.ReadLine());
            z = Convert.ToInt32(sr.ReadLine());

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
            separator = sr.ReadLine();//ITEMS LOCATION 1n10
            for (int i = 0; i < location1n10.Length; i++)
            {
                location1n10[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 202
            for (int i = 0; i < location202.Length; i++)
            {
                location202[i] = sr.ReadLine();
            }
			separator = sr.ReadLine();//ITEMS LOCATION 1n20
			for (int i = 0; i < location1n20.Length; i++)
			{
				location1n20[i] = sr.ReadLine();
			}
			separator = sr.ReadLine();//ITEMS LOCATION 1n30
			for (int i = 0; i < location1n30.Length; i++)
			{
				location1n30[i] = sr.ReadLine();
			}
			separator = sr.ReadLine();//ITEMS LOCATION 2n20
			for (int i = 0; i < location2n20.Length; i++)
			{
				location2n20[i] = sr.ReadLine();
			}
			separator = sr.ReadLine();//ITEMS LOCATION 1n30
			for (int i = 0; i < location0n20.Length; i++)
			{
				location0n20[i] = sr.ReadLine();
			}
			separator = sr.ReadLine();//ITEMS LOCATION 1n40
			for (int i = 0; i < location1n40.Length; i++)
			{
				location1n40[i] = sr.ReadLine();
			}
			sr.Close();

            //BOOLEANS
            StreamReader zr = new StreamReader("newGameBooleans.txt");

            separator = zr.ReadLine();//introduction
            introduction = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//messageSeen
            messageSeen = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//phoneCharged
            phoneCharged = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//firstTimeTurnPhoneOn
            firstTimeMCTurnsPhoneOn = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//passwordCheck
            passwordCheck = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//firstTimeEliseOffice
            firstTimeEliseOffice = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//secondTimeEliseOffice
            secondTimeEliseOffice = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//unlockedDoor
            unlockedDoor = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//knowingWhatIsGoingOn
            knowingWhatIsGoingOn = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//firstTimeServerRoom
            firstTimeServerRoom = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//serverRoomLoop
            serverRoomLoop = Convert.ToBoolean(zr.ReadLine());
            zr.Close();
        }  //This method must be updated every time a new location is created
        public static void ReadingSavedGameSettings()
        {
            //newGameSettings
            StreamReader sr = new StreamReader("save.txt");
            separator = sr.ReadLine();//COORDINATES
            x = Convert.ToInt32(sr.ReadLine());
            y = Convert.ToInt32(sr.ReadLine());
            z = Convert.ToInt32(sr.ReadLine());

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
            separator = sr.ReadLine();//ITEMS LOCATION 1n10
            for (int i = 0; i < location1n10.Length; i++)
            {
                location1n10[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 202
            for (int i = 0; i < location202.Length; i++)
            {
                location202[i] = sr.ReadLine();
            }
            sr.Close();

            //BOOLEANS
            StreamReader zr = new StreamReader("saveBooleans.txt");

            separator = zr.ReadLine();//introduction
            introduction = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//messageSeen
            messageSeen = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//phoneCharged
            phoneCharged = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//firstTimeTurnPhoneOn
            firstTimeMCTurnsPhoneOn = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//passwordCheck
            passwordCheck = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//firstTimeEliseOffice
            firstTimeEliseOffice = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//secondTimeEliseOffice
            secondTimeEliseOffice = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//unlockedDoor
            unlockedDoor = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//knowingWhatIsGoingOn
            knowingWhatIsGoingOn = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//firstTimeServerRoom
            firstTimeServerRoom = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//serverRoomLoop
            serverRoomLoop = Convert.ToBoolean(zr.ReadLine());
            zr.Close();
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

                sw.WriteLine("Inventory");//INVENTORY
                for (int i = 0; i < inventory.Length; i++)
                {
                    sw.WriteLine(inventory[i]);
                }
                //LOCATIONS
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
                sw.WriteLine("LOCATION 1n10 South Exit");
                for (int i = 0; i < location1n10.Length; i++)
                {
                    sw.WriteLine(location1n10[i]);
                }
                sw.WriteLine("LOCATION 202 SERVER ROOM");
                for (int i = 0; i < location202.Length; i++)
                {
                    sw.WriteLine(location202[i]);
                }
				sw.WriteLine("LOCATION 1n20 Harbor Terrace");
				for (int i = 0; i < location1n20.Length; i++)
				{
					sw.WriteLine(location1n20[i]);
				}
				sw.WriteLine("LOCATION 2n20 Harbor Terrace");
				for (int i = 0; i < location2n20.Length; i++)
				{
					sw.WriteLine(location1n20[i]);
				}
				sw.WriteLine("LOCATION 0n20 Harbor Terrace");
				for (int i = 0; i < location0n20.Length; i++)
				{
					sw.WriteLine(location1n20[i]);
				}
				sw.WriteLine("LOCATION 1n30 Manaaki Car Park");
				for (int i = 0; i < location1n30.Length; i++)
				{
					sw.WriteLine(location1n20[i]);
				}
				sw.WriteLine("LOCATION 1n40 Dark alley");
				for (int i = 0; i < location1n40.Length; i++)
				{
					sw.WriteLine(location1n40[i]);
				}
				sw.WriteLine("Placeholder");
                sw.Close();

                //BOOLEANS
                StreamWriter zw = new StreamWriter("saveBooleans.txt");
                
                zw.WriteLine("introduction");
                zw.WriteLine(introduction);
                zw.WriteLine("messageSeen");
                zw.WriteLine(messageSeen);
                zw.WriteLine("phoneCharged");
                zw.WriteLine(phoneCharged);
                zw.WriteLine("firstTimeMCTurnsPhoneOn");
                zw.WriteLine(firstTimeMCTurnsPhoneOn);
                zw.WriteLine("passwordCheck");
                zw.WriteLine(passwordCheck);
                zw.WriteLine("firstTimeEliseOffice");
                zw.WriteLine(firstTimeEliseOffice);
                zw.WriteLine("secondTimeEliseOffice");
                zw.WriteLine(secondTimeEliseOffice);
                zw.WriteLine("unlockedDoor");
                zw.WriteLine(unlockedDoor);
                zw.WriteLine("knowingWhatIsGoingOn");
                zw.WriteLine(knowingWhatIsGoingOn);
                zw.WriteLine("firstTimeServerRoom");
                zw.WriteLine(firstTimeServerRoom);
                zw.WriteLine("serverRoomLoop");
                zw.WriteLine(serverRoomLoop);
                zw.Close();

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
                        Console.WriteLine("You can't go this way");
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
                        Console.WriteLine("You can't go this way");
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
                    bool empty = true; //This is an auxiliar boolean to help us determine if there are items in this location or not, if it remain true the location is empty

                    //CORPSE
                    if ((x == 1 && y == -1 && z == 2) && firstTimeEliseOffice)
                    {
                        Console.WriteLine("There is a corpse on the ground here");
                        empty = false;
                    }
                    if (location.Contains("keys"))
                    {
                        //Custom Dscription for LOCATION 1n12 ELISE's OFFICE
                        if (x == 1 && y == -1 && z == 2) Console.WriteLine("There are some keys by the dead man");
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
                    //DESK
                    if ((x == 1 && y == -1 && z == 2) && secondTimeEliseOffice)
                    {
                        Console.WriteLine("The most professional desk you've ever seen. Everything seems to be organized using the golden ratio.");
                        empty = false;
                    }
                    if (location.Contains("documents"))
                    {
                        //Generic Description
                        int randomNumber = rand.Next(4);
                        if (randomNumber == 0) Console.WriteLine("There are some documents nearby");
                        else if (randomNumber == 1) Console.WriteLine("There are some documents on the floor here");
                        else if (randomNumber == 2) Console.WriteLine("There are some documents on the ground here");
                        else if (randomNumber == 3) Console.WriteLine("You can see some documents here");
                    }
                    if (location.Contains("cv"))
                    {
                        //Generic Description
                        int randomNumber = rand.Next(4);
                        if (randomNumber == 0) Console.WriteLine("There is a glowing cv nearby");
                        else if (randomNumber == 1) Console.WriteLine("There is a glowing cv on the floor here");
                        else if (randomNumber == 2) Console.WriteLine("There is a glowing cv on the ground here");
                        else if (randomNumber == 3) Console.WriteLine("You can see a glowing cv here");
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
                    //COMPUTER
                    if ((x == 1 && y == -1 && z == 1) && secondTimeEliseOffice)
                    {
                        Console.WriteLine("There is a turned on computer here");
                        empty = false;
                    }
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
                ///////////////////////////////////////////
                case "inspect":
                    Console.WriteLine("inspect what?");
                    anythingElseCondition = false;
                    break;
                case "examine":
                    Console.WriteLine("examine what?");
                    anythingElseCondition = false;
                    break;
                ///////////////////////////////
                case "charge":
                    Console.WriteLine("charge what");
                    anythingElseCondition = false;
                    break;
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
                case "password":
                    Console.WriteLine("Yes, you gotta find the password...");
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
                    //Searches second word in the items of the current location or in the inventory, if true, it tells the player a description of it, or answerSplit == corpse, answerSplit == desk
                    if (location.Contains(answerSplit[1]) || inventory.Contains(answerSplit[1]) || answerSplit[1] == "corpse" || answerSplit[1] == "body" || answerSplit[1] == "desk" || answerSplit[1] == "computer") 
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
                            case "corpse":
                            case "body":
                                if ((x == 1 && y == -1 && z == 2) && firstTimeEliseOffice)
                                {
                                    Console.WriteLine("The dead body of someone who you probably knew. Some keys can be seen out of one of his pockets");
                                    location1n12[9] = "keys"; // Puts keys in the location
                                }
                                else AnythingElse(); // Displays what, Nani, etc...
                                break;
                            case "desk":
                                if ((x == 1 && y == -1 && z == 2) && secondTimeEliseOffice)
                                {
                                    Console.WriteLine("You see some documents and a really impressive CV that stands out from the rest, it even shines.");

                                    location1n12[8] = "documents"; // Puts documents in the location
                                    location1n12[9] = "cv"; // Puts CV in the location
                                }
                                else AnythingElse(); // Displays what, Nani, etc...
                                break;
                            case "documents":
                                passwordCheck = true;
                                Console.WriteLine("As you examine the documents you see a list of names with their respective marks for the Professional Practice paper. As you read through it, you can spot only four people with perfect marks:");
                                Console.WriteLine("Name".PadRight(10)+"Mark".PadLeft(10));
                                Console.WriteLine("Bill".PadRight(10)+"Exemplary".PadLeft(10));
                                Console.WriteLine("Francisco".PadRight(10)+"Exemplary".PadLeft(10));
                                Console.WriteLine("Mitchell".PadRight(10)+"Exemplary".PadLeft(10));
                                Console.WriteLine("Nabeel".PadRight(10) + "Exemplary".PadLeft(10));
                                Console.WriteLine("\nEventually, you find a sheet with the credentials of all the BIT students:");
                                Console.WriteLine("Username:".PadRight(10) + "YourAverageBitStudent".PadLeft(20));
                                Console.WriteLine("Password:".PadRight(10) + "qwerty".PadLeft(20));
                                break;
                            case "cv":
                            case "curriculum vitae":
                            case "curriculum":
                            case "resume":
                                Console.WriteLine("When you take a closer look at the CV, you sense a truly professional and powerful aura from the shiny object.");
                                Console.WriteLine("After a while, you wonder that perhaps the class you belonged to wanted to SEE what HER ACTUAL CV looks like.");
                                break;
                            case "computer":
                            case "pc":
                                Console.WriteLine("Your average BIT computer, which uses a single monitor unfortunately, eager for your password to log you on.");
                                Console.WriteLine("It is powered by a UPS, probably you could charge your phone here");
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
        public static void UseItem(string answer)  //USE + ITEMS
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
                            case "phone":
                            case "bottle":
                            case "photo":
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
            }
        }    //Makes use of the items as long as they are in the inventory
        public static void SpecialInputs(string answer) //SPECIAL INPUTS////////
        {
            //CHARGE PHONE
            if (answer == "charge phone")
            {
                if ((x == 1 && y == -1 && z == 1) && inventory.Contains("phone") && inventory.Contains("charger"))
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
            if (answer == "turn on phone" || answer == "turn phone on" || answer == "power on phone" || answer == "power phone on" || answer == "turn phone")
            {
                if (phoneCharged && inventory.Contains("phone") && firstTimeMCTurnsPhoneOn)
                {
                    firstTimeMCTurnsPhoneOn = false;
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
            //UNLOCK DOOR
            if (answer == "unlock door" || answer == "open door")
            {
                if ((x == 1 && y == 0 && z == 1) && inventory.Contains("keys")) // STAIRS SECOND FLOOR PLUS KEYS IN INVENTORY
                {
                    Console.WriteLine("You have opened the door.");
                    unlockedDoor = true;
                }
                else if ((x == 1 && y == 0 && z == 1) && !inventory.Contains("keys")) // STAIRS SECOND FLOOR PLUS KEYS IN INVENTORY
                {
                    Console.WriteLine("You need the keys first");
                }
                else Console.WriteLine("What door?");
                anythingElseCondition = false;
            }
            //qwerty
            if (answer == "qwerty")
            {
                if ((x == 1 && y == -1 && z == 1) && passwordCheck)
                {
                    Console.WriteLine("You bring up the browser, and there is no internet connection. However, on the open tab there is a live youtube broadcast buffered on the memory");
                    Console.WriteLine("You wind back and watch the video from the beginning. It says: “Emergency... all the population in the Otago Region has to evacuate the area by going to the nearest safe zones immediately, an outbreak of...” the video stops playing.");
                    knowingWhatIsGoingOn = true;
                }
                else Console.WriteLine("You need a working computer to enter your password");
                anythingElseCondition = false;
            }
        }
        public static void ZombieAttack()
        {
            zombieLoop = true;
            zombieBoolean = false;

            int randomNumber = rand.Next(2);

            if (randomNumber == 0)
            {
                while (zombieLoop)
                {
                    Console.WriteLine("\nA wild zombie appears on the scene, ready to feast on your brain!");
                    Console.WriteLine("In a moment of panic, you desperately search inside your inventory for any 'item' to use as a weapon.");
                    Console.WriteLine("Although, perhaps running away would be a wiser choice..., up to you.");
                    Console.Write("\n>");
                    string answer = Console.ReadLine();
                    answer = answer.ToLower();
                    DisplayInventory(answer);

                    switch (answer)
                    {
                        case "keys":
                            if (inventory.Contains("keys"))
                            {
                                Console.WriteLine("You have no idea how to use the keys as a weapon. Hence, you throw them at the zombie.");
                                Console.WriteLine("Unfortunately you don't hit your target. However, the zombie picks up the keys and thanks you.");
                                Console.WriteLine("The zombie is your average-zombified-OP staff member and tells you how bad it needed to go to the toilet.");
                                Console.WriteLine("Seems like this time it was a friendly one.");
                                for (int i = 0; i < inventory.Length; i++)
                                {
                                    if (inventory[i] == "keys")
                                    {
                                        inventory[i] = "";
                                    }
                                }
                                zombieLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("you don't have this item");
                            }
                            break;
                        case "cv":
                        case "curriculum vitae":
                        case "curriculum":
                        case "resume":
                            if (inventory.Contains("cv"))
                            {
                                Console.WriteLine("You take out Elise's CV and you immediatly acquire serious levels of professionalism to get hired by any company.");
                                Console.WriteLine("When the zombie notices that, it gets intimidated by your godlike presence and runs away.");
                                zombieLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("you don't have this item");
                            }
                            break;
                        case "documents":
                            if (inventory.Contains("documents"))
                            {
                                Console.WriteLine("You take out the documents and show them to the zombie.");
                                Console.WriteLine("This tactic makes no sense at all, and as a result, the zombie takes this chance to knock you down.");
                                Console.WriteLine("When you fall, you hit your head with the floor and pass out.");
                                Console.WriteLine("Seems like the zombie just had a lucky day.");
                                zombieLoop = false;
                                zombieBoolean = true;
                                Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\tYOU DIED. GAME OVER");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("you don't have this item");
                            }
                            break;
                        case "phone":
                            if (inventory.Contains("phone"))
                            {
                                Console.WriteLine("You yolo-throw your phone at the zombie, and out of sheer luck you hit it in the head.");
                                Console.WriteLine("Immediately after the impact, it explodes blowing up the zombie's head.");
                                Console.WriteLine("After this, you thank SAMSUNG for making deadly phones.");
                                for (int i = 0; i < inventory.Length; i++)
                                {
                                    if (inventory[i] == "phone")
                                    {
                                        inventory[i] = "phone(ruined)";
                                    }
                                }
                                zombieLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("you don't have this item");
                            }
                            break;
                        case "charger":
                            if (inventory.Contains("charger"))
                            {
                                Console.WriteLine("You take out the charger and...Placeholder");
                                zombieLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("you don't have this item");
                            }
                            break;
                        case "photo":
                            if (inventory.Contains("photo"))
                            {
                                Console.WriteLine("You take out the photo and the only thing you come up with is praying for salvation.");
                                Console.WriteLine("Right when you are about to get killed, a man with two machine guns (one in each hand) appears and obliterates the zombie.");
                                Console.WriteLine("When he takes off his badass-looking sunglasses, his face rings a bell. After this, you thank him for his immeasurable support");
                                zombieLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("you don't have this item");
                            }
                            break;
                        case "flee":
                        case "escape":
                        case "run":
                        case "run away":
                            randomNumber = rand.Next(3);
                            if (randomNumber == 0)
                            {
                                Console.WriteLine("You decide to escape and you successfully do!");
                                Console.WriteLine("After a while, you come back again and the zombie is gone.");
                                zombieLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("You decide to escape but you trip over, the zombie takes this chance and gets you.");
                                Console.WriteLine("You try to fight back but the zombie is way too op.");
                                Console.WriteLine("After this, you hope that the creators get these zombies nerfed for the next patch.");
                                zombieLoop = false;
                                zombieBoolean = true;
                                Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\tYOU DIED. GAME OVER");
                                Console.ReadLine();
                            }
                            break;
                        default:
                            Console.WriteLine("Please enter a valid input.");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
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
        public static void Help(string answer)
        {

            switch (answer)
            {
                case "help":
                case "info":
                    Console.WriteLine("To move you can use 'North', 'South', 'East', 'West', 'Up', and 'Down'.");
                    Console.WriteLine("You can also use abreviated terms like 'n' for North and 'd' for Down.");
                    Console.WriteLine("To see what's in the world around you type 'look' or 'l'.");
                    Console.WriteLine("To access your current items, use 'inventory' or 'i'.");
                    Console.WriteLine("If you find something perhaps you want to 'inspect' or 'examine' it.");
                    Console.WriteLine("You can use 'save' to save your progress, and you can use 'exit' to close the game.");
                    Console.WriteLine("Finally you can use words like 'get' and 'grab' to pick up any items you come accross.");
                    Console.WriteLine("Bear in mind that these are jsut a few commands, feel free to experiment.");
                    anythingElseCondition = false;
                    break;
            }

        }
        public static void AnythingElse()
        {
            int randomNumber = rand.Next(7);
            if (randomNumber == 0) Console.WriteLine("What?");
            else if (randomNumber == 1) Console.WriteLine("Pardon?");
            else if (randomNumber == 2) Console.WriteLine("Nani?");
            else if (randomNumber == 3) Console.WriteLine("I don't understand that");
            else if (randomNumber == 4) Console.WriteLine("I don't know that expression");
            else if (randomNumber == 5) Console.WriteLine("What do you mean?");
            else if (randomNumber == 6) Console.WriteLine("What are you talking about?");
        }
        public static void CollectionOfMethods(string answer, string[] location)
        {
            answer = answer.ToLower(); // This instruction is important, it converts the input into lower case so that the rest of the methods can work with only lowercase inputs
            //Methods
            DisplayCoordinates(answer);
            ExitGame(answer);
            Help(answer);
            Navigation(answer);
            LookingAround(answer, location);
            ItemDetails(answer, location);
            InspectItem(answer, location);
            UseItem(answer);
            GetDrop(answer, location);
            DisplayInventory(answer);
            SpecialInputs(answer);
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
			if (inputFromMenu == 3) Credits();              //Instructions
			if (inputFromMenu == 4) ExitGame();                  //Exit Game

			//READING RED ZONES
			StreamReader sr = new StreamReader("RedZones.txt");
            string RedZoneCoordinates = sr.ReadToEnd();
            sr.Close();

			//INSTRUCTIONS
			//Console.WriteLine("SEVERAL LINES WITH INSTRUCTIONS IN THIS PART");
			Console.WriteLine("\n\t\t\tYou are to navigate your way through");
			Console.WriteLine("\t\t\tthe zombie apocalypse. To do so you must");
			Console.WriteLine("\t\t\tsearch for items that are spread out around ");
			Console.WriteLine("\t\t\t(Dunedin or world). Basic commands are");
			Console.WriteLine("\t\t\tN,E,S & W, your job is to figure out the rest.");
			Console.WriteLine("\t\t\tGood Luck");

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
                        Console.WriteLine("You wake up in the middle of D201, looking bewildered and unable to remember anything at all. Outside, a cold and dark night lies upon Dunedin.");
                        Console.WriteLine("After a while, you make up your mind and decide to find out what is going on and more importantly, who you are...");
                        introduction = false;
                    }
                    else Console.WriteLine("You are in D201, the classroom you once loved.");
                    CommandAnalysis(location001);
                } //LOCATION 001 D201
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 0 && z == 1) //LOCATION 101 STAIRS SECOND FLOOR
                {
                    ZombieAttack();  // ZOMBIE METHOD
                    if (zombieBoolean) break; // This conditional terminates the current loop and exits the game

                    SavingCoordinates();
                    Console.WriteLine("You spot a weak light coming out of one the rooms.");
                    Console.WriteLine("You are in the second floor.");
                    Console.WriteLine("You can see the building stairs from here.");
                    CommandAnalysis(location101);
                }//LOCATION 101 STAIRS SECOND FLOOR
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == -1 && z == 1) //LOCATION 1n11 COMMON ROOM
                {
                    if (secondTimeEliseOffice) //This if fixes a bug
                    {
                        SavingCoordinates();
                        Console.WriteLine("The light was coming from one of the computers which seems to be still turned on thanks to a UPS. Apparently it is the only source of energy available in this building. You try to access the computer but it asks for a password");
                        CommandAnalysis(location1n11);
                    }
                    if (savingX == 1 && savingY == -1 && savingZ == 2) //COMING FROM ELISE'S OFFICE
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You can't go this way\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        LoadSavedCoordinates();
                    }
                    if (savingX == 1 && savingY == 0 && savingZ == 1) //COMING FROM STAIRS SECOND FLOOR
                    {
                        if (unlockedDoor)
                        {
                            secondTimeEliseOffice = true;
                            SavingCoordinates();
                            Console.WriteLine("The light was coming from one of the computers which seems to be still turned on thanks to a UPS. Apparently it is the only source of energy available in this building. You try to access the computer but it asks for a password");
                            CommandAnalysis(location1n11);
                        }
                        else
                        {
                            Console.WriteLine("You see the light through the door glass. Nevertheless, the door is locked.");
                            LoadSavedCoordinates();
                        }
                    }
                }//LOCATION 1n11 COMMON ROOM
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 1 && z == 1) //LOCATION 111 ROB
                {
                    if (savingX == 1 && savingY == 1 && savingZ == 0) //The location you are comming from
                    {
                        Console.WriteLine("You can't go this way\n");
                        LoadSavedCoordinates();
                    }
                    else
                    {
                        SavingCoordinates();
                        Console.WriteLine("It says ROB's office, you wonder if you can find anything useful here.");
                        CommandAnalysis(location111);
                    }
                }//LOCATION 111 ROB
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 0 && z == 2) //LOCATION 102 THIRD FLOOR
                {
                    if (secondTimeEliseOffice)
                    {
                        SavingCoordinates();
                        Console.WriteLine("You see the phrase “Tech News” written with blood on one of the walls here, you swear it wasn’t there before.");
                        Console.WriteLine("You are on the third floor.");
                        Console.WriteLine("You can see the building stairs from here.");
                        CommandAnalysis(location102);
                    }
                    else if (firstTimeEliseOffice)
                    {
                        SavingCoordinates();
                        Console.WriteLine("As you wander around, you start perceiving a really strong and strange smell in this area.");
                        Console.WriteLine("You are on the third floor.");
                        Console.WriteLine("You can see the building stairs from here.");
                        CommandAnalysis(location102);
                    }
                    else
                    {
                        SavingCoordinates();
                        Console.WriteLine("Strange noises somewhere start giving you the goosebumps.");
                        Console.WriteLine("You are on the third floor.");
                        Console.WriteLine("You can see the building stairs from here.");
                        CommandAnalysis(location102);
                    }
                }//LOCATION 102 THIRD FLOOR
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == -1 && z == 2) //LOCATION 1n12 ELISE's OFFICE
                {
                    if (savingX == 1 && savingY == -1 && savingZ == 1) //COMING FROM THE COMMON ROOM
                    {
                        Console.WriteLine("You can't go this way\n");
                        LoadSavedCoordinates();
                    }
                    else if (secondTimeEliseOffice)
                    {
                        firstTimeEliseOffice = false;
                        SavingCoordinates();
                        Console.WriteLine("You enter Elise’s office and her professionally arranged desk catches your eyes once again. At the same time, something unconsciously bothers you, you realize that the smell is gone, and then you try to have a look at the corpse so that your paranoia doesn’t get the best of you. Lo and behold, all you see is just a puddle of blood instead. Right after this, you start laughing kinda like the Joaquin Phoenix when you realize that “the shit has hit the fan”.");
                        CommandAnalysis(location1n12);
                    }
                    else if (firstTimeEliseOffice)
                    {
                        SavingCoordinates();
                        Console.WriteLine("As you step into Elise's office, the smell gets even stronger. On the other hand, her really well-organized desk draws your attention and makes you think that with such a setting you could always find any kind of information easier than any sort algorithm. Suddenly, you turn your head to your left and see a corpse lying on the floor. Terrified by the scene, you fall over to the floor and remain petrified for a while. Then you realize the dead man had some fancy glasses which makes you regain your sanity.");
                        CommandAnalysis(location1n12);
                    }
                    else
                    {
                        SavingCoordinates();
                        Console.WriteLine("You see Elise’s well-organized desk and gives you consolation.");
                        CommandAnalysis(location1n12);
                    }

                }//LOCATION 1n12 ELISE's OFFICE
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 0 && z == 0) //LOCATION 100 FIRST FLOOR
                {
                    if (!serverRoomLoop)
                    {
                        SavingCoordinates();
                        Console.WriteLine("Someone is passing by looking quite... “chillaxed”.");
                        Console.WriteLine("You approach him and ask him for help. He interrupts you and tells you that he has been working on a super exciting AI project for almost a week non-stop, and now that the servers are down for some uncommon and strange reason, he is gonna take a break.");
                        Console.WriteLine("You try to tell him if he knows what is going on, but he walks away saying that he cannot wait to tell everyone what he’s been up to by tomorrow morning.");
                        CommandAnalysis(location100);
                    }
                    else
                    {
                        SavingCoordinates();
                        Console.WriteLine("You are in the first floor.");
                        Console.WriteLine("You can see the building stairs from here. ");
                        Console.WriteLine("You notice that both the southern and northern exits are open.");
                        CommandAnalysis(location100);
                    }
                }//LOCATION 100 FIRST FLOOR
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 1 && z == 0) //LOCATION 110 OUTSIDE OF D BLOCK
                {
                    if (savingX == 1 && savingY == 1 && savingZ == 1) //The location you are comming from
                    {
                        Console.WriteLine("You can't go this way\n");
                        LoadSavedCoordinates();
                    }
                    else
                    {
                        if (messageSeen && knowingWhatIsGoingOn)
                        {
                            SavingCoordinates();
                            Console.WriteLine("You are outside the D block, the hostile atmosphere chills your blood.");
                            CommandAnalysis(location110);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You cannot leave the building yet.You need to find out about yourself and where to go.\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            LoadSavedCoordinates();
                        }
                    }
                }//LOCATION 110 OUTSIDE OF D BLOCK NORTH
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 2 && z == 0) //LOCATION 120
                {
                    SavingCoordinates();
                    Console.WriteLine("You are in location 120");
                    CommandAnalysis(location100);
                }//LOCATION 120
                 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == -1 && z == 0) //LOCATION 1n10 OUTSIDE OF D BLOCK SOUTH
                {
                    if (savingX == 1 && savingY == -1 && savingZ == 1) //The location you are comming from
                    {
                        Console.WriteLine("You can't go this way\n");
                        LoadSavedCoordinates();
                    }
                    else
                    {
                        if (messageSeen && knowingWhatIsGoingOn)
                        {
                            SavingCoordinates();
                            Console.WriteLine("You're south of the D Block. \nYou are not safe anymore");
                            CommandAnalysis(location1n10);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You cannot leave the building yet.\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            LoadSavedCoordinates();

                        }
                    }
                }//LOCATION 1n10
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 2 && y == 0 && z == 2) //LOCATION 202 SERVER ROOM
                {
                    if (!serverRoomLoop)
                    {
                        Console.WriteLine("You can't go this way, the room is totally destroyed.\n");
                        LoadSavedCoordinates();
                    }
                    while (serverRoomLoop)
                    {
                        Console.WriteLine("You enter the server room and immediately notice that everything is working somehow. Unfortunately due to your amnesia, you have a hard time recalling your BIT learnings. Thus, while trying to bring electricity back to the building, you end up mixing up the servers with generators and setting everything on fire.");
                        Console.WriteLine("You have two options: using an extinguisher or trying to get out as fast as you can.");
                        Console.Write("\n>");
                        string answer = Console.ReadLine();
                        answer = answer.ToLower();

                        //USE EXTINGUISHER
                        if (answer == "extinguisher" || answer == "use extinguisher" || answer == "extinguish")
                        {
                            serverRoomLoop = false;
                            Console.WriteLine("Miraculously, you remember one answer from your NetAcademy-chapter-exam questions and you take the extinguisher, so you “aim at the base of the flame, squeeze the lever, and sweep from side to side”.");
                            Console.WriteLine("This sophisticated technique allows you to get rid of the fire and save your ass as a result.\n");
                        }
                        else if (answer == "run" || answer == "get out" || answer == "run out" || answer == "escape")
                        {
                            Console.WriteLine("You decide to run out of the server room but the smoke obstructs your vision and you crash into the door that you forgot you had closed before. This knocks you out and you die burnt inside the server room.");
                            serverRoomLoop = false;
                            firstWhileCondition = false;
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t\tYOU DIED. GAME OVER");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid decision.");
                        }
                    }
                    x = 1; y = 0; z = 2; //STAIRS THIRD FLOOR
                }//LOCATION 202 SERVER ROOM
				else if (x == 1 && y == -2 && z == 0) // 1N20 HARBOUR TERRACE
				{
					SavingCoordinates();
					Console.WriteLine("Be carefull you are now on the Harbour Terrace St");
					CommandAnalysis(location1n20);
				}//LOCATION 1n20/////////////////////////////////////////////////////////////////////////////////////////////////
				 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				 ///
				else if (x == 1 && y == -2 && z == 0) // 2N20 HARBOUR TERRACE
				{
					SavingCoordinates();
					Console.WriteLine("You are now on the Harbour Terrace St");
					CommandAnalysis(location2n20);
				}//LOCATION 2n20/////////////////////////////////////////////////////////////////////////////////////////////////
				 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				 ///

				else if (x == 1 && y == -3 && z == 0) // 1N30 HARBOUR TERRACE 
				{
					SavingCoordinates();
					Console.WriteLine("You are approuching Manaaki's car park");
					CommandAnalysis(location1n30);
				}//LOCATION 1n30/////////////////////////////////////////////////////////////////////////////////////////////////
				 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				 ///
				else if (x == 1 && y == -4 && z == 0) // 1N40 HARBOUR TERRACE 
				{
					SavingCoordinates();
					Console.WriteLine("You are in a dark alley that leads you to an abandoned");
					CommandAnalysis(location1n40);
				}//LOCATION 1n40/////////////////////////////////////////////////////////////////////////////////////////////////
				 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
				 ///
				//RED ZONES
				else if (RedZoneCoordinates.Contains($"{x},{y},{z}")) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("You can't go this way\n"); LoadSavedCoordinates(); Console.ForegroundColor = ConsoleColor.Gray; }
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
		public static void Credits()
		{
			Console.Clear();
			Console.WriteLine("\n\t\t\t  \n");
			Console.WriteLine("\t\t\t  \n");
			Console.WriteLine("\t\t\t  \n");
			Console.WriteLine("\t\t\t  \n");
			Console.WriteLine("\t\t\t  \n");
			Thread.Sleep(5000);
			Console.Clear();
			Main();
		}
		public static void ExitGame()
		{
			Console.Clear();
			Console.WriteLine("\t\t\tThank you for playing");
			Thread.Sleep(2500);
			Environment.Exit(-1);
		}
		static void Main()
        {
			Console.SetWindowSize(160, 40);
			Console.WriteLine("");
			Console.WriteLine("\t\t\t\t\t\t\t1 New Game \n");
			Console.WriteLine("\t\t\t\t\t\t\t2 Resume \n");
			Console.WriteLine("\t\t\t\t\t\t\t3 Credits \n");
			Console.WriteLine("\t\t\t\t\t\t\t4 Exit \n");
			Console.Write("\t\t\t\t\t\t       :");
			MainGAME(Convert.ToInt32(Console.ReadLine()));
		}
    }
}
