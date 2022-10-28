using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Tromino
    {
        class twobytwo
        {
            static int cnt = 0;
            int size_of_grid = 128, b, a;
            static int[,] arr = new int[128, 128];

            // Placing tile at the given coordinates
            static void place(int x1, int y1, int x2,
                      int y2, int x3, int y3)
            {
                if (arr[x1, y1] == 0 && arr[x2, y2] == 0 && arr[x3, y3] == 0)
                {
                    cnt++;
                    arr[x1, y1] = cnt;
                    arr[x2, y2] = cnt;
                    arr[x3, y3] = cnt;
                }
            }
            static void divideandconquer(int n, int x, int y)
            {
                int r = 0, c = 0;
                if (n == 2)
                {
                    cnt++;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (arr[x + i, y + j] == 0)
                            {
                                arr[x + i, y + j] = cnt;
                            }
                        }
                    }
                    return;
                }

                // finding hole location
                for (int i = x; i < x + n; i++)
                {
                    for (int j = y; j < y + n; j++)
                    {
                        if (arr[i, j] != 0)
                        {
                            r = i;
                            c = j;
                        }

                    }
                }

                // If missing tile is 1st quadrant
                if (r < x + n / 2 && c < y + n / 2)
                    place(x + n / 2, y + (n / 2) - 1, x + n / 2,
                          y + n / 2, x + n / 2 - 1, y + n / 2);

                // If missing Tile is in 3rd quadrant
                else if (r >= x + n / 2 && c < y + n / 2)
                    place(x + (n / 2) - 1, y + (n / 2), x + (n / 2),
                          y + n / 2, x + (n / 2) - 1, y + (n / 2) - 1);

                // If missing Tile is in 2nd quadrant
                else if (r < x + n / 2 && c >= y + n / 2)
                    place(x + n / 2, y + (n / 2) - 1, x + n / 2,
                          y + n / 2, x + n / 2 - 1, y + n / 2 - 1);

                // If missing Tile is in 4th quadrant
                else if (r >= x + n / 2 && c >= y + n / 2)
                    place(x + (n / 2) - 1, y + (n / 2), x + (n / 2),
                          y + (n / 2) - 1, x + (n / 2) - 1,
                          y + (n / 2) - 1);

                // diving it again in 4 quadrants
                divideandconquer(n / 2, x, y + n / 2);
                divideandconquer(n / 2, x, y);
                divideandconquer(n / 2, x + n / 2, y);
                divideandconquer(n / 2, x + n / 2, y + n / 2);
                return;
            }
            static void tile(int n, int x, int y)
            {
                int r = 0, c = 0;
                if (n == 2)
                {
                    cnt++;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (arr[x + i, y + j] == 0)
                            {
                                arr[x + i, y + j] = cnt;
                            }
                        }
                    }
                    return;
                }

                // finding hole location
                for (int i = x; i < x + n; i++)
                {
                    for (int j = y; j < y + n; j++)
                    {
                        if (arr[i, j] != 0)
                        {
                            r = i;
                            c = j;
                        }

                    }
                }

                // If missing tile is 1st quadrant
                if (r < x + n / 2 && c < y + n / 2)
                {
                    place(x + n / 2, y + (n / 2) - 1, x + n / 2,
                          y + n / 2, x + n / 2 - 1, y + n / 2);
                    if ((n / 2) > 8)
                    {
                        tile(n / 2, x, y);
                    }
                    divideandconquer(n / 2, x, y + n / 2);
                    divideandconquer(n / 2, x + n / 2, y);
                    divideandconquer(n / 2, x + n / 2, y + n / 2);
                }
                // If missing Tile is in 3rd quadrant
                else if (r >= x + n / 2 && c < y + n / 2)
                {
                    place(x + (n / 2) - 1, y + (n / 2), x + (n / 2),
                          y + n / 2, x + (n / 2) - 1, y + (n / 2) - 1);
                    if ((n / 2) > 8)
                    {
                        tile(n / 2, x + n / 2, y);
                    }
                    divideandconquer(n / 2, x, y + n / 2);
                    divideandconquer(n / 2, x, y);
                    divideandconquer(n / 2, x + n / 2, y + n / 2);
                }

                // If missing Tile is in 2nd quadrant
                else if (r < x + n / 2 && c >= y + n / 2)
                {
                    place(x + n / 2, y + (n / 2) - 1, x + n / 2,
                          y + n / 2, x + n / 2 - 1, y + n / 2 - 1);
                    if ((n / 2) > 8)
                    {
                        tile(n / 2, x, y + n / 2);
                    }
                    divideandconquer(n / 2, x + n / 2, y);
                    divideandconquer(n / 2, x, y);
                    divideandconquer(n / 2, x + n / 2, y + n / 2);
                }

                // If missing Tile is in 4th quadrant
                else if (r >= x + n / 2 && c >= y + n / 2)
                {
                    place(x + (n / 2) - 1, y + (n / 2), x + (n / 2),
                          y + (n / 2) - 1, x + (n / 2) - 1,
                          y + (n / 2) - 1);
                    if ((n / 2) > 8)
                    {
                        tile(n / 2, x + n / 2, y + n / 2);

                    }
                    divideandconquer(n / 2, x + n / 2, y);
                    divideandconquer(n / 2, x, y);
                    divideandconquer(n / 2, x, y + n / 2);
                }

                // return 0;
            }

            public static void GetSq(int size, int sqX, int sqY)
            {
                if (sqX + 1 >= size || sqX < 0 || sqX >= size || sqY < 0 || sqY >= size || sqY + 1 >= size)
                {
                    Console.WriteLine("Square cannot be placed in this location");
                    return;
                }
                arr[sqX, sqY] = -1;
                arr[sqX + 1, sqY] = -1;
                arr[sqX, sqY + 1] = -1;
                arr[sqX + 1, sqY + 1] = -1;
                

                if ((sqX % 4 == sqY % 4) || (sqX % 4 == 0 && sqY % 4 == 2) || (sqX % 4 == 2 && sqY % 4 == 0))
                {

                    tile(size, 0, 0);
                    for (int i = 0; i < size; i = i + 4)
                    {
                        for (int j = 0; j < size; j = j + 4)
                        {
                            if (sqX >= j + 4 || sqY >= i + 4)
                            {

                            }
                            else
                            {
                                // sqX and sqY in the range of i & j 
                                //build the square
                                if (sqX % 4 == 0 && sqY % 4 == 0)
                                {
                                    tile(8, sqX - (sqX % 8), sqY - (sqY % 8));
                                    place(sqX + 1, sqY + 2, sqX + 2, sqY + 2, sqX + 2, sqY + 1);
                                    place(sqX + 2, sqY, sqX + 3, sqY, sqX + 3, sqY + 1);
                                    place(sqX + 3, sqY + 2, sqX + 3, sqY + 3, sqX + 2, sqY + 3);
                                    place(sqX, sqY + 2, sqX, sqY + 3, sqX + 1, sqY + 3);

                                }
                                else if (sqX % 4 == 2 && sqY % 4 == 2)
                                {
                                    tile(8, sqX - (sqX % 8), sqY - (sqY % 8));
                                    place(sqX, sqY - 1, sqX - 1, sqY - 1, sqX - 1, sqY);
                                    place(sqX - 1, sqY + 1, sqX - 2, sqY + 1, sqX - 2, sqY);
                                    place(sqX, sqY - 2, sqX + 1, sqY - 2, sqX + 1, sqY - 1);
                                    place(sqX - 2, sqY - 1, sqX - 2, sqY - 2, sqX - 1, sqY - 2);
                                }
                                else if (sqX % 4 == 0 && sqY % 4 == 2)
                                {
                                    tile(8, sqX - (sqX % 8), sqY - (sqY % 8));
                                    place(sqX + 1, sqY - 1, sqX + 2, sqY - 1, sqX + 2, sqY);
                                    place(sqX + 2, sqY + 1, sqX + 3, sqY + 1, sqX + 3, sqY);
                                    place(sqX + 3, sqY - 1, sqX + 3, sqY - 2, sqX + 2, sqY - 2);
                                    place(sqX, sqY - 1, sqX, sqY - 2, sqX + 1, sqY - 2);
                                }
                                else if (sqX % 4 == 2 && sqY % 4 == 0)
                                {
                                    tile(8, sqX - (sqX % 8), sqY - (sqY % 8));
                                    place(sqX - 1, sqY + 1, sqX - 1, sqY + 2, sqX, sqY + 2);
                                    place(sqX + 1, sqY + 2, sqX + 1, sqY + 3, sqX, sqY + 3);
                                    place(sqX - 1, sqY + 3, sqX - 2, sqY + 3, sqX - 2, sqY + 2);
                                    place(sqX - 2, sqY + 1, sqX - 2, sqY, sqX - 1, sqY);
                                }
                                else if (sqX % 4 == 1 && sqY % 4 == 1)
                                {
                                    tile(8, sqX - (sqX % 8), sqY - (sqY % 8));
                                    place(sqX - 1, sqY, sqX - 1, sqY - 1, sqX, sqY - 1);
                                    place(sqX + 1, sqY - 1, sqX + 2, sqY - 1, sqX + 2, sqY);
                                    place(sqX - 1, sqY + 1, sqX - 1, sqY + 2, sqX, sqY + 2);
                                    place(sqX - 1, sqY + 2, sqX + 2, sqY + 2, sqX + 2, sqY + 1);
                                }
                                else if (sqX % 4 == 3 && sqY % 4 == 3)
                                {
                                    divideandconquer(8, sqX - 3, sqY - 3);
                                }
                            }
                        }

                    }
                }
                else
                {
                    // the problem has no sol
                    Console.WriteLine("Problem cannot be solved");
                    return;
                }
                return;
            }
            static void Main()
            {

                // size of box
                int size = 4;
                int gridSize = (int)Math.Pow(2, size);

                // Coordinates which will be marked
                Console.WriteLine("Enter the coordinates of the square");
                Console.WriteLine("Enter the x coordinate");
                int xSq = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the y coordinate");
                int ySq = Convert.ToInt32(Console.ReadLine());



                GetSq(gridSize, ySq, xSq);

                // The grid is
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                        Console.Write(arr[i, j] + "   |   ");
                    Console.WriteLine();
                }
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
