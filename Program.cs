using System;
using System.Linq;

namespace ticTacToe
{
    class Program
    {
        static readonly int n = 4;
        static readonly int forVin = 4;
        static string BuidStringHorizontalLine(int weight)
        {
            string line = "";
            for (int k = 0; k <= weight * 2; k++)
            {
                line += "—";
            } 
            return line;
        }
        static void Draw(int[,] field)
        {
            Console.Clear();
            for (int i = 0; i < field.GetLength(0); i++)
            {                  
                Console.WriteLine(BuidStringHorizontalLine(field.GetLength(1)));
                string row = "";      
                for (int j = 0; j < field.GetLength(1); j++)
                {                                        
                    if (field[i,j] == 1)
                    {
                        row += "|O";
                    }
                    else if (field[i,j] == -1)
                    {
                        row += "|X";
                    } 
                    else 
                    {
                        row += "| ";
                    }                    
                }
                Console.WriteLine(row + '|');
                if (i == field.GetLength(0) - 1)
                {
                    Console.WriteLine(BuidStringHorizontalLine(field.GetLength(1)));
                }
            }            
        }
        
        static bool IsVictory(int x, int y, int team, int[,] field)
        {            

            int counthorizontal = 0;
            bool r = true;
            bool l = true;
            int countVertical = 0;
            bool u = true;
            bool d = true;
            int countDiagonalLeft = 0;
            bool dlu = true;
            bool dld = true;
            int countDiagonalRight = 0;
            bool dru = true;
            bool drd = true;
            for (int i = 0; i < forVin; i++)
            {                   
                if (dlu && x - i >= 0 && y + i < field.GetLength(1) && field[x - i,y + i] == team)
                {
                    countDiagonalLeft++;
                }
                else 
                {
                    dlu = false;
                }
                if (dld &&  x + i < field.GetLength(0) && y - i >= 0 && field[x + i,y - i] == team)
                {
                    countDiagonalLeft++;
                }
                else 
                {
                    dld = false;
                }

                if (drd && x + i < field.GetLength(0) && y + i < field.GetLength(1) && field[x + i,y + i] == team)
                {
                    countDiagonalRight++;
                }
                else 
                {
                    drd = false;
                }
                if (dru && x - i >= 0 && y - i >= 0 && field[x - i,y - i] == team)
                {
                    countDiagonalRight++;
                }
                else 
                {
                    dru = false;
                }                
                if (r && x + i < field.GetLength(0) && field[x + i,y] == team)
                {
                    counthorizontal++;
                }
                else 
                {
                    r = false;
                }
                if (l && x - i >= 0 && field[x - i,y] == team)
                {
                    counthorizontal++;
                }
                else 
                {
                    l = false;
                }
                if (u && y + i < field.GetLength(1) && field[x,y + i] == team)
                {
                    countVertical++;
                }
                else 
                {
                    u = false;
                }
                if (d && y - i >= 0 && field[x,y - i] == team)
                {
                    countVertical++;
                }
                else 
                {
                    d = false;
                }

            }
            return counthorizontal > forVin || countVertical > forVin || countDiagonalRight > forVin || countDiagonalLeft > forVin; 
        }
        static void CheckInputCoordinates(ref int inputX, ref int inputY, int[,] field, int team)
        {
            do
            {            
                if (team == 1)
                {
                    Console.WriteLine("input coordinates of O");
                }
                else if (team == -1)
                {
                    Console.WriteLine("input coordinates of X");
                }
                string[] input = Console.ReadLine().Split(' ');
                inputX = Convert.ToInt32(input[0]);
                inputY = Convert.ToInt32(input[1]);
            }while(!(field[inputX, inputY] == 0));
        }
        static bool IsDraw(int checkRow, int[,] field)
        {
            return checkRow >= Math.Pow(field.GetLength(0),2);
        }
        static void Main(string[] args)
        {
            int[,] field = new int[n,n];
            int checkRow = 0;
            int inputX = 0;
            int inputY = 0;
            int team = 1;
            Draw(field);
            do
            {
                if (IsDraw(checkRow, field))
                {
                    team = 0;
                    break;
                }
                team = -team;
                //CheckInputCoordinates(ref inputX, ref inputY, field, team);                
                do
                {                                
                    string[] input = Console.ReadLine().Split(' ');
                    inputX = Convert.ToInt32(input[0]);
                    inputY = Convert.ToInt32(input[1]);
                } while(!(field[inputX, inputY] == 0));                
                checkRow++;
                field[inputX, inputY] = team;
                Draw(field);
                
            }
            while(!IsVictory(inputX,inputY,team,field));

            if (team == 0)
            {
                Console.WriteLine("Draw");
            }
            else if (team == 1)
            {
                Console.WriteLine(" \'O\' " + "victory");
            }
            else if (team == -1)
            {
                Console.WriteLine(" \'X\' " + "victory");
            }
        }
    }
}
