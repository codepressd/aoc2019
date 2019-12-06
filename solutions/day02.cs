using System;
using System.Linq;
using System.Collections.Generic;
using Helpers;

namespace Solutions
{
    public class DayTwo : ISolution
    {
        private int noun;
        private int verb;
        public int RunSolution()
        {
            var readFile = new ReadFile();
            var fileArray = readFile.ReturnStringArray("day2.txt");
            var numArray = fileArray[0].Split(",").Select(Int32.Parse).ToList();


            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    var newNumArray = AddToArray(i, j, numArray);
                    var solved = SolveIt(newNumArray)[0];
                    Console.WriteLine($"{solved}");
                    if (solved == 19690720)
                    {
                        noun = newNumArray[1];
                        verb = newNumArray[2];
                        break;
                    }
                }
            }
            return 100 * noun + verb;
        }
        // Basura
        private List<int> AddToArray(int firstNum, int secondNum, List<int> theList)
        {
            var newList = new List<int>(theList);
            newList[1] = firstNum;
            newList[2] = secondNum;
            return newList;
        }

        private List<int> SolveIt(List<int> data)
        {
            var finalArray = new List<int>(data);

            for (int s = 0; s < data.Count; s += 4)
            {
                var range = data.GetRange(s, 4);
                var value = calcInputs(range[0], range[1], range[2]);
                Console.WriteLine($"{value}");
                if (value < 0)
                {
                    Console.WriteLine("fires");
                    break;
                }
                else
                {
                    finalArray[range[3]] = value;
                }

            }

            return finalArray;
        }

        private int calcInputs(int operation, int input1, int input2)
        {
            switch (operation)
            {
                case 1:
                    return input1 + input2;
                case 2:
                    return input1 * input2;
                case 99:
                    return -1;
                default:
                    return -1;
            }
        }

    }
}