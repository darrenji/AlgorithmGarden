using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGarden.Algorithms.Common
{
    public class TimeConverHelper
    {
        public static long ConvertToLong(DateTime time)
        {
            return time.Ticks;
        }

        public static DateTime ConvertToTimeFromLong(long ticks) 
        {
            return new DateTime(ticks);
        }

        public static DateTime ConvertToTimeFromStr(string str)
        {
            DateTime now;
            if(DateTime.TryParse(str, out now))
            {
                return now;
            }
            else
            {
                return DateTime.Now;
            }
        }
    }
}
