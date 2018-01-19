using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Battleships
{
    class Program
    {

        static void Main(string[] args)
        {
            //dev
            while (true)
            {

                int size = Convert.ToInt32(Console.ReadLine());
                int[] ship_nums = new int[4];
                ship_nums[0] = 1;
                ship_nums[1] = 2;
                ship_nums[2] = 1;
                ship_nums[3] = 1;
                string[,] display = new string[size, size];

                string[,] enemies = new string[size, size];

                int health = 17;

                Grid_Size(ref size, ref display, ref enemies);
                Place_Enemies(size, ref enemies, ship_nums);
                for (int x = 0; x < size; x++)
                {
                    if ((x + 1) < 10)
                    {
                        Console.Write(" " + (x + 1));
                    }
                    else
                    {
                        Console.Write(x + 1);
                    }
                    for (int y = 0; y < size; y++)
                    {
                        if (enemies[y, x] == " -")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        else if (enemies[y, x] == " X")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (enemies[y, x] == " O")
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else if (enemies[y, x] == " #")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                        Console.Write(enemies[y, x]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
                while (true)
                {
                    Display(size, display);
                    Attack(size, ref enemies, ref display);

                    if (health == 0)
                    {
                        //Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("WIN!");
                    }
                }
                //Console.ReadLine();
            }
            //dev


            while (true)
            {           //this is the main menu that allows the user to select the different types of games
                int choice;
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Guessing Practice");
                Console.WriteLine("2. Player vs AI");
                Console.WriteLine("3. 2 Player");
                Console.WriteLine("4. Settings");
                Console.WriteLine("5. Quit");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        //goto guessing practice        //when the user selects the first option, the guessing practice subroutine will be called
                        break;
                    case 2:
                        Console.Clear();
                        //goto player vs AI     //when the user selects the second option, the PLayer vs AI subroutine will be called
                        break;
                    case 3:
                        Console.Clear();
                        //goto 2 player     //when the user selects the third option, the 2 player subroutine will be called
                        break;
                    case 4:
                        Console.Clear();
                        //goto settings     //when the user selects the fourth option, the setting subroutine will be called, which will allow the user to change the parameters of the game
                        break;
                    case 5:
                        Console.Clear();
                        //quit          //the fifth option will instantly quit the program
                        System.Environment.Exit(0);
                        break;

                }
            }

        }

        static void Grid_Size(ref int size, ref string[,] display, ref string[,] enemies)
        {
            //size = Convert.ToInt32(Console.ReadLine());   //sets the gridsize to whatever the user inputs (in the settings)
            //string[,] _display = new string[size, size];  //creates a new array called _display which draws the grid
            for (int x = 0; x < size; x++)
            {

                for (int y = 0; y < size; y++)
                {
                    display[y, x] = " -";       //populates the array with " -", which acts as a placeholder for an "empty" co-ordiante
                    enemies[y, x] = " -";
                }
            }

        }
        //set grid size
        static void Display(int size, string[,] display)
        {
            //Console.Clear();
            Console.Write("  ");
            for (int i = 0; i <= size - 1; i++)     //this for loop places the corrosponding letter above the correct column
            {
                const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";        //the code below grabs a letter from this string which is the alphabet

                var value = "";

                if (i >= letters.Length)
                    value += letters[i / letters.Length - 1];

                value += letters[i % letters.Length];

                Console.Write(" " + value);

            }
            Console.WriteLine();
            for (int x = 0; x < size; x++)
            {
                if ((x + 1) < 10)
                {
                    Console.Write(" " + (x + 1));
                }
                else
                {
                    Console.Write(x + 1);
                }
                for (int y = 0; y < size; y++)
                {
                    if (display[y, x] == " -")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    } else if (display[y, x] == " X")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    } else if (display[y, x] == " O")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (display[y, x] == " #")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }
                    Console.Write(display[y, x]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine();
            }
        }
        //display grid

        static void Place_Enemies(int size, ref string[,] enemies, int[] ship_nums)
        {
            for (int length = 2; length <= 5; length++)
            {
                for (int a = 1; a <= ship_nums[length - 2]; a++)
                {

                    int[,] temp = new int[2, 5];        //this creates a temporary array to hold the co-ordiantes of the ships 
                    Boolean ship_placed = false;

                    while (ship_placed == false)
                    {
                        Random rnd = new Random();      //the program generates two co-ordinates between 0 and the size of the grid (e.g. 10) and then chooses a random direction detween 1 and 4
                        int x = rnd.Next(size);
                        int y = rnd.Next(size);
                        int dir = rnd.Next(1, 5);
                        for (int i = 0; i <= length - 1; i++)   //then, for the length of the ship, 
                        {

                            switch (dir)
                            {
                                case 1:

                                    temp[1, i] = x;
                                    temp[0, i] = y + i;

                                    break;
                                case 2:

                                    temp[1, i] = x + i;
                                    temp[0, i] = y;


                                    break;
                                case 3:

                                    temp[1, i] = x;
                                    temp[0, i] = y - i;

                                    break;
                                case 4:

                                    temp[1, i] = x - i;
                                    temp[0, i] = y;

                                    break;
                            }
                        }
                        ship_placed = true;
                        for (int i = 0; i <= length - 1; i++)
                        {
                            if (temp[0, i] >= size || temp[0, i] <= 0 || temp[1, i] >= size || temp[1, i] <= 0)
                            {
                                ship_placed = false;
                            }
                            else if (enemies[temp[1, i], temp[0, i]] == " #")
                            {
                                ship_placed = false;
                            }
                        }
                    }
                    for (int b = 0; b <= length - 1; b++)
                    {
                        enemies[temp[1, b], temp[0, b]] = " #";
                    }
                }
            }
        }
        //place enemies

        static void Attack(int size, ref string[,] enemies, ref string[,] display)
        {
            Console.WriteLine();
            Console.WriteLine("Enter coordinate (e.g. 3E)");
            Console.WriteLine(); //the user enters their co-ordinates 
            string coord = Console.ReadLine();
            if (coord.Length >= 2)
            {
                char _1 = coord[0];
                char _2 = coord[1];
                char _3 = ' ';
                if (coord.Length == 3)
                {
                    _3 = coord[2];
                }
                int x = -1, y = -1;
                if ((char.IsDigit(_1) == true && char.IsLetter(_2) == true) && char.IsLetter(_3) == false)
                {
                    x = ((int)_2 % 32) - 1;
                    y = Convert.ToInt32(Convert.ToString(_1)) - 1;
                }
                else if ((char.IsDigit(_2) == true && char.IsLetter(_1) == true) && char.IsDigit(_3) == false)
                {
                    x = ((int)_1 % 32) - 1;
                    y = Convert.ToInt32(Convert.ToString(_2)) - 1;

                }
                else if (((char.IsDigit(_1) == true && char.IsDigit(_2) == true) && char.IsLetter(_3) == true))
                {
                    x = ((int)_3 % 32) - 1;
                    y = Convert.ToInt32(Convert.ToString(_1) + Convert.ToString(_2)) - 1;
                    Console.WriteLine(y);
                }
                else if (((char.IsDigit(_2) == true && char.IsDigit(_3) == true) && char.IsLetter(_1) == true))
                {
                    x = ((int)_1 % 32) - 1;
                    y = Convert.ToInt32(Convert.ToString(_2) + Convert.ToString(_3)) - 1;
                    Console.WriteLine(y);
                }
                else
                {
                    Console.WriteLine("Invalid Coordinte - Incorrect format");
                }

                if ((x >= 0 && x <= size) && (y >= 0 && y <= size))
                {
                    if (enemies[x, y] == " #")
                    {
                        Console.WriteLine("HIT!");
                        enemies[x, y] = " X";
                        display[x, y] = " X";

                    }
                    else if (enemies[y, x] == " -")
                    {
                        Console.WriteLine("MISS!");
                        enemies[x, y] = " O";
                        display[x, y] = " O";
                    }
                    else if (enemies[x, y] == " X" || enemies[x, y] == " O")
                    {
                        Console.WriteLine("Invalid Coordinte - Coordinate already attacked");
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Coordinte - Not within bounds");
                }

                Thread.Sleep(800);
            }
        }
        //attack
    }
}
