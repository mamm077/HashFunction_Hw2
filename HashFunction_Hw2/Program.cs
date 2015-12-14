using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HashFunction_Hw2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimiter = { ' ' };
            List<int> ParseInput;
            Hashtable myHash = new Hashtable();
            bool isNumber = true;
            do
            {
                Console.Write("Input : ");
                string input = Console.ReadLine();

                string[] splitinput = input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                ParseInput = new List<int>();

                if (splitinput.Length > 100)
                {
                    Console.WriteLine("Error the number you inputed are over 100 number. Please, Try again");
                    isNumber = false;
                }
                else
                {
                    foreach (string item in splitinput)
                    {
                        int num = 0;
                        isNumber = int.TryParse(item, out num);
                        if (!isNumber)
                        {
                            Console.WriteLine("Error There is not a number");
                            break;
                        }
                        else if (num > 1000)
                        {
                            Console.WriteLine("Error This program is not accept number over 1000. Please,Try Again");
                            isNumber = false;
                            break;
                        }
                        else if (num < 0)
                        {
                            Console.WriteLine("Error This program is not accept number less than zero. Please Try Again");
                            isNumber = false;
                            break;
                        }
                        else
                            ParseInput.Add(num);
                    }

                }
            } while (!isNumber);

            //add all item into hash
            if (ParseInput.Count > 0)
            {
                foreach (int item2 in ParseInput)
                {
                    //calculate key
                    int key = item2 % 50;
                    
                    //if there is no key --> add new one else concat item
                    if (!myHash.ContainsKey(key))
                    {
                        myHash.Add(key, item2.ToString());
                    }
                    else
                    {
                        myHash[key] = myHash[key] + " " + item2.ToString();
                    }
                }
            }

            Console.WriteLine("Output");
            //print 1 - 50 hash
            for (int i = 0; i < 50; i++)
            {
                if (myHash.ContainsKey(i))
                    Console.WriteLine(i + " : " + myHash[i]);
                else
                    Console.WriteLine(i + " :");
            }

            Console.ReadKey();
        }
    }
}
