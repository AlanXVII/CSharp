using ExcelDna.Integration;
using QLNet;
using System;
using System.Collections.Generic;
using System.IO;

namespace UDFLib
{
    public class Quants
    {
        [ExcelFunction(Name = "Quants.BlackScholesEuropean", Description = "The Black-Scholes Option Price for European Options")]
        public static double BSE([ExcelArgument("Spot Price of Underlying")] double spot, [ExcelArgument("Strike Price")] double strike,
            [ExcelArgument("Risk-Free Rate")] double rfr, [ExcelArgument("Annualised Volatility")] double vol, [ExcelArgument("Time to Maturity")] double tenor,
            [ExcelArgument("Option Type")] string opt_type)
        {
            var d_1 = (Math.Log(spot / strike) + (rfr + Math.Pow(vol, 2) / 2) * (tenor)) / (vol * Math.Sqrt(tenor));
            var d_2 = (d_1 - vol * Math.Sqrt(tenor));
            var NormINV = new CumulativeNormalDistribution(0, 1);

            if (opt_type == "Put")
                return strike * Math.Pow(Math.E, -rfr * tenor) * NormINV.value(-d_2) - spot * NormINV.value(-d_1);
            else if (opt_type == "Call")
                return spot * NormINV.value(d_1) + strike * Math.Pow(Math.E, -rfr * tenor) * NormINV.value(d_2);
            else
                return 0;
        }

        [ExcelFunction(Name = "Quants.BS_Greeks", Description = "The Black-Scholes Greeks")]
        public static double Greeks([ExcelArgument("Spot Price of Underlying")] double spot, [ExcelArgument("Strike Price")] double strike,
            [ExcelArgument("Risk-Free Rate")] double rfr, [ExcelArgument("Annualised Volatility")] double vol, [ExcelArgument("Time to Maturity")] double tenor,
            [ExcelArgument("Option Type")] string opt_type, [ExcelArgument("Option Type")] string greeks_type)
        {
            var d_1 = (Math.Log(spot / strike) + (rfr + Math.Pow(vol, 2) / 2) * (tenor)) / (vol * Math.Sqrt(tenor));
            var d_2 = (d_1 - vol * Math.Sqrt(tenor));
            var NormINV = new CumulativeNormalDistribution(0, 1);

            if (opt_type == "Put")
            {
                if (greeks_type == "Delta")
                    return -Math.Pow(Math.E, -rfr * tenor) * NormINV.value(d_1);
                else if (greeks_type == "Gamma")
                    return (Math.Pow(Math.E, -rfr * tenor) * NormINV.value(d_1)) / spot * vol * Math.Sqrt(tenor);
                else
                    return 0;
            }
            else if (opt_type == "Call")
            {
                if (greeks_type == "Delta")
                    return Math.Pow(Math.E, -rfr * tenor) * NormINV.value(d_1);
                else if (greeks_type == "Gamma")
                    return (Math.Pow(Math.E, -rfr * tenor) * NormINV.value(d_1)) / spot * vol * Math.Sqrt(tenor);
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }
    }

    public class Utils
    {
        [ExcelFunction(Name = "Utils.FileExists", Description = "Function that checks if a file exists based on the provided file path")]
        public static bool FileExists([ExcelArgument("Spot Price of Underlying")] string filepath)
        {
            return File.Exists(filepath);
        }

        [ExcelFunction(Name = "Utils.SubtractBusDays", Description = "Subtracts number of Business Days from specific date and return date")]
        public static Date SubtractBusDays([ExcelArgument("Supplied Date")] DateTime cur_date, [ExcelArgument("Number of Days")] int days)
        {
            for (int iter = 0; iter <= days; iter++)
            {
                cur_date = cur_date.AddDays(-1);

                while (IsBusDay(cur_date) == false)
                {
                    cur_date = cur_date.AddDays(-1);
                }
            }

            return cur_date.Date;
        }

        [ExcelFunction(Name = "Utils.IsBusDay", Description = "Checks if given date is a business day based of ZAR Banking Calendar")]
        public static bool IsBusDay([ExcelArgument("Supplied Date")] DateTime inputdate)
        {
            //creating a dictionary using collection-initializer syntax
            bool isbusday;
            IList<DateTime> holidays = new List<DateTime>()
            {
                new DateTime(1,1,2020), new DateTime(1,2,2020)
            };           

            switch (inputdate.DayOfWeek)
            {
                case DayOfWeek.Saturday | DayOfWeek.Sunday:
                    isbusday = false;
                    break;
                default:
                    isbusday = true;
                    break;
            }

            foreach (DateTime day in holidays)
                if (inputdate.Date == day.Date)
                    isbusday = false;
            
            return isbusday;
        }
    }


}

