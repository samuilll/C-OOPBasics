using System;
using System.Collections.Generic;
using System.Text;


    class DateModifier
    {

    public static int CalculateTheDifference(string firstDate, string secondDate)
    {
        DateTime.TryParse(firstDate, out DateTime date1);
        DateTime.TryParse(secondDate, out DateTime date2);

        var difference = date1 - date2;


        return Math.Abs(difference.Days);
    }
    }

