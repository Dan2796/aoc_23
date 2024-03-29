﻿using AOC2023.Days.Day01;
using AOC2023.Days.Day02;
using AOC2023.Days.Day04;
using AOC2023.Days.Day05;
using AOC2023.Days.Day06;
using AOC2023.Days.Day07;
using AOC2023.Days.Day08;
using AOC2023.Days.Day09;

namespace AOC2023;

internal class Program
{
    public static void Main(string[] args)
    {
        var dayRequested = 0;
        try
        {
            dayRequested = int.Parse(args[0]);
        }
        catch (Exception)
        {
            Console.WriteLine("Please supply the number of the day you wish to access, between 1 and 25.");
        }
        RunDay(dayRequested);
    }
    private static void RunDay(int dayRequested)
    {
        switch (dayRequested)
        {
            case < 1 or > 25:
                Console.WriteLine("Please supply a valid AOC day, from between 1 and 25.");
                return;
            case 1:
                Day<List<(int, int)>, int, List<(int, int)>, int> day01 = new Day01();
                day01.CompletePart1("Inputs/Day01.txt");
                day01.CompletePart2("Inputs/Day01.txt");
                break;
            case 2:
                Day<List<Game>, int, List<Game>, int> day02 = new Day02();
                day02.CompletePart1("Inputs/Day02.txt");
                day02.CompletePart2("Inputs/Day02.txt");
                break;
            case 4:
                Day<List<ScratchCard>, int, List<ScratchCard>, int> day04 = new Day04();
                day04.CompletePart1("Inputs/Day04.txt");
                day04.CompletePart2("Inputs/Day04.txt");
                break;
            case 5:
                Day<Almanac, long, Almanac, long> day05 = new Day05();
                day05.CompletePart1("Inputs/Day05.txt");
                day05.CompletePart2("Inputs/Day05.txt");
                break;
            case 6:
                Day<List<Race>, long, Race, long> day06 = new Day06();
                day06.CompletePart1("Inputs/Day06.txt");
                day06.CompletePart2("Inputs/Day06.txt");
                break;
            case 7:
                var day07 = new Day07();
                day07.CompletePart1("Inputs/Day07.txt");
                day07.CompletePart2("Inputs/Day07.txt");
                break;
            case 8:
                Day<CamelMaps, int, CamelMaps, long> day08 = new Day08();
                day08.CompletePart1("Inputs/Day08.txt");
                day08.CompletePart2("Inputs/Day08.txt");
                break;
            case 9:
                var day09 = new Day09();
                day09.CompletePart1("Inputs/Day09.txt");
                day09.CompletePart2("Inputs/Day09.txt");
                break;
            default:
                Console.WriteLine("Sorry, I haven't yet completed day " + dayRequested);
                return;
        }
    }
}
