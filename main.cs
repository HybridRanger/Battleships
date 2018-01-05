using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesTable
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int size = 10;
                int[] ship_nums = new int[4];
                string[,] display = new string[10, 10];
                string[,] enemies = new string[10, 10];

                Grid_Size(ref size, ref display, ref enemies);
                Display(size, display);
                Select_Ships(size, ref ship_nums);
                //Place_Enemies(size, enemies);


                //Console.ReadLine();
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
                    Console.Write(display[y,x]);
                }
                Console.WriteLine();
            }
        }
        //display grid
        static void Place_Enemies(int size, string[,] enemies)
        {
            Boolean shipplaced = false;
            while (shipplaced == false)
            {
                int[,] ship = new int[4, 2];

                Random rnd = new Random();
                int x_1 = rnd.Next(size);
                int y_1 = rnd.Next(size);
                int y_2;
                int shiplength;

                if (enemies[y_1, x_1] == " -")
                {

                    ship[0, 0] = x_1;
                    ship[0, 1] = y_1;
                    int dir = rnd.Next(1, 5);


                    switch (dir)
                    {
                        case 1:



                            for (int i = 1; i < shiplength; i++)
                            {
                                y_2 = y_1 - i;
                                ship[i, 0] = x_1;
                                ship[i, 1] = y_2;

                            }

                            break;

                        case 2:

                            break;

                        case 3:

                            break;

                        case 4:

                            break;
                    }
                }

                Console.ReadLine();
            }
            {
            Boolean shipplaced = false;
            while (shipplaced == false)
                {

                Random rnd = new Random();
                int x_1 = rnd.Next(size);
                int y_1 = rnd.Next(size);

                if (enemies[y_1, x_1] == " -")
                {
                    int dir = rnd.Next(1, 5);

                    if (dir == 1)
                    {
                        int y_2 = y_1 - 1;
                        if (y_2 >= 0)
                        {
                            if (enemies[y_2, x_1] == " -")
                            {
                                enemies[y_2, x_1] = " #";
                                enemies[y_1, x_1] = " #";
                                shipplaced = true;
                            }
                        }


                    }
                    else if (dir == 2)
                    {

                    }
                    else if (dir == 3)
                    {

                    }
                    else if (dir == 4)
                    {

                    }
                }

            }

            Console.ReadLine();


        }
        //place enemies
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
