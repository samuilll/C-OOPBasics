using System;
using System.Collections.Generic;
using System.Linq;

class Task09RectangleInterSection
{
    static void Main(string[] args)
    {
        var cmdArgs = Console.ReadLine().Split();
        var rectanglesData = new Dictionary<string, Rectangle>();
        var rectanglesCount = int.Parse(cmdArgs[0]);
        var checksNumber = int.Parse(cmdArgs[1]);

        DataStore(cmdArgs, rectanglesData, rectanglesCount);

        CheckForIntersectionAndPrint(rectanglesData, checksNumber);
    }

    private static void CheckForIntersectionAndPrint(Dictionary<string, Rectangle> rectanglesData, int checksNumber)
    {
        
            for (int i = 0; i < checksNumber; i++)
            {
                var input = Console.ReadLine().Split();

                var firstId = input[0];
                var secondId = input[1];
            if (rectanglesData.ContainsKey(firstId) && rectanglesData.ContainsKey(secondId))
            {
                var firstRectangle = rectanglesData[firstId];
                var secondRectangle = rectanglesData[secondId];
                Console.WriteLine(Rectangle.IsIntersected(firstRectangle, secondRectangle).ToString().ToLower());
            }
            }
        
    }

    private static void DataStore(string[] cmdArgs, Dictionary<string, Rectangle> rectanglesData, int rectanglesCount)
    {
        for (int i = 0; i < rectanglesCount; i++)
        {
            var input = Console.ReadLine().Split();

            var id = input[0];

            var width = decimal.Parse(input[1]);
            var height = decimal.Parse(input[2]);
            var x = decimal.Parse(input[3]);
            var y = decimal.Parse(input[4]);

            rectanglesData[id] = new Rectangle(id, width, height, x, y);
        }
    }
}

