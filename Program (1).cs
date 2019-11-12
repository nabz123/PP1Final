using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beginning
{
    public struct Name
    {
        public int[] numbers;
        public string names;
    }
    class Program
    {
        public static int x = 0, y = 0, z = 0; //coordinates
        public static string[] inventory = new string[7];
        public static bool first = true, navigationCheck = false, inventoryCheck = false;
        public static void Navigation(string answer)
        {
            answer = answer.ToLower();
            switch (answer)
            {
                case "n":
                case "north":
                    y++;
                    navigationCheck = true;
                    break;
                case "w":
                case "west":
                    x--;
                    navigationCheck = true;
                    break;
                case "e":
                case "east":
                    x++;
                    navigationCheck = true;
                    break;
                case "s":
                case "south":
                    y--;
                    navigationCheck = true;
                    break;
                case "up":
                case "u":
                    z++;
                    navigationCheck = true;
                    break;
                case "down":
                case "d":
                    z--;
                    navigationCheck = true;
                    break;
            }
        }
        public static void WAT(string answer)
        {
            switch (answer)
            {
                ///////////////////////////////////////
                case "get":
                    Console.WriteLine("get what?");
                    break;
                case "take":
                    Console.WriteLine("take what?");
                    break;
                case "grab":
                    Console.WriteLine("grab what?");
                    break;
                ////////////////////////////////////////
                case "drop":
                    Console.WriteLine("drop what?");
                    break;
                case "discard":
                    Console.WriteLine("discard what?");
                    break;
                ////////////////////////////////////////
                /*default:
                    Console.WriteLine("what?");
                    break;*/
            }
        }
        public static void DisplayInventory(string answer)
        {
            answer = answer.ToLower();
            switch (answer)
            {
                case "i":
                case "inventory":
                    inventoryCheck = false;
                    //This foor-loop evaluates whether the inventory is empty or not, if it has at least one item, it activates "inventoryCheck"
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        if (inventory[i] != null) inventoryCheck = true;
                    }
                    //If "inventoryCheck" is activated, the contents are displayed
                    if (inventoryCheck)
                    {
                        Console.WriteLine("You currently have the following items:\n");
                        for (int i = 0; i < inventory.Length; i++)
                        {
                            if (inventory[i] != null)
                            {
                                Console.WriteLine(inventory[i]);
                            }
                        }
                    }
                    //If "inventoryCheck" is not activated, a message is displayed instead
                    else Console.WriteLine("You don't have any items yet.\n");
                    break;
            }
        }
        public static void AddToInventory(string item)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                {
                    inventory[i] = item;
                    break;
                }
            }
        }
        public static void RemoveFromInventory(string item)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == item)
                {
                    inventory[i] = null;
                    break;
                }
            }
        }
        static void Main()
        {
            //Console.WriteLine($"These are the current coordinates: ({x},{y},{z})\n");
            Console.WriteLine("You wake up in the middle of D201 and don’t remember anything at all. The lights seem");
            Console.WriteLine("to be off for some reason. Outside, a cold and dark evening lays above Dunedin.\n");

            z = 1;
            while (true) //Main While-Loop
            {
                navigationCheck = false; //Resets the navigation check
                if (x == 0 && y == 0 && z == 1)
                {
                    if (first) { Console.WriteLine("You are in D201 looking bewildered."); first = false; }
                    else Console.WriteLine("You are in the D201 classroom you once loved.");

                    while (true)
                    {
                        Console.Write("\n>");
                        string answer = Console.ReadLine();
                        Navigation(answer);
                        if (navigationCheck) break; //If this is true, it exits the loop
                        DisplayInventory(answer);
                        WAT(answer);

                        //Interaction Switch which is unique for every scenario
                        switch (answer)
                        {
                            case "l":
                            case "look":
                                if (inventory.Contains("keys")) ;
                                else Console.WriteLine("There is a desk with some keys on it here");
                                //
                                if (inventory.Contains("phone")) ;
                                else Console.WriteLine("There is a phone on the floor here");
                                break;
                                //KEYS
                            case "get keys":
                            case "take keys":
                            case "grab keys":
                                if (inventory.Contains("keys")) Console.WriteLine("You already have this item");
                                else
                                {
                                    Console.WriteLine("Understood");
                                    AddToInventory("keys");
                                }
                                break;
                            case "drop keys":
                            case "discard keys":
                                if (inventory.Contains("keys"))
                                {
                                    Console.WriteLine("Understood");
                                    RemoveFromInventory("keys");
                                }
                                else Console.WriteLine("You don't have this item...");
                                break;
                                //PHONE
                            case "get phone":
                            case "take phone":
                            case "grab phone":
                                if (inventory.Contains("phone")) Console.WriteLine("You already have this item");
                                else
                                {
                                    Console.WriteLine("Understood");
                                    AddToInventory("phone");
                                }
                                break;
                            case "drop phone":
                            case "discard phone":
                                if (inventory.Contains("phone"))
                                {
                                    Console.WriteLine("Understood");
                                    RemoveFromInventory("phone");
                                }
                                else Console.WriteLine("You don't have this item...");
                                break;
                        }
                    }
                }
                else if (x == 1 && y == 0 && z == 1)
                {
                    Console.WriteLine("You are outside D201.");
                    Console.Write("\n>");
                    string answer = Console.ReadLine();
                    Navigation(answer);
                }
                else if (x == 1 && y == -1 && z == 1)
                {
                    Console.WriteLine("You are in the common room.");
                    Console.Write("\n>");
                    string answer = Console.ReadLine();
                    Navigation(answer);
                }
                else if (x == 1 && y == 0 && z == 0)
                {
                    Console.WriteLine("You are in the first floor.");
                    Console.Write("\n>");
                    string answer = Console.ReadLine();
                    Navigation(answer);
                }
                else if (x == 0 && y == 1 && z == 1) { Console.WriteLine("You can't go this way\n"); y--; }
                else if (x == -1 && y == 0 && z == 1) { Console.WriteLine("You can't go this way\n"); x++; }
                else if (x == 0 && y == -1 && z == 1) { Console.WriteLine("You can't go this way\n"); y++; }


            }
            Console.ReadLine();
        }
    }
}
