using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tikTacToe
{
    class Program
    {
        public static char player = 'O';
        public static bool gameOver = false;

        static void Main(string[] args)
        {
            char[] field = new char[9];

            Setup(field);

            while (!gameOver)
            {
                Print(field);
                Input(field, false);
                Logic(field);
                Toggle();
                Console.Clear();
            }
            Toggle();
            Console.WriteLine($"{player} wins!");

            Console.ReadLine();
        }

        static void Setup(char[] field)
        {
            for (int i = 0; i < field.Length; ++i)
            {
                string symbol = (i + 1).ToString();
                field[i] = symbol[0];
            }
        }

        static void Print(char[] field)
        {
            for (int i = 1; i <= field.Length; ++i)
            {
                Console.Write(field[i - 1]);
                if (i % 3 == 0)
                    Console.WriteLine();
            }
        }

        static void Toggle()
        {
            if (player == 'O')
                player = 'X';
            else
                player = 'O';
        }

        static void Logic(char[] field)
        {
            // horizontal case
            if (field[0] == player && field[1] == player && field[2] == player)
                gameOver = true;
            else if(field[3] == player && field[4] == player && field[5] == player)
                gameOver = true;
            else if (field[6] == player && field[7] == player && field[8] == player)
                gameOver = true;
            // vertical case
            else if (field[0] == player && field[3] == player && field[6] == player)
                gameOver = true;
            else if (field[1] == player && field[4] == player && field[7] == player)
                gameOver = true;
            else if (field[2] == player && field[5] == player && field[8] == player)
                gameOver = true;
            // deagonal case
            else if (field[0] == player && field[4] == player && field[8] == player)
                gameOver = true;
            else if (field[2] == player && field[4] == player && field[6] == player)
                gameOver = true;
        }
        static void Input(char[] field, bool correct)
        {
            Console.Write("Enter position: ");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                if (field[choice - 1] != 'X' && field[choice - 1] != 'O')
                {
                    field[choice - 1] = player;
                    correct = true;
                }
                else
                {
                    Console.WriteLine("Current position already in use. Try again!");
                    Input(field, correct);
                }
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Index out of range!");
                Input(field, correct);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid format");
                Input(field, correct);
            }
        }
    }
}
