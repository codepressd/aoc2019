using System;
using Helpers;

namespace Solutions
{
    public class DayOne : ISolution
    {
        public int RunSolution()
        {
            var readFile = new ReadFile();
            string[] fileArray = readFile.ReturnStringArray("day1.txt");

            int totalFuel = 0;

            for (int x = 0; x < fileArray.Length; x++)
            {
                int total = calcAllFuel(Int32.Parse(fileArray[x]), 0);
                totalFuel += total;
            }
            return totalFuel;
        }

        private int calcAllFuel(int number, int allFuel)
        {
            int fuel = number / 3 - 2;
            return fuel >= 0 ? calcAllFuel(fuel, allFuel + fuel) : allFuel;
        }
    }
}