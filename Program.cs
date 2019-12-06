using System;
using System.Collections;
using System.Collections.Generic;
using Solutions;

namespace aoc
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = args[0];
            var solutions = new Dictionary<string, ISolution>(){
                {"DayOne", new DayOne()},
                {"DayTwo", new DayTwo()}
            };

            Console.WriteLine($"{solutions[day].RunSolution()}");
        }
    }
}
