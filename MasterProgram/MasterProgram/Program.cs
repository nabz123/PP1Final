using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace MasterProgram
{
    class Program
    {
        public static Random rand = new Random();

        //VARIABLE DECLARATION
        public static bool firstWhileCondition = true, secondWhileCondition = true, thirdWhileCondition = true, anythingElseCondition = true, zombieLoop = true, zombieBoolean = false, menuLoop = true;
        public static bool inventoryCheck = false; //Auxiliar boolean to check whether the inventory is empty or not
        public static string separator; //Helps to orginize the text files
        public static bool nameLoop = true;

        public static int food_level_current = 15; //FOOD COUNTER
        public static int zombie_level_current = 15; //ZOMBIFICATION COUNTER

        //COORDINATES
        public static int x = 0, y = 0, z = 0; 
        public static int savingX = 0, savingY = 0, savingZ = 0;  //SAVED COORDINATES

        //INVENTORY
        public static string[] inventory = new string[10];

        // LOCATION ARRAYS CREATION
        //D BLOCK
        public static string[] location001 = new string[10]; //D201
        public static string[] location101 = new string[10]; //STAIRS SECOND FLOOR
        public static string[] location1n11 = new string[10];//COMMON ROOM
        public static string[] location111 = new string[10]; //ROB
        public static string[] location102 = new string[10]; //THIRD FLOOR
        public static string[] location1n12 = new string[10];//ELISES's OFFICE
        public static string[] location100 = new string[10]; //FIRST FLOOR
        public static string[] location110 = new string[10];   //OUTSIDE OF D BLOCK NORTH
        public static string[] location120 = new string[10]; //HUB
        public static string[] location1n10 = new string[10]; //OUTSIDE OF D BLOCK SOUTH
        public static string[] location202 = new string[10];  //SERVER ROOM

        //AROUND MAANAKI
        public static string[] location0n20 = new string[10]; //HARBOUR TERRACE STREET
        public static string[] location1n20 = new string[10];  //HARBOUR TERRACE STREET
        public static string[] location2n20 = new string[10]; //HARBOUR TERRACE STREET
        public static string[] location1n30 = new string[10]; //APPROACHING MAANAKI's CAR PARK
        public static string[] location1n40 = new string[10];  // DARK ALLEY
        public static string[] location2n40 = new string[10];  //MAANAKI ENTRANCE
                                                               //MAANAKI SECOND FLOOR
        public static string[] location2n41 = new string[10]; //MAANAKI SECOND FLOOR
        public static string[] location3n41 = new string[10]; //BECOMING LOUDER
        public static string[] location4n41 = new string[10]; //MYSTERIOUS SOUNDS
        public static string[] location2n51 = new string[10]; //GETTING WARMER
        public static string[] location3n51 = new string[10]; //PUDDLE OF WATER
        public static string[] location4n51 = new string[10]; //MAANAKI SECOND FLOOR
        public static string[] location2n61 = new string[10]; //COUNTER
        public static string[] location3n61 = new string[10]; //COUNTER
        public static string[] location4n61 = new string[10]; //V DRINK

        //LIBRARY
        public static string[] locationn210 = new string[10]; //LIBRARY ENTRANCE
        public static string[] locationn211 = new string[10]; //LIBRARY SECOND FLOOR
        public static string[] locationn311 = new string[10]; //LIBRARY SECOND FLOOR
        public static string[] locationn201 = new string[10]; //LIBRARY SECOND FLOOR
        public static string[] locationn301 = new string[10]; //LIBRARY SECOND FLOOR
        public static string[] locationn321 = new string[10]; //LIBRARY SECOND FLOOR STAIRS
        public static string[] locationn322 = new string[10]; //LIBRARY THIRD FLOOR
        public static string[] locationn332 = new string[10]; //KEYCARD

        //STREETS
        public static string[] location130 = new string[10];  //FORTH STREET
        public static string[] location030 = new string[10];  //FORTH STREET

        public static string[] locationn130 = new string[10]; //UNION STREET
        public static string[] locationn120 = new string[10]; //UNION STREET
        public static string[] locationn110 = new string[10]; //UNION STREET
        public static string[] locationn100 = new string[10]; //UNION STREET
        public static string[] locationn1n10 = new string[10]; //UNION STREET
        public static string[] locationn1n20 = new string[10]; //UNION STREET

        //UNIVERSITY
        public static string[] locationn140 = new string[10]; //UNIVERSITY GATE
        public static string[] locationn150 = new string[10]; //UNIVERSITY CAMPUS

        //LOCATION BOOLEANS
        public static string name; //Player's name
        public static bool closeGate = false;
        public static bool savedYourself = false;
        public static bool savedPaul = false;
        public static bool openGate = false;
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

        public static bool foodCurrent = false;
        public static bool zombificationCurrent = false;
        public static bool firstTimeGoingOutDBlock = true;
        public static bool rescuePaul = false;
        public static bool gateLoop = true;
        public static bool beforeUniCampus = true;
        public static bool rightAfterUniCampus = false;
        public static bool davidFirstFloor = false;
        public static bool paulRaid = false;
        public static bool d201Decision = false;
        public static bool d201Loop = true;
        public static bool getPaul = false;
        public static bool lockedPaul = false;
        public static bool afterSavingPaul = true;
        public static bool unlockedGate = false;
        public static bool firstTimeKeys = true;
        public static bool firstTimeDocsNcv = true;
        public static bool davidSeen = false;


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
            //D BLOCK
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
            //AROUND MAANAKI
            separator = sr.ReadLine();//ITEMS LOCATION 0n20
            for (int i = 0; i < location0n20.Length; i++)
            {
                location0n20[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 1n20
            for (int i = 0; i < location1n20.Length; i++)
            {
                location1n20[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 2n20
            for (int i = 0; i < location2n20.Length; i++)
            {
                location2n20[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 1n30
            for (int i = 0; i < location1n30.Length; i++)
            {
                location1n30[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 1n40
            for (int i = 0; i < location1n40.Length; i++)
            {
                location1n40[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 2n40
            for (int i = 0; i < location2n40.Length; i++)
            {
                location2n40[i] = sr.ReadLine();
            }
            //MAANAKI SECOND FLOOR
            separator = sr.ReadLine();//ITEMS LOCATION 2n41
            for (int i = 0; i < location2n41.Length; i++)
            {
                location2n41[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 3n41
            for (int i = 0; i < location3n41.Length; i++)
            {
                location3n41[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 4n41
            for (int i = 0; i < location4n41.Length; i++)
            {
                location4n41[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 2n51
            for (int i = 0; i < location2n51.Length; i++)
            {
                location2n51[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 3n51
            for (int i = 0; i < location3n51.Length; i++)
            {
                location3n51[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 4n51
            for (int i = 0; i < location4n51.Length; i++)
            {
                location4n51[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 2n61
            for (int i = 0; i < location2n61.Length; i++)
            {
                location2n61[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 3n61
            for (int i = 0; i < location3n61.Length; i++)
            {
                location3n61[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 4n61
            for (int i = 0; i < location4n61.Length; i++)
            {
                location4n61[i] = sr.ReadLine();
            }
            //LIBRARY
            separator = sr.ReadLine();//ITEMS LOCATION n210
            for (int i = 0; i < locationn210.Length; i++)
            {
                locationn210[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n211
            for (int i = 0; i < locationn211.Length; i++)
            {
                locationn211[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n311
            for (int i = 0; i < locationn311.Length; i++)
            {
                locationn311[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n201
            for (int i = 0; i < locationn201.Length; i++)
            {
                locationn201[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n301
            for (int i = 0; i < locationn301.Length; i++)
            {
                locationn301[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n321
            for (int i = 0; i < locationn321.Length; i++)
            {
                locationn321[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n322
            for (int i = 0; i < locationn322.Length; i++)
            {
                locationn322[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n332
            for (int i = 0; i < locationn332.Length; i++)
            {
                locationn332[i] = sr.ReadLine();
            }
            //STREETS
            separator = sr.ReadLine();//ITEMS LOCATION 130
            for (int i = 0; i < location130.Length; i++)
            {
                location130[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 030
            for (int i = 0; i < location030.Length; i++)
            {
                location030[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n130
            for (int i = 0; i < locationn130.Length; i++)
            {
                locationn130[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n120
            for (int i = 0; i < locationn120.Length; i++)
            {
                locationn120[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n110
            for (int i = 0; i < locationn110.Length; i++)
            {
                locationn110[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n100
            for (int i = 0; i < locationn100.Length; i++)
            {
                locationn100[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n1n10
            for (int i = 0; i < locationn1n10.Length; i++)
            {
                locationn1n10[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n1n20
            for (int i = 0; i < locationn1n20.Length; i++)
            {
                locationn1n20[i] = sr.ReadLine();
            }
            //UNIVERSITY
            separator = sr.ReadLine();//ITEMS LOCATION n140
            for (int i = 0; i < locationn140.Length; i++)
            {
                locationn140[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n150
            for (int i = 0; i < locationn150.Length; i++)
            {
                locationn150[i] = sr.ReadLine();
            }
            sr.Close();

            //BOOLEANS
            StreamReader zr = new StreamReader("newGameBooleans.txt");

            separator = zr.ReadLine();//Food counter
            food_level_current = Convert.ToInt32(zr.ReadLine());
            separator = zr.ReadLine();//Zombie counter
            zombie_level_current = Convert.ToInt32(zr.ReadLine());
            separator = zr.ReadLine();//name
            name = zr.ReadLine();
            separator = zr.ReadLine();//closedGate
            closeGate = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//savedYourself
            savedYourself = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//savedPaul
            savedPaul = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//openGate
            openGate = Convert.ToBoolean(zr.ReadLine());
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
            separator = zr.ReadLine();//foodCurrent

            foodCurrent = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//zombificationCurrent
            zombificationCurrent = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//firstTimeGoingOutDBlock
            firstTimeGoingOutDBlock = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//rescuePaul
            rescuePaul = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//gateLoop
            gateLoop = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//beforeUniCampus
            beforeUniCampus = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//rightAfterUniCampus
            rightAfterUniCampus = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//davidFirstFloor
            davidFirstFloor = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//paulRaid
            paulRaid = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//d201Decision
            d201Decision = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//d201Loop
            d201Loop = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//getPaul
            getPaul = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//lockedPaul
            lockedPaul = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//afterSavingPaul
            afterSavingPaul = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//unlockedGate
            unlockedGate = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//firstTimeKeys
            firstTimeKeys = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//firstTimeDocsNcv
            firstTimeDocsNcv = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//davidSeen
            davidSeen = Convert.ToBoolean(zr.ReadLine());

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
            //D BLOCK
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
            //AROUND MAANAKI
            separator = sr.ReadLine();//ITEMS LOCATION 0n20
            for (int i = 0; i < location0n20.Length; i++)
            {
                location0n20[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 1n20
            for (int i = 0; i < location1n20.Length; i++)
            {
                location1n20[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 2n20
            for (int i = 0; i < location2n20.Length; i++)
            {
                location2n20[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 1n30
            for (int i = 0; i < location1n30.Length; i++)
            {
                location1n30[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 1n40
            for (int i = 0; i < location1n40.Length; i++)
            {
                location1n40[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 2n40
            for (int i = 0; i < location2n40.Length; i++)
            {
                location2n40[i] = sr.ReadLine();
            }
            //MAANAKI SECOND FLOOR
            separator = sr.ReadLine();//ITEMS LOCATION 2n41
            for (int i = 0; i < location2n41.Length; i++)
            {
                location2n41[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 3n41
            for (int i = 0; i < location3n41.Length; i++)
            {
                location3n41[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 4n41
            for (int i = 0; i < location4n41.Length; i++)
            {
                location4n41[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 2n51
            for (int i = 0; i < location2n51.Length; i++)
            {
                location2n51[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 3n51
            for (int i = 0; i < location3n51.Length; i++)
            {
                location3n51[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 4n51
            for (int i = 0; i < location4n51.Length; i++)
            {
                location4n51[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 2n61
            for (int i = 0; i < location2n61.Length; i++)
            {
                location2n61[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 3n61
            for (int i = 0; i < location3n61.Length; i++)
            {
                location3n61[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 4n61
            for (int i = 0; i < location4n61.Length; i++)
            {
                location4n61[i] = sr.ReadLine();
            }
            //LIBRARY
            separator = sr.ReadLine();//ITEMS LOCATION n210
            for (int i = 0; i < locationn210.Length; i++)
            {
                locationn210[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n211
            for (int i = 0; i < locationn211.Length; i++)
            {
                locationn211[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n311
            for (int i = 0; i < locationn311.Length; i++)
            {
                locationn311[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n201
            for (int i = 0; i < locationn201.Length; i++)
            {
                locationn201[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n301
            for (int i = 0; i < locationn301.Length; i++)
            {
                locationn301[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n321
            for (int i = 0; i < locationn321.Length; i++)
            {
                locationn321[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n322
            for (int i = 0; i < locationn322.Length; i++)
            {
                locationn322[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n332
            for (int i = 0; i < locationn332.Length; i++)
            {
                locationn332[i] = sr.ReadLine();
            }
            //STREETS
            separator = sr.ReadLine();//ITEMS LOCATION 130
            for (int i = 0; i < location130.Length; i++)
            {
                location130[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION 030
            for (int i = 0; i < location030.Length; i++)
            {
                location030[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n130
            for (int i = 0; i < locationn130.Length; i++)
            {
                locationn130[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n120
            for (int i = 0; i < locationn120.Length; i++)
            {
                locationn120[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n110
            for (int i = 0; i < locationn110.Length; i++)
            {
                locationn110[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n100
            for (int i = 0; i < locationn100.Length; i++)
            {
                locationn100[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n1n10
            for (int i = 0; i < locationn1n10.Length; i++)
            {
                locationn1n10[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n1n20
            for (int i = 0; i < locationn1n20.Length; i++)
            {
                locationn1n20[i] = sr.ReadLine();
            }
            //UNIVERSITY
            separator = sr.ReadLine();//ITEMS LOCATION n140
            for (int i = 0; i < locationn140.Length; i++)
            {
                locationn140[i] = sr.ReadLine();
            }
            separator = sr.ReadLine();//ITEMS LOCATION n150
            for (int i = 0; i < locationn150.Length; i++)
            {
                locationn150[i] = sr.ReadLine();
            }
            sr.Close();

            //BOOLEANS
            StreamReader zr = new StreamReader("saveBooleans.txt");

            separator = zr.ReadLine();//Food counter
            food_level_current = Convert.ToInt32(zr.ReadLine());
            separator = zr.ReadLine();//Zombie counter
            zombie_level_current = Convert.ToInt32(zr.ReadLine());
            separator = zr.ReadLine();//name
            name = zr.ReadLine();
            separator = zr.ReadLine();//closedGate
            closeGate = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//savedYourself
            savedYourself = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//savedPaul
            savedPaul = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//openGate
            openGate = Convert.ToBoolean(zr.ReadLine());
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
            separator = zr.ReadLine();//foodCurrent

            foodCurrent = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//zombificationCurrent
            zombificationCurrent = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//firstTimeGoingOutDBlock
            firstTimeGoingOutDBlock = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//rescuePaul
            rescuePaul = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//gateLoop
            gateLoop = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//beforeUniCampus
            beforeUniCampus = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//rightAfterUniCampus
            rightAfterUniCampus = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//davidFirstFloor
            davidFirstFloor = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//paulRaid
            paulRaid = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//d201Decision
            d201Decision = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//d201Loop
            d201Loop = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//getPaul
            getPaul = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//lockedPaul
            lockedPaul = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//afterSavingPaul
            afterSavingPaul = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//unlockedGate
            unlockedGate = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//firstTimeKeys
            firstTimeKeys = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//firstTimeDocsNcv
            firstTimeDocsNcv = Convert.ToBoolean(zr.ReadLine());
            separator = zr.ReadLine();//davidSeen
            davidSeen = Convert.ToBoolean(zr.ReadLine());

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
                sw.WriteLine("LOCATION 101 STAIRS SECOND FLOOR");
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
                sw.WriteLine("LOCATION 110 OUTSIDE OF D BLOCK NORTH");
                for (int i = 0; i < location110.Length; i++)
                {
                    sw.WriteLine(location110[i]);
                }
                sw.WriteLine("LOCATION 120 HUB");
                for (int i = 0; i < location120.Length; i++)
                {
                    sw.WriteLine(location120[i]);
                }
                sw.WriteLine("LOCATION 1n10 OUTSIDE OF D BLOCK SOUTH");
                for (int i = 0; i < location1n10.Length; i++)
                {
                    sw.WriteLine(location1n10[i]);
                }
                sw.WriteLine("LOCATION 202 SERVER ROOM");
                for (int i = 0; i < location202.Length; i++)
                {
                    sw.WriteLine(location202[i]);
                }
                sw.WriteLine("LOCATION 0n20 HARBOUR TERRACE STREET");
                for (int i = 0; i < location0n20.Length; i++)
                {
                    sw.WriteLine(location0n20[i]);
                }
                sw.WriteLine("LOCATION 1n20 HARBOUR TERRACE STREET");
                for (int i = 0; i < location1n20.Length; i++)
                {
                    sw.WriteLine(location1n20[i]);
                }
                sw.WriteLine("LOCATION 2n20 HARBOUR TERRACE STREET");
                for (int i = 0; i < location2n20.Length; i++)
                {
                    sw.WriteLine(location2n20[i]);
                }
                sw.WriteLine("LOCATION 1n30 APPROACHING MAANAKI's CAR PARK");
                for (int i = 0; i < location1n30.Length; i++)
                {
                    sw.WriteLine(location1n30[i]);
                }
                sw.WriteLine("LOCATION 1n40 DARK ALLEY");
                for (int i = 0; i < location1n40.Length; i++)
                {
                    sw.WriteLine(location1n40[i]);
                }
                sw.WriteLine("LOCATION 2n40 MAANAKI ENTRANCE");
                for (int i = 0; i < location2n40.Length; i++)
                {
                    sw.WriteLine(location2n40[i]);
                }
                sw.WriteLine("LOCATION 2n41 MAANAKI SECOND FLOOR");
                for (int i = 0; i < location2n41.Length; i++)
                {
                    sw.WriteLine(location2n41[i]);
                }
                sw.WriteLine("LOCATION 3n41 BECOMING LOUDER");
                for (int i = 0; i < location3n41.Length; i++)
                {
                    sw.WriteLine(location3n41[i]);
                }
                sw.WriteLine("LOCATION 4n41 MYSTERIOUS SOUNDS");
                for (int i = 0; i < location4n41.Length; i++)
                {
                    sw.WriteLine(location4n41[i]);
                }
                sw.WriteLine("LOCATION 2n51 GETTING WARMER");
                for (int i = 0; i < location2n51.Length; i++)
                {
                    sw.WriteLine(location2n51[i]);
                }
                sw.WriteLine("LOCATION 3n51 PUDDLE OF WATER");
                for (int i = 0; i < location3n51.Length; i++)
                {
                    sw.WriteLine(location3n51[i]);
                }
                sw.WriteLine("LOCATION 4n51 MAANAKI SECOND FLOOR");
                for (int i = 0; i < location4n51.Length; i++)
                {
                    sw.WriteLine(location4n51[i]);
                }
                sw.WriteLine("LOCATION 2n61 COUNTER");
                for (int i = 0; i < location2n61.Length; i++)
                {
                    sw.WriteLine(location2n61[i]);
                }
                sw.WriteLine("LOCATION 3n61 COUNTER");
                for (int i = 0; i < location3n61.Length; i++)
                {
                    sw.WriteLine(location3n61[i]);
                }
                sw.WriteLine("LOCATION 4n61 V DRINK");
                for (int i = 0; i < location4n61.Length; i++)
                {
                    sw.WriteLine(location4n61[i]);
                }
                sw.WriteLine("LOCATION n210 LIBRARY ENTRANCE");
                for (int i = 0; i < locationn210.Length; i++)
                {
                    sw.WriteLine(locationn210[i]);
                }
                sw.WriteLine("LOCATION n211 LIBRARY SECOND FLOOR");
                for (int i = 0; i < locationn211.Length; i++)
                {
                    sw.WriteLine(locationn211[i]);
                }
                sw.WriteLine("LOCATION n311 LIBRARY SECOND FLOOR");
                for (int i = 0; i < locationn311.Length; i++)
                {
                    sw.WriteLine(locationn311[i]);
                }
                sw.WriteLine("LOCATION n201 LIBRARY SECOND FLOOR");
                for (int i = 0; i < locationn201.Length; i++)
                {
                    sw.WriteLine(locationn201[i]);
                }
                sw.WriteLine("LOCATION n301 LIBRARY SECOND FLOOR");
                for (int i = 0; i < locationn301.Length; i++)
                {
                    sw.WriteLine(locationn301[i]);
                }
                sw.WriteLine("LOCATION n321 LIBRARY SECOND FLOOR STAIRS");
                for (int i = 0; i < locationn321.Length; i++)
                {
                    sw.WriteLine(locationn321[i]);
                }
                sw.WriteLine("LOCATION n322 LIBRARY THIRD FLOOR");
                for (int i = 0; i < locationn322.Length; i++)
                {
                    sw.WriteLine(locationn322[i]);
                }
                sw.WriteLine("LOCATION n332 KEYCARD");
                for (int i = 0; i < locationn332.Length; i++)
                {
                    sw.WriteLine(locationn332[i]);
                }
                sw.WriteLine("LOCATION 130 FORTH STREET");
                for (int i = 0; i < location130.Length; i++)
                {
                    sw.WriteLine(location130[i]);
                }
                sw.WriteLine("LOCATION 030 FORTH STREET");
                for (int i = 0; i < location030.Length; i++)
                {
                    sw.WriteLine(location030[i]);
                }
                sw.WriteLine("LOCATION n130 UNION STREET");
                for (int i = 0; i < locationn130.Length; i++)
                {
                    sw.WriteLine(locationn130[i]);
                }
                sw.WriteLine("LOCATION n120 UNION STREET");
                for (int i = 0; i < locationn120.Length; i++)
                {
                    sw.WriteLine(locationn120[i]);
                }
                sw.WriteLine("LOCATION n110 UNION STREET");
                for (int i = 0; i < locationn110.Length; i++)
                {
                    sw.WriteLine(locationn110[i]);
                }
                sw.WriteLine("LOCATION n100 UNION STREET");
                for (int i = 0; i < locationn100.Length; i++)
                {
                    sw.WriteLine(locationn100[i]);
                }
                sw.WriteLine("LOCATION n1n10 UNION STREET");
                for (int i = 0; i < locationn1n10.Length; i++)
                {
                    sw.WriteLine(locationn1n10[i]);
                }
                sw.WriteLine("LOCATION n1n20 UNION STREET");
                for (int i = 0; i < locationn1n20.Length; i++)
                {
                    sw.WriteLine(locationn1n20[i]);
                }
                sw.WriteLine("LOCATION n140 UNIVERSITY GATE");
                for (int i = 0; i < locationn140.Length; i++)
                {
                    sw.WriteLine(locationn140[i]);
                }
                sw.WriteLine("LOCATION n150 UNIVERSITY CAMPUS");
                for (int i = 0; i < locationn150.Length; i++)
                {
                    sw.WriteLine(locationn150[i]);
                }
                sw.WriteLine("Placeholder");
                sw.Close();

                //BOOLEANS
                StreamWriter zw = new StreamWriter("saveBooleans.txt");

                zw.WriteLine("foodCounter");
                zw.WriteLine(food_level_current);
                zw.WriteLine("ZombieCounter");
                zw.WriteLine(zombie_level_current);
                zw.WriteLine("name");
                zw.WriteLine(name);
                zw.WriteLine("closeGate");
                zw.WriteLine(closeGate);
                zw.WriteLine("savedYourself");
                zw.WriteLine(savedYourself);
                zw.WriteLine("savedPaul");
                zw.WriteLine(savedPaul);
                zw.WriteLine("openGate");
                zw.WriteLine(openGate);
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
                zw.WriteLine("foodCurrent");
                zw.WriteLine(foodCurrent);
                zw.WriteLine("zombificationCurrent");
                zw.WriteLine(zombificationCurrent);
                zw.WriteLine("firstTimeGoingOutDBlock");
                zw.WriteLine(firstTimeGoingOutDBlock);
                zw.WriteLine("rescuePaul");
                zw.WriteLine(rescuePaul);
                zw.WriteLine("gateLoop");
                zw.WriteLine(gateLoop);
                zw.WriteLine("beforeUniCampus");
                zw.WriteLine(beforeUniCampus);
                zw.WriteLine("rightAfterUniCampus");
                zw.WriteLine(rightAfterUniCampus);
                zw.WriteLine("davidFirstFloor");
                zw.WriteLine(davidFirstFloor);
                zw.WriteLine("paulRaid");
                zw.WriteLine(paulRaid);
                zw.WriteLine("d201Decision");
                zw.WriteLine(d201Decision);
                zw.WriteLine("d201Loop");
                zw.WriteLine(d201Loop);
                zw.WriteLine("getPaul");
                zw.WriteLine(getPaul);
                zw.WriteLine("lockedPaul");
                zw.WriteLine(lockedPaul);
                zw.WriteLine("afterSavingPaul");
                zw.WriteLine(afterSavingPaul);
                zw.WriteLine("unlockedGate");
                zw.WriteLine(unlockedGate);
                zw.WriteLine("firstTimeKeys");
                zw.WriteLine(firstTimeKeys);
                zw.WriteLine("firstTimeDocsNcv");
                zw.WriteLine(firstTimeDocsNcv);
                zw.WriteLine("davidSeen");
                zw.WriteLine(davidSeen);
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
                    foodCounter();
                    zombificationCounter();
                    anythingElseCondition = false;
                    break;
                case "w":
                case "west":
                    x--;
                    secondWhileCondition = false;
                    foodCounter();
                    zombificationCounter();
                    anythingElseCondition = false;
                    break;
                case "e":
                case "east":
                    x++;
                    secondWhileCondition = false;
                    foodCounter();
                    zombificationCounter();
                    anythingElseCondition = false;
                    break;
                case "s":
                case "south":
                    y--;
                    secondWhileCondition = false;
                    foodCounter();
                    zombificationCounter();
                    anythingElseCondition = false;
                    break;
                case "up":
                case "u":
                    if (z < 2)
                    {
                        z++;
                        secondWhileCondition = false;
                        foodCounter();
                        zombificationCounter();
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
                        foodCounter();
                        zombificationCounter();
                        anythingElseCondition = false;
                    }
                    else
                    {
                        Console.WriteLine("You can't go this way");
                        anythingElseCondition = false;
                    }
                    break;
            }
        } // Navigation triggers the food and zombie counters if they have been activated
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
                    if (location.Contains("food"))
                    {
                        //Generic Description
                        int randomNumber = rand.Next(4);
                        if (randomNumber == 0) Console.WriteLine("There is some food nearby");
                        else if (randomNumber == 1) Console.WriteLine("There is some food on the floor here");
                        else if (randomNumber == 2) Console.WriteLine("There is some food on the ground here");
                        else if (randomNumber == 3) Console.WriteLine("You can see some food here");
                    }
                    if (location.Contains("v"))
                    {
                        //Generic Description
                        int randomNumber = rand.Next(4);
                        if (randomNumber == 0) Console.WriteLine("There is a V nearby");
                        else if (randomNumber == 1) Console.WriteLine("There is a V on the floor here");
                        else if (randomNumber == 2) Console.WriteLine("There is a V on the ground here");
                        else if (randomNumber == 3) Console.WriteLine("You can see a V here");
                    }
                    if (location.Contains("sledgehammer"))
                    {
                        //Generic Description
                        int randomNumber = rand.Next(4);
                        if (randomNumber == 0) Console.WriteLine("There is a sledgehammer nearby");
                        else if (randomNumber == 1) Console.WriteLine("There is a sledgehammer on the floor here");
                        else if (randomNumber == 2) Console.WriteLine("There is a sledgehammer on the ground here");
                        else if (randomNumber == 3) Console.WriteLine("You can see a sledgehammer here");
                    }
                    if (location.Contains("keycard"))
                    {
                        //Generic Description
                        int randomNumber = rand.Next(4);
                        if (randomNumber == 0) Console.WriteLine("There is a university keycard nearby");
                        else if (randomNumber == 1) Console.WriteLine("There is a university keycard on the floor here");
                        else if (randomNumber == 2) Console.WriteLine("There is a university keycard on the ground here");
                        else if (randomNumber == 3) Console.WriteLine("You can see a university keycard here");
                    }
                    if (location.Contains("syringe"))
                    {
                        //Generic Description
                        int randomNumber = rand.Next(4);
                        if (randomNumber == 0) Console.WriteLine("There is the syringe with the cure nearby");
                        else if (randomNumber == 1) Console.WriteLine("There is the syringe with the cure on the floor here");
                        else if (randomNumber == 2) Console.WriteLine("There is the syringe with the cure on the ground here");
                        else if (randomNumber == 3) Console.WriteLine("You can see the syringe with the cure here");
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
                                    if (firstTimeKeys)
                                    {
                                        firstTimeKeys = false;
                                        Console.WriteLine("The dead body of someone who you probably knew. Some keys can be seen out of one of his pockets");
                                        location1n12[9] = "keys"; // Puts keys in the location
                                    }
                                    else if (inventory.Contains("keys"))
                                    {
                                        Console.WriteLine("The dead body of someone who you probably knew.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The dead body of someone who you probably knew. Some keys can be seen out of one of his pockets");
                                    }
                                }
                                else AnythingElse(); // Displays what, Nani, etc...
                                break;
                            case "desk":
                                if ((x == 1 && y == -1 && z == 2) && secondTimeEliseOffice)
                                {
                                    if (firstTimeDocsNcv)
                                    {
                                        firstTimeDocsNcv = false;
                                        Console.WriteLine("You see some documents and a really impressive CV that stands out from the rest, it even shines.");
                                        location1n12[8] = "documents"; // Puts documents in the location
                                        location1n12[9] = "cv"; // Puts CV in the location
                                    }
                                    else if (inventory.Contains("documents") || inventory.Contains("cv"))
                                    {
                                        Console.WriteLine("You see some things that catch your eyes, perhaps you can get them.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("You see some documents and a really impressive CV that stands out from the rest, it even shines.");
                                    }
                                }
                                else AnythingElse(); // Displays what, Nani, etc...
                                break;
                            case "documents":
                                passwordCheck = true;
                                Console.WriteLine("As you examine the documents you see a list of names with their respective marks for the Professional Practice paper.\n As you read through it, you can spot only four people with perfect marks:");
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
                                Console.WriteLine("Your average BIT computer, who uses a single monitor unfortunately, eager for your password to log you on.");
                                Console.WriteLine("It is powered by a UPS, probably you could charge your phone here");
                                break;
                            case "food":
                                Console.WriteLine("It doesn't look that good, but you think it is better than nothing.");
                                break;
                            case "v":
                                Console.WriteLine("A really popular energy drink among the Otago Polytechnic students.");
                                break;
                            case "sledgehammer":
                                Console.WriteLine("A tool that pehaps you could use somehow.");
                                break;
                            case "keycard":
                                Console.WriteLine("A card that grants you access to the Uni Campus through the University Gate");
                                break;
                            case "syringe":
                                Console.WriteLine("The last dose of serum entrusted to you to save Paul.");
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
                            case "food":
                            case "v":
                            case "sledgehammer":
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
                    Console.WriteLine("You wind back and watch the video from the beginning. It says: “Emergency... all the population in the Otago Region has to evacuate the area by \ngoing to the nearest safe zones immediately, an outbreak of...” the video stops playing.");
                    knowingWhatIsGoingOn = true;
                }
                else Console.WriteLine("You need a working computer to enter your password");
                anythingElseCondition = false;
            }
            //EAT FOOD
            if (answer == "eat food")
            {
                if (inventory.Contains("food"))
                {
                    Console.WriteLine("At first; you thought the food was bad but it turned out to be quite a decent meal.");
                    Console.WriteLine("You now feel more energetic. Ready to kick some \"dead asses\".");
                    //Deleting food
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        if (inventory[i] == "food") 
                        {
                            inventory[i] = "";
                            break;
                        }
                    }
                    //Stops the counter
                    foodCurrent = false;
                }
                else Console.WriteLine("You have to take it first...");
                anythingElseCondition = false;
            }
            //DRINK V
            if (answer == "drink v")
            {
                if (inventory.Contains("v"))
                {
                    Console.WriteLine("After the last sip, you start to feel a rush of energy flowing within your body, you have extended you lifespan.");
                    //Deleting v
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        if (inventory[i] == "v")
                        {
                            inventory[i] = "";
                            break;
                        }
                    }
                    food_level_current += 10;
                }
                else Console.WriteLine("You have to take it first...");
                anythingElseCondition = false;
            }
            //USE KEYCARD
            if (answer == "unlock gate" || answer == "open gate" || answer == "use keycard")
            {
                if ((x == -1 && y == 4 && z == 0) && inventory.Contains("keycard")) 
                {
                    Console.WriteLine("You have opened the gate.");
                    unlockedGate = true;
                }
                else if ((x == -1 && y == 4 && z == 0) && !inventory.Contains("keycard")) 
                {
                    Console.WriteLine("You need some sort of key first");
                }
                else Console.WriteLine("What gate?");
                anythingElseCondition = false;
            }
        }
        public static void ZombieAttack()
        {
            zombieLoop = true;
            zombieBoolean = false;

            int randomNumber = rand.Next(3);

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
                        case "use keys":
                        case "throw keys":
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
                        case "use cv":
                        case "use curriculum vitae":
                        case "use curriculum":
                        case "use resume":
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
                        case "use documents":
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
                        case "throw phone":
                        case "use phone":
                            if (inventory.Contains("phone"))
                            {
                                Console.WriteLine("You yolo-throw your phone at the zombie, and out of sheer luck you hit it in the head.");
                                Console.WriteLine("Immediately after the impact, it explodes blowing up the zombie's head.");
                                Console.WriteLine("After this, you thank SAMSUNG for making deadly phones.");
                                for (int i = 0; i < inventory.Length; i++)
                                {
                                    if (inventory[i] == "phone")
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
                        case "charger":
                        case "use charger":
                            if (inventory.Contains("charger"))
                            {
                                Console.WriteLine("You take out the charger and you swing it around like a cowboy hoping that it wraps around the zombie's neck.");
                                Console.WriteLine("Letting go of the swinging cable results in it wrapping around your own neck.");
                                Console.WriteLine("Struggling to breathe, the zombie lashes out and pushes you to the ground.");
                                Console.WriteLine("The zombie grabs the cable and pulls tight. Ending your life.");
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
                        case "photo":
                        case "use photo":
                            if (inventory.Contains("photo"))
                            {
                                Console.WriteLine("You take out the Rob's photo and the only thing you come up with is praying for salvation.");
                                Console.WriteLine("Right when you are about to get killed, a man with two machine guns (one in each hand) appears and obliterates the zombie.");
                                Console.WriteLine("When he takes off his badass-looking sunglasses, his face rings a bell. After this, you thank him for his immeasurable \"support\"");
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
                        case "sledgehammer":
                        case "use sledgehammer":
                            if (inventory.Contains("sledgehammer"))
                            {
                                Console.WriteLine("You take the sledgehammer and smash the zombie's head with it.");
                                Console.WriteLine("You do it so hard that you end up breaking it, getting a useless tool as result.");
                                Console.WriteLine("Therefore, you decide to discard it. At least it saved your life once.");
                                //Deleting sledgehammer
                                for (int i = 0; i < inventory.Length; i++)
                                {
                                    if (inventory[i] == "sledgehammer")
                                    {
                                        inventory[i] = "";
                                        break;
                                    }
                                }
                                zombieLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("you don't have this item");
                            }
                            break;
                        default:
                            Console.WriteLine("Please enter a valid input.");
                            break;
                    }
                }
                Console.WriteLine();
            }
        } //1 out of 4 times a zombie spawns
        public static void foodCounter()
        {
            if (foodCurrent)
            {
                food_level_current--;
            }

            if (food_level_current == 0) //This condition forces the game to exit
            {
                firstWhileCondition = false;
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t         YOU DIDN'T EAT ANYTHING, YOU STARVED TO DEATH. GAME OVER");
                Console.ReadLine();
            }
        }
        public static void zombificationCounter()
        {
            if (zombificationCurrent)
            {
                zombie_level_current--;
            }

            if (zombie_level_current == 0) //This condition forces the game to exit
            {
                firstWhileCondition = false;
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t   YOU DIDN'T MAKE IT TO THE UNI IN TIME, YOU TURNED INTO A ZOMBIE. GAME OVER");
                Console.ReadLine();
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
        public static void Help(string answer) //DISPLAYS FOOD COUNTER
        {

            switch (answer)
            {
                case "help":
                case "info":
                    Console.WriteLine("To move you can use 'North', 'South', 'East', 'West'.");
                    Console.WriteLine("You can also use abreviated terms like 'n' for North.");
                    Console.WriteLine("Inside Buildings you can go 'Up' or 'Down'.");
                    Console.WriteLine("To see what's in the world around you type 'look' or 'l'.");
                    Console.WriteLine("To access your current items, use 'inventory' or 'i'.");
                    Console.WriteLine("If you find something perhaps you want to 'inspect' or 'examine' it.");
                    Console.WriteLine("You can use 'save' to save your progress, and you can use 'exit' to close the game.");
                    Console.WriteLine("Finally you can use words like 'get' and 'grab' to pick up any items you come accross.");
                    Console.WriteLine("Bear in mind that these are jsut a few commands, feel free to experiment.");
                    anythingElseCondition = false;
                    break;
                case "food": //Developer tool to display the food counter
                    Console.WriteLine(food_level_current);
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
        public static void Name(string answer)
        {
            switch (answer)
            {
                case "name":
                    Console.WriteLine(name);
                    anythingElseCondition = false;
                    break;
            }
        }
        public static void Omnipresent(string answer)
        {
            switch (answer)
            {
                case "omnipresent":
                    Console.Write("x coordinate: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("y coordinate: ");
                    y = Convert.ToInt32(Console.ReadLine());
                    Console.Write("z coordinate: ");
                    z = Convert.ToInt32(Console.ReadLine());
                    secondWhileCondition = false;
                    anythingElseCondition = false;
                    break;
            }
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
            Name(answer);
            Omnipresent(answer);
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
            if (inputFromMenu == 1) // NEW GAME
            {
                //INSTRUCTIONS
                Console.WriteLine("\n\n\n\n\n\n\n\n");
                Console.WriteLine("\t\t\t\t\t\t\t\tYou are to navigate your way through");
                Console.WriteLine("\t\t\t\t\t\t\t\tthe zombie apocalypse. To do so you must");
                Console.WriteLine("\t\t\t\t\t\t\t\tsearch for items that are spread out around ");
                Console.WriteLine("\t\t\t\t\t\t\t\tworld. Basic commands are N,E,S & W");
                Console.WriteLine("\t\t\t\t\t\t\t\tYour job is to figure out the rest,");
                Console.WriteLine("\t\t\t\t\t\t\t\tand above all, survive!");
                Console.WriteLine("\t\t\t\t\t\t\t\tGood Luck.");
                Console.ReadLine();
                ReadingNewGameSettings();
                nameLoop = true;
                while (nameLoop)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                    Console.Write("\t\t\t\t\t\tI am an average BIT student whose name is: ");
                    name = Console.ReadLine();
                    if (name != "")
                    {
                        nameLoop = false;
                    }
                    else
                    {
                        Console.WriteLine("\n\t\t\t\t\t\t\tPlease enter a valid name.");
                        Console.ReadLine();
                    }
                }
            }
            if (inputFromMenu == 2) ReadingSavedGameSettings();  // RESUME GAME

            Console.Clear();

            //Main While-Loop
            firstWhileCondition = true;
            while (firstWhileCondition) //FIRST WHILE
            {
                //D BLOCK
                if (x == 0 && y == 0 && z == 1) //LOCATION 001 D201
                {
                    if (introduction)
                    {
                        SavingCoordinates();
                        introduction = false;
                        Console.WriteLine("You wake up in the middle of D201, looking bewildered and unable to remember anything at all. Outside, a cold and dark night lies upon Dunedin.");
                        Console.WriteLine("After a while, you make up your mind and decide to find out what is going on and more importantly, who you are...");
                        CommandAnalysis(location001);
                    }
                    else if ((savingX == 1 && savingY == 0 && savingZ == 1) && lockedPaul)
                    {
                        Console.WriteLine("You shouldn't go back there, Paul is there and he is watching you through the door's glass.");
                        LoadSavedCoordinates();
                    }
                    else if (d201Decision)
                    {
                        d201Decision = false;
                        SavingCoordinates();
                        while (d201Loop)
                        {
                            Console.WriteLine("\nYou are in D201, you locked the door, through the window you can see Paul attempting to get inside to eat your brain and read your \"Tech News\".");
                            Console.WriteLine("After a while, you look out the window, everything seems calm. Nevertheless, you start to feel the effects of the virus.");
                            Console.WriteLine("You are slowly turning into a zombie!");
                            zombificationCurrent = true;
                            Console.WriteLine("You have two options:");
                            Console.WriteLine("do you use the cure on yourself \"save yourself\" or you do \"save Paul\"?");
                            string answer2 = Console.ReadLine();
                            if (answer2 != "")
                            {
                                answer2 = answer2.ToLower();
                                switch (answer2)
                                {
                                    case "myself":
                                    case "save myself":
                                    case "save me":
                                    case "me":
                                    case "save yourself":
                                    case "yourself":
                                        savedYourself = true;  //Ending Decision
                                        d201Loop = false;
                                        LoadSavedCoordinates();
                                        break;
                                    case "paul":
                                    case "save paul":
                                        savedPaul = true;  //Ending Decision
                                        d201Loop = false;
                                        LoadSavedCoordinates();
                                        break;
                                    default:
                                        Console.WriteLine("Please enter a valid answer");
                                        break;
                                }
                            }
                            else Console.WriteLine("Please enter a valid answer");
                        }
                    }
                    else if (savedYourself)
                    {
                        Console.WriteLine("\nYou pull out the syringe out from your inventory, without thinking about it twice, you inject the green ");
                        Console.WriteLine("suerum into your bloodstream. Immediately after, you begin to notice and feel its effects.");
                        Console.WriteLine("After a while, you feel better than ever in fact you feel super human!.");
                        Console.WriteLine("You unlock the door and proceed to get Paul.");
                        getPaul = true;
                        ///Deleting syringe
                        for (int i = 0; i < inventory.Length; i++)
                        {
                            if (inventory[i] == "syringe")
                            {
                                inventory[i] = "";
                                break;
                            }
                        }
                        CommandAnalysis(location001);
                    }
                    else if (savedPaul && afterSavingPaul)
                    {
                        afterSavingPaul = false;
                        Console.WriteLine("\nYou pull out the syringe out from your inventory, you stare at the green suerum and start meditating about your situation.");
                        Console.WriteLine("You think that perhaps if you don't save Paul you will never be able to find out who you are.");
                        Console.WriteLine("What's more, if you end up turning into a zombie, it wouldn't matter because you think that having no memories is the same as being dead.");
                        Console.WriteLine("Suddenly a noise kills your reflection time, you see Paul trying to knock down the door.");
                        Console.WriteLine("Then you prepare the syringe and unlock the door. Paul tackles the door and after the impact, he falls over.");
                        Console.WriteLine("You jump on him and inject the suerum. Right away, you start seeing how quicly he recovers his human form.");
                        Console.WriteLine("You are not that strong enough to carry Paul, so you decide to drag him instead.");
                        ///Deleting syringe
                        for (int i = 0; i < inventory.Length; i++)
                        {
                            if (inventory[i] == "syringe")
                            {
                                inventory[i] = "";
                                break;
                            }
                        }
                        CommandAnalysis(location001);
                    }
                    else
                    {
                        SavingCoordinates();
                        Console.WriteLine("You are in D201, the classroom you once loved.");
                        CommandAnalysis(location001);

                    }
                } //LOCATION 001 D201
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 0 && z == 1) //LOCATION 101 STAIRS SECOND FLOOR
                {
                    if (getPaul)
                    {
                        SavingCoordinates();
                        getPaul = false;
                        lockedPaul= true;
                        Console.WriteLine("After stepping out of D201 you no longer feel like a super human when you see Paul frenetically running towards you.");
                        Console.WriteLine("You enter D201 once agaim and close the door without locking it.");
                        Console.WriteLine("Paul knocks down the door and after the impact, he falls over.");
                        Console.WriteLine("You take this chance to lock him in D201");
                        LoadSavedCoordinates();
                    }
                    else if (paulRaid)
                    {
                        paulRaid = false;
                        d201Decision = true;
                        Console.WriteLine("Before continuing any further, you kneel down and start to pray to gather enough guts for what's to come.");
                        Console.WriteLine("However, \"REALITY HITS YOU HARD BRO\", and Paul who was lurking from the darkness, pounces onto you like some sort of hungry tiger.");
                        Console.WriteLine("He bites your kneck, and immidiatly after, he goes insane by the taste of your blood.");
                        Console.WriteLine("You manage to articulate some words and say to Paul that you have the latest \"Tech News\" on your phone.");
                        Console.WriteLine("Paul gets petrified for a moment and you take this opportunity to break free and run inside D201 and quickly shut the door.");
                        x = 0;  y = 0; z = 1;
                    }
                    else
                    {
                        SavingCoordinates();
                        Console.WriteLine("You spot a weak light coming out of one the rooms.");
                        Console.WriteLine("You are in the second floor.");
                        Console.WriteLine("You can see the building stairs from here.");
                        CommandAnalysis(location101);
                    }
                }//LOCATION 101 STAIRS SECOND FLOOR
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == -1 && z == 1) //LOCATION 1n11 COMMON ROOM
                {
                    if (secondTimeEliseOffice) //This if fixes a bug
                    {
                        SavingCoordinates();
                        Console.WriteLine("The light is coming from one of the computers which seems to be still turned on thanks to a UPS. Apparently it is the only source of energy available in this building.\n You try to access the computer but it asks for a password");
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
                            Console.WriteLine("The light is coming from one of the computers which seems to be still turned on thanks to a UPS. Apparently it is the only source of energy available in this building.\n You try to access the computer but it asks for a password");
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
                        Console.WriteLine("You enter Elise’s office and her professionally arranged desk catches your eyes once again. At the same time, something unconsciously bothers you, you realize that the smell is gone,\nand then you try to have a look at the corpse so that your paranoia doesn’t get the best of you. Lo and behold, all you see is just a puddle of blood instead. Right after this, you start laughing kinda like the Joaquin Phoenix when you realize that “the shit has hit the fan”.");
                        CommandAnalysis(location1n12);
                    }
                    else if (firstTimeEliseOffice)
                    {
                        SavingCoordinates();
                        Console.WriteLine("As you step into Elise's office, the smell gets even stronger. On the other hand, her really well-organized desk draws your attention and makes you think that with such a setting you \ncould always find any kind of information easier than any sort algorithm. Suddenly, you turn your head to your left and see a corpse lying on the floor. Terrified by the scene, you fall over to the floor and remain petrified for a while. Then you realize the dead man had some fancy glasses which makes you regain your sanity.");
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
                    if (davidFirstFloor) //SERVER ROOM HAS BEEN ACTIVATED
                    {
                        davidFirstFloor = false;
                        davidSeen = true;
                        SavingCoordinates();
                        Console.WriteLine("Someone is passing by looking quite... “chillaxed”.");
                        Console.WriteLine("You approach him and ask him for help. He interrupts you and tells you that he has been working on a super exciting AI project for almost a week non-stop, and now that the servers are down for some");
                        Console.WriteLine("uncommon and strange reason, he is gonna take a break. You try to tell him if he knows what is going on, but he walks away saying that he cannot wait to tell everyone what he’s been up to by tomorrow morning.");
                        CommandAnalysis(location100);
                    }
                    else if (rescuePaul)
                    {
                        rescuePaul = false;
                        paulRaid = true;
                        SavingCoordinates();
                        Console.WriteLine("You enter the D Block and start looking for Paul.");
                        Console.WriteLine("You can hear really bizarre cries coming from the floors above.");
                        Console.WriteLine("You are in the first floor.");
                        Console.WriteLine("You can see the building stairs from here. ");
                        Console.WriteLine("You notice that both the southern and northern exits are open.");
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
                else if (x == 1 && y == 1 && z == 0) //LOCATION 110 OUTSIDE OF D BLOCK NORTH
                {
                    if (savingX == 1 && savingY == 1 && savingZ == 1) //The location you are comming from
                    {
                        Console.WriteLine("You can't go this way\n");
                        LoadSavedCoordinates();
                    }
                    else
                    {
                        if (messageSeen && knowingWhatIsGoingOn && davidSeen)
                        {
                            SavingCoordinates();
                            Console.WriteLine("You are outside the D block, the hostile atmosphere chills your blood.");
                            Console.WriteLine("It's been a while since the last time you ate something. You are starting to feel extremely weak.");
                            Console.WriteLine("If you don't find something to eat soon, you may die.");

                            //ACTIVATES FOOD COUNT
                            if (firstTimeGoingOutDBlock)
                            {
                                firstTimeGoingOutDBlock = false;
                                foodCurrent = true;
                            }
                            CommandAnalysis(location110);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You cannot leave the building yet.You need to find out about yourself and where to go.\n");
                            Console.WriteLine("Perhaps explore the building a bit more?");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            LoadSavedCoordinates();
                        }
                    }
                }//LOCATION 110 OUTSIDE OF D BLOCK NORTH
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == 2 && z == 0) //LOCATION 120
                {
                    SavingCoordinates();
                    Console.WriteLine("You enter the H Block, also known as ‘The Hub’ at least that's what the sign above the door says.");
                    Console.WriteLine("There are puddles of blood everywhere. You wonder how this happened.");
                    Console.WriteLine("You should look around for anything that might help.");

                    CommandAnalysis(location120);
                }//LOCATION 120 HUB
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
                            Console.WriteLine("It's been a while since the last time you ate something. You are starting to feel extremely weak.");
                            Console.WriteLine("If you don't find something to eat soon, you may die.");

                            //ACTIVATES FOOD COUNT
                            if (firstTimeGoingOutDBlock)
                            {
                                firstTimeGoingOutDBlock = false;
                                foodCurrent = true;
                            }
                            CommandAnalysis(location110);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You cannot leave the building yet.\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            LoadSavedCoordinates();

                        }
                    }
                }//LOCATION 1n10 OUTSIDE OF D BLOCK SOUTH
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 2 && y == 0 && z == 2) //LOCATION 202 SERVER ROOM
                {
                    if (firstTimeServerRoom)
                    {
                        firstTimeServerRoom = false;
                        davidFirstFloor = true;
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
                            else if (answer == "run" || answer == "get out" || answer == "run out" || answer == "escape" || answer == "leave")
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
                    }
                    else
                    {
                        Console.WriteLine("You can't go this way, the room is totally destroyed.\n");
                        LoadSavedCoordinates();
                    }
                    x = 1; y = 0; z = 2; //STAIRS THIRD FLOOR
                }//LOCATION 202 SERVER ROOM

                //AROUND MAANAKI
                else if (x == 0 && y == -2 && z == 0) // 0n20 HARBOUR TERRACE
                {
                    ZombieAttack();  // ZOMBIE METHOD
                    if (zombieBoolean) break; // This conditional terminates the current loop and exits the game
                    SavingCoordinates();
                    Console.WriteLine("Be careful you are on the Harbour Terrace St");
                    CommandAnalysis(location0n20);
                }//LOCATION 0n20 HARBOUR TERRACE
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == -2 && z == 0) // 1n20 HARBOUR TERRACE
                {
                    ZombieAttack();  // ZOMBIE METHOD
                    if (zombieBoolean) break; // This conditional terminates the current loop and exits the game
                    SavingCoordinates();
                    Console.WriteLine("Be careful you are on the Harbour Terrace St");
                    CommandAnalysis(location1n20);
                }//LOCATION 1n20 HARBOUR TERRACE
                 ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 2 && y == -2 && z == 0) // 2n20 HARBOUR TERRACE
                {
                    ZombieAttack();  // ZOMBIE METHOD
                    if (zombieBoolean) break; // This conditional terminates the current loop and exits the game
                    SavingCoordinates();
                    Console.WriteLine("Be careful you are on the Harbour Terrace St");
                    CommandAnalysis(location2n20);
                }//LOCATION 2n20 HARBOUR TERRACE
                 ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == -3 && z == 0) // 1n30 //APPROACHING MAANAKI's CAR PARK
                {
                    SavingCoordinates();
                    Console.WriteLine("You are approuching Manaaki's car park");
                    CommandAnalysis(location1n30);
                }//LOCATION 1n30 //APPROACHING MAANAKI's CAR PARK
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 1 && y == -4 && z == 0) // 1n40 DARK ALLEY
                {
                    SavingCoordinates();
                    Console.WriteLine("You are in a dark alley leading you toward Manaaki");
                    CommandAnalysis(location1n40);
                }//LOCATION 1n40 DARK ALLEY
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 2 && y == -4 && z == 0) // 2n40 MAANAKI ENTRANCE
                {
                    SavingCoordinates();
                    Console.WriteLine("You are in Manaaki");
                    Console.WriteLine("You seem to hear some rumbling and weird sounds coming from somewhere.");
                    CommandAnalysis(location2n40);
                }//LOCATION 2n40 MAANAKI ENTRANCE

                //MAANAKI SECOND FLOOR
                else if (x == 2 && y == -4 && z == 1) // 2n41 MAANAKI SECOND FLOOR
                {
                    SavingCoordinates();
                    Console.WriteLine("Stairs level 2 Manaaki");
                    CommandAnalysis(location2n41);
                }//LOCATION 2n41 MAANAKI SECOND FLOOR
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 3 && y == -4 && z == 1) // 3n41 Manaaki  //BECOMING LOUDER
                {
                    SavingCoordinates();

                    Console.WriteLine("You are on the second floor.");
                    Console.WriteLine("the second is still dark and the sounds are becoming louder and louder...");
                    CommandAnalysis(location3n41);
                }//LOCATION 3n41 BECOMING LOUDER
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 4 && y == -4 && z == 1) // 4n41 MYSTERIOUS SOUNDS
                {
                    SavingCoordinates();
                    Console.WriteLine("You are getting warmer to the mysterious sounds");
                    CommandAnalysis(location4n41);
                }//LOCATION 4n41 MYSTERIOUS SOUNDS
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 2 && y == -5 && z == 1) // 2n51 GETTING WARMER
                {
                    SavingCoordinates();
                    Console.WriteLine("You are getting even warmer");
                    CommandAnalysis(location2n51);
                }//LOCATION 2n51 GETTING WARMER
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 3 && y == -5 && z == 1) // 3n51 PUDDLE OF WATER
                {
                    SavingCoordinates();
                    Console.WriteLine("You have walked into a puddle of water");
                    CommandAnalysis(location3n51);
                }//LOCATION 3n51 PUDDLE OF WATER
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 4 && y == -5 && z == 1) // 4n51 MAANAKI SECOND FLOOR 
                {
                    SavingCoordinates();
                    Console.WriteLine("You are still on the second floor.");
                    CommandAnalysis(location4n51);
                }//LOCATION 4n51 MAANAKI SECOND FLOOR
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 2 && y == -6 && z == 1) // 2n61 COUNTER
                {
                    SavingCoordinates();
                    Console.WriteLine("You have walked into a metal counter");
                    CommandAnalysis(location2n61);
                }//LOCATION 2n61 COUNTER
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 3 && y == -6 && z == 1) // 3n61 COUNTER
                {
                    SavingCoordinates();
                    Console.WriteLine("You have walked into a metal counter");
                    CommandAnalysis(location3n61);
                }//LOCATION 3n61 COUNTER
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 4 && y == -6 && z == 1) // 4n61 V DRINK
                {
                    SavingCoordinates();
                    Console.WriteLine("The counter finishes here."); //V drink
                    CommandAnalysis(location4n61);
                }//LOCATION 4n61 V DRINK


                //LIBRARY
                else if (x == -2 && y == 1 && z == 0) // n210 LIBRARY ENTRANCE
                {
                    SavingCoordinates();
                    Console.WriteLine("You are on the libraries ground floor");
                    CommandAnalysis(locationn210);
                }//LOCATION n210 LIBRARY ENTRANCE
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == -2 && y == 1 && z == 1) // n211 LIBRARY SECOND FLOOR
                {
                    SavingCoordinates();
                    Console.WriteLine("Second Level Library");
                    CommandAnalysis(locationn211);
                }//LOCATION n211 LIBRARY SECOND FLOOR
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == -3 && y == 1 && z == 1) // n311 LIBRARY SECOND FLOOR
                {
                    SavingCoordinates();
                    Console.WriteLine("Second Level Library");
                    CommandAnalysis(locationn311);
                }//LOCATION n311 LIBRARY SECOND FLOOR
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == -2 && y == 0 && z == 1) // n201 LIBRARY SECOND FLOOR
                {
                    SavingCoordinates();
                    Console.WriteLine("Second Level Library");
                    CommandAnalysis(locationn201);
                }//LOCATION n201 LIBRARY SECOND FLOOR
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == -3 && y == 0 && z == 1) // n301 LIBRARY SECOND FLOOR
                {
                    SavingCoordinates();
                    Console.WriteLine("Second Level Library");
                    CommandAnalysis(locationn301);
                }//LOCATION n301 LIBRARY SECOND FLOOR
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == -3 && y == 2 && z == 1) // n321 LIBRARY SECOND FLOOR STAIRS
                {
                    SavingCoordinates();
                    Console.WriteLine("Second Level Library");
                    CommandAnalysis(locationn321);
                }//LOCATION n321 LIBRARY SECOND FLOOR STAIRS
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == -3 && y == 2 && z == 2) // n322 LIBRARY THIRD FLOOR
                {
                    SavingCoordinates();
                    Console.WriteLine("Third Level Library");
                    Console.WriteLine("Stairs");
                    CommandAnalysis(locationn322);
                }//LOCATION n322 LIBRARY THIRD FLOOR
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == -3 && y == 3 && z == 2) // n332 KEYCARD
                {
                    SavingCoordinates();
                    Console.WriteLine("A small room which seemed to store important things for the University of Otago.");
                    CommandAnalysis(locationn332);
                }//LOCATION n332 KEYCARD
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                //STREETS
                else if (x == 1 && y == 3 && z == 0) //LOCATION 130 FORTH STREET 
                {
                    ZombieAttack();  // ZOMBIE METHOD
                    if (zombieBoolean) break; // This conditional terminates the current loop and exits the game
                    SavingCoordinates();
                    Console.WriteLine("You are on Forth St");
                    CommandAnalysis(location130);
                }//LOCATION 130 FORTH STREET 
                 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == 0 && y == 3 && z == 0) //LOCATION 030 FORTH STREET
                {
                    ZombieAttack();  // ZOMBIE METHOD
                    if (zombieBoolean) break; // This conditional terminates the current loop and exits the game
                    SavingCoordinates();
                    Console.WriteLine("You are on Forth St");
                    CommandAnalysis(location030);
                }//LOCATION 030 FORTH STREET
                 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                else if (x == -1 && y == 3 && z == 0) //LOCATION n130 UNION STREET
                {
                    ZombieAttack();  // ZOMBIE METHOD
                    if (zombieBoolean) break; // This conditional terminates the current loop and exits the game
                    SavingCoordinates();
                    Console.WriteLine("You are on Union St");
                    CommandAnalysis(locationn130);
                }//LOCATION n130 UNION STREET
                 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == -1 && y == 2 && z == 0) // n120 UNION STREET
                {
                    ZombieAttack();  // ZOMBIE METHOD
                    if (zombieBoolean) break; // This conditional terminates the current loop and exits the game
                    SavingCoordinates();
                    Console.WriteLine("You are on Unions St");
                    CommandAnalysis(locationn120);
                }//LOCATION n120 UNION STREET
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == -1 && y == 1 && z == 0) // n110 UNION STREET
                {
                    ZombieAttack();  // ZOMBIE METHOD
                    if (zombieBoolean) break; // This conditional terminates the current loop and exits the game
                    SavingCoordinates();
                    Console.WriteLine("You are on Unions St");
                    CommandAnalysis(locationn110);
                }//LOCATION n110 UNION STREET
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == -1 && y == 0 && z == 0) // n100 UNION STREET
                {
                    ZombieAttack();  // ZOMBIE METHOD
                    if (zombieBoolean) break; // This conditional terminates the current loop and exits the game
                    SavingCoordinates();
                    Console.WriteLine("You are on Unions St");
                    CommandAnalysis(locationn100);
                }//LOCATION n100 UNION STREET
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == -1 && y == -1 && z == 0) // n1n10 UNION STREET
                {
                    ZombieAttack();  // ZOMBIE METHOD
                    if (zombieBoolean) break; // This conditional terminates the current loop and exits the game
                    SavingCoordinates();
                    Console.WriteLine("You are on Unions St");
                    CommandAnalysis(locationn1n10);
                }//LOCATION n1n10 UNION STREET
                 ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == -1 && y == -2 && z == 0) // n1n20 UNION STREET
                {
                    ZombieAttack();  // ZOMBIE METHOD
                    if (zombieBoolean) break; // This conditional terminates the current loop and exits the game
                    SavingCoordinates();
                    Console.WriteLine("You are on Unions St");
                    CommandAnalysis(locationn1n20);
                }//LOCATION n1n20 UNION STREET


                //UNIVERSITY
                else if (x == -1 && y == 4 && z == 0) //LOCATION n140 UNIVERSITY GATE
                {
                    if (rightAfterUniCampus)
                    {
                        rightAfterUniCampus = false;
                        while (gateLoop)
                        {
                            Console.WriteLine("\nYou come out of the University campus and wonder whether to close the gate or not.");
                            Console.Write("Do you close the gate? (Y/N): ");
                            string answer2 = Console.ReadLine();
                            answer2 = answer2.ToLower();
                            if (answer2 != "")
                            {
                                answer2 = answer2.ToLower();
                                switch (answer2[0])
                                {
                                    case 'y':
                                        closeGate = true;  //Ending Decision
                                        gateLoop = false;
                                        break;
                                    case 'n':
                                        openGate = true;
                                        gateLoop = false;  //Ending Decision
                                        break;
                                    default:
                                        Console.WriteLine("Please enter a valid answer");
                                        break;
                                }
                            }
                            else Console.WriteLine("Please enter a valid answer");
                        }
                        Console.WriteLine();
                    }
                    if (closeGate && savedPaul)
                    {
                        Console.Clear();
                        Console.WriteLine("Miraculously, you and Paul have arrived at the University Gate, you have to open the gate in order to enter.");
                        Console.WriteLine("You manage to close the gate again and fall exhausted to the floor, then you pass out.");
                        Console.WriteLine("When you wake up, you see almost all of the BIT community crowded inside the hospital room you are in, and a bunch of presents for you.");
                        Console.WriteLine("Then you turn your head to the left and you see Paul on the other bed smiling at you. He then expresses his gratitude to you.");
                        Console.WriteLine("Suddenly you remember that you were about to become a zombie, so you quickly see your arms and hands, and everything looks in order.");
                        Console.WriteLine("When Elise notices how concerned you look, she proceeds to explain. She tells you that the scientists were able to develop more suerums,");
                        Console.WriteLine("and that after you passing out at the gate they took you into the camp, and hours later the army came to rescue everyone.");
                        Console.WriteLine("You {0}, have survived the Otago Apocalypse and your great heart managed to rescue everyone. Congratulations!",name);
                        Console.ReadLine();
                        firstWhileCondition = false;
                    }
                    else if (closeGate && savedYourself)
                    {
                        Console.WriteLine("You arrive at the University Gate, you have to open the gate in order to enter.");
                        Console.WriteLine("You close the gate again, and head towards the Refugee Camp.");
                        Console.WriteLine("Krissi focuses you with her flashlight and aims at you with her gun. After verifying that it is you, she let's you in.");
                        Console.WriteLine("When you enter the camp, Elise comes up to you and asks where Paul is");
                        Console.WriteLine("You tell her that you couldn't find him. Then she starts to cry and asks you to return the suerum because now they need to save Joy who was bitten by a zombie dog.");
                        Console.WriteLine("You lie to Elise telling her that you lost the suerum, then she starts to freak out because that was the only cure there was.");
                        Console.WriteLine("You say that you feel sorry for Paul and Joy, and head to find something to eat.");
                        Console.WriteLine("Hours later the army comes in and rescues everyone.");
                        Console.WriteLine("You {0}, have survived the Otago Apocalypse, however, you are intrinsically selfish. Neutral Ending", name);
                        Console.ReadLine();
                        firstWhileCondition = false;
                    }
                    else if (openGate && savedPaul)
                    {
                        Console.Clear();
                        Console.WriteLine("Miraculously, you and Paul have arrived at the University Gate, you don't have to open the gate in order to enter because you left it open.");
                        Console.WriteLine("You manage to close the gate again and at this point you're feeling extreamly fatigued, therefore you pass out.");
                        Console.WriteLine("When you wake up, you feel like eating brains so bad. Then you look up and contemplate a horde of zombies inside the University Campus.");
                        Console.WriteLine("You barely have lucid thoughts by now. You look down and see a corpse on the ground. You swear that body had a head before you passed out.");
                        Console.WriteLine("You realize that all the zombies that walk past you ignore you. Then, you try to hurry up and get to the Refugee Camp desperately to find Salvation");
                        Console.WriteLine("When you reach the camp, all you find is hell, apparently the zombies have completely taken over the place.");
                        Console.WriteLine("You blame yourself for not having closed the gates and your consciousness fades away.");
                        Console.WriteLine("You {0}, didn't survive the Otago Apocalypse and got everyone killed. Such a Tragedy. Bad Ending.", name);
                        Console.ReadLine();
                        firstWhileCondition = false;
                    }
                    else if (openGate && savedYourself)
                    {
                        Console.WriteLine("You arrive at the University Gate.");
                        Console.WriteLine("You see a huge horde of zombies making their way into the University Campus");
                        Console.WriteLine("You then realize having left the gates open was not a really good idea at all.");
                        Console.WriteLine("All you can hear are the screams of horror of what is about to happen.");
                        Console.WriteLine("You can't stand the guilt of being responsible for killing everyone, and decide that the easiest way out is to end it right here.");
                        Console.WriteLine("With no sanity left in your mind, you run into the horde of zombies to never see the light again.");
                        Console.WriteLine("You {0}, didn't survive the Otago Apocalypse and got everyone killed, you are intrinsically selfish. Bad Ending.", name);
                        Console.ReadLine();
                        firstWhileCondition = false;
                    }
                    else if (closeGate)
                    {
                        SavingCoordinates();
                        Console.WriteLine("You reach at the University Gate, you can sense hope coming from the other side of it.");
                        Console.WriteLine("The door remains closed as you decided");
                        CommandAnalysis(locationn140);
                    }
                    else if (openGate)
                    {
                        SavingCoordinates();
                        Console.WriteLine("You reach at the University Gate, you can sense hope coming from the other side of it.");
                        Console.WriteLine("The door remains open as you decided");
                        CommandAnalysis(locationn140);
                    }
                    else
                    {
                        SavingCoordinates();
                        Console.WriteLine("You reach at the University Gate, you can sense hope coming from the other side of it.");
                        Console.WriteLine("I the gate is locked, perhaps you can find something to open it.");
                        CommandAnalysis(locationn140);
                    }
                }//LOCATION n140 UNIVERSITY GATE
                 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (x == -1 && y == 5 && z == 0) //LOCATION n150 UNIVERSITY CAMPUS
                {
                    if (unlockedGate)
                    {
                        Console.Clear();
                        Console.WriteLine("You walk into the University campus making sure you close the gate again.");
                        Console.WriteLine("In the distance you see someone with a flashlight, then, you decide to approach and start shouting for help.");
                        Console.WriteLine("The person notices you and focuses you with the flashlight. Right after that, they start shooting their gun at you.");
                        Console.WriteLine("Luckily for you, the visually impaired person missed all their shots and had to reload their gun again.");
                        Console.WriteLine("When the person is ready to shoot, they aim at you and when they're about to pull the trigger, out of nowhere Elise shouts \"STOP!\"");
                        Console.WriteLine("Elise tells Krissi that she has found her glasses and that you are not a zombie, in fact you are {0}, one of the BIT students",name);
                        Console.WriteLine("You hear your name and immediately realize that your parents certainly had a really bad taste for names, and probably disgraced your previous life.");
                        Console.WriteLine("After this, they take you to a refugee camp.");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Elise starts to talk about how they establihed themselves here a week ago and that the army will evacuate everyone soon");
                        Console.WriteLine("On the other hand, she cheerfuly tells you that some scientists from the Uni have been able to find a cure.");
                        Console.WriteLine("Then, she explains that they thought they had lost you, and that David almost gets killed by Krissi as well when he arrived some hours ago.");
                        Console.WriteLine("Sadly, she also tells you that the only one who couldn't make it was Paul.");
                        Console.WriteLine("You then tell Elise that you think Paul has become a zombie and wanders around in the D Block.");
                        Console.WriteLine("When she listens to that, in a matter of seconds she hands you a syringe with the last cure that they have and begs you to go and rescue Paul.");
                        Console.WriteLine("Persuaded by her professional selection of words you embark yourself to the Otago Polytechnic once again.");
                        rescuePaul = true;
                        //Adding the syringe to the inventory
                        for (int i = 0; i < inventory.Length; i++)
                        {
                            if (inventory[i] == "")
                            {
                                inventory[i] = "syringe";
                                break;
                            }
                        }
                        rightAfterUniCampus = true;
                        LoadSavedCoordinates();
                    }
                    else
                    {
                        Console.WriteLine("You need to open the gate first.");
                        LoadSavedCoordinates();
                    }
                }//LOCATION n150 UNIVERSITY CAMPUS
                 //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                
                //RED ZONES
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You can't go this way\n");
                    LoadSavedCoordinates();
                    //These conditionals reset the food and zombie counters
                    if (foodCurrent)
                    {
                        food_level_current++;
                    }
                    if (zombificationCurrent)
                    {
                        zombie_level_current++;
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
        public static void Credits()
        {
            Console.WriteLine(" \n\n\n\n\n\n\n\n\n\n\t\t\t\t\t The purpose of this project was to demonstrate the skills that we have been taught");
            Console.WriteLine("\t\t\t\t\t\t\tduring the first semester of the BIT S2 2019 stream");
            Console.WriteLine("");
            Console.WriteLine("\t\t\t   Thinking of a suitable credits area has taken way too much effort and time, so let's get straight to the point.");
            Console.WriteLine("\n\n");
            Console.WriteLine("\n\t\t\t\t\t\t\t\t    Here are the creators:\n\n");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t  Nabeel Riad");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t Mitchell Scott");
            Console.WriteLine("\t\t\t\t\t\t\t\t\tFrancisco Rosas");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t  Nguyen Nhan\n");
            Console.ReadLine();
        }
        static void Main()
        {
            Console.SetWindowSize(160, 40);
            while (menuLoop)
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t1 New Game \n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t2 Resume \n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t3 Credits \n");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t4 Exit \n");
                Console.Write("\t\t\t\t\t\t\t\t       :");
                string input = Console.ReadLine();

                if (input != "")
                {
                    switch (input)
                    {
                        case "1":
                            Console.Clear();
                            MainGAME(1);
                            Console.Clear();
                            break;
                        case "2":
                            Console.Clear();
                            MainGAME(2);
                            Console.Clear();
                            break;
                        case "3":
                            Console.Clear();
                            Credits();
                            Console.Clear();
                            break;
                        case "4":
                            Console.Clear();
                            Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\t\t\t\t\t\t\t\t      Exiting the game");
                            Thread.Sleep(2500);
                            menuLoop = false;
                            break;
                        default:
                            Console.Write("\n\n\t\t\t\t\t\t\t\tPlease enter a valid option.");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.Write("\n\n\t\t\t\t\t\t\t\tPlease enter a valid option.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
