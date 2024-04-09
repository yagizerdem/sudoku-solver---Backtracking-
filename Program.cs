using System.Collections;
using System.Data;
using System.Runtime.InteropServices.JavaScript;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sudoku = new char[,]
        {
         { '5', '.', '.', '.', '7', '.', '.', '.', '.' },
        { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
        { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
        { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
        { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
        { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
        { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
        { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
        { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
};

            // taking input
            for (int i = 0; i <9; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int j = 0; j < 9; j++)
                {
                    sudoku[i, j] = row[j];
                }
            }
            ;
        

            bool dfs(char[,] board)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board[i,j] == '.')
                        {
                            for (char c = '1'; c <= '9'; c++)
                            {
                                if (check(board , i ,j, c))
                                {
                                    board[i,j] = c;
                                    if (dfs(board)) return true;
                                    else
                                    {
                                        board[i, j] = '.';
                                    }
                                }
                            }
                            return false;
                        }
                    }
                }

                return true;
            }


            bool check(char[,] board , int row , int col , char c)
            {
                for (int i = 0; i< 9; i++)
                {
                    if (board[row, i] == c) return false;
                    if (board[i, col] == c) return false;
                    //checking block
                    if (board[3*(row / 3) + i / 3 ,3* (col / 3) + i % 3]  == c) return false;
                }
                return true;
            }

            dfs(sudoku);

            bool flag = true;
            for (int i = 0; i <9; i++)
            {
                for (int j = 0; j <9; j++)
                {
                    if (sudoku[i,j] == '.')
                    {
                        flag = false;
                        break;
                    }
                }
                if (!flag) break;
            }

            if (!flag)
            {
                Console.WriteLine("impossible to solve");
                return;
            }



            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0)
                {
                    for (int k = 0; k < 31; k++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                }
                for (int j = 0; j <9; j++)
                {
                    if(j % 3 == 0)
                    {
                        Console.Write("|");
                    }
                    Console.Write(" " + sudoku[i, j] + " ");
                    if(j == 8)
                    {
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
                if(i == 8)
                {
                    for (int k = 0; k < 31; k++)
                    {
                        Console.Write("-");
                    }
                }
            }

        }
    }
}
