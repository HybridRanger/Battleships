using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;

            Boolean correct = false;

            while (correct == false)
            {
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
                        //goto guessing practice
                        correct = true;
                        break;
                    case 2:
                        Console.Clear();
                        //goto player vs AI
                        correct = true;
                        break;
                    case 3:
                        Console.Clear();
                        //goto 2 player
                        correct = true;
                        break;
                    case 4:
                        Console.Clear();
                        //goto settings
                        correct = true;
                        break;
                    case 5:
                        Console.Clear();
                        //quit
                        System.Environment.Exit(0);
                        break;

                }
            }
            while (true)
            {
                int size = 10;
                int[] ship_nums = new int[4];
                ship_nums[0] = 1;
                ship_nums[1] = 2;
                ship_nums[2] = 1;
                ship_nums[3] = 1;
                string[,] display = new string[10, 10];
                string[,] enemies = new string[10, 10];

                Grid_Size(ref size, ref display, ref enemies);
                //Display(size, display);
                //Select_Ships(size, ref ship_nums);
                Place_Enemies(size, enemies, ship_nums);
                for (int x = 0; x < size; x++)
                {

                    for (int y = 0; y < size; y++)
                    {
                        Console.Write(enemies[y, x]);
                    }
                    Console.WriteLine();
                }

                Console.ReadLine();
            }
        }

        static void Grid_Size(ref int size, ref string[,] display, ref string[,] enemies)
        {
            size = Convert.ToInt32(Console.ReadLine());
            string[,] _display = new string[size, size];
            for (int x = 0; x < size; x++)
            {

                for (int y = 0; y < size; y++)
                {
                    _display[y, x] = " -";
                }
            }
            display = _display;
            enemies = _display;
        }
        //set grid size
        static void Display(int size, string[,] display)
        {
            for (int x = 0; x < size; x++)
            {

                for (int y = 0; y < size; y++)
                {
                    Console.Write(display[y, x]);
                }
                Console.WriteLine();
            }
        }
        //display grid
        static void Place_Enemies(int size, string[,] enemies, int[] ship_nums)
        {
            for (int length = 2; length <= 5; length++)
            {
                for (int a = 1; a <= ship_nums[length - 2]; a++)
                {

                    int[,] temp = new int[2, 5];
                    Boolean ship_placed = false;

                    while (ship_placed == false)
                    {
                        Random rnd = new Random();
                        int x = rnd.Next(size);
                        int y = rnd.Next(size);
                        int dir = rnd.Next(1, 5);
                        for (int i = 0; i <= length - 1; i++)
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
                            } else if (enemies[temp[1, i], temp[0, i]] == " #")
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
        static void Enemy_Coords(ref int length, Boolean ship_placed, int[,] temp)
        {

        }
        static void Attack()
        {

        }
        //attack
        static void Select_Ships(int size, ref int[] ship_nums)
        {
            Boolean exit = false;
            double ships = Math.Ceiling(((double)size / 5) * 3);

            while (exit == false)
            {
                for (int i = 2; i < 6; i++)
                {
                    //Console.Clear();
                    Console.WriteLine("Ships left - " + ships);
                    Console.Write(i + " long - ");
                    ship_nums[i - 2] = Convert.ToInt32(Console.ReadLine());
                    ships = ships - ship_nums[i - 2];
                    for (int a = 0; a < 3; a++)
                    {
                        Console.WriteLine(ship_nums[a]);
                    }
                }
            }
        }
        //select ships
    }
}
