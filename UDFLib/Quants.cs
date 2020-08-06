using System;
using ExcelDna.Integration;
using QLNet;

namespace UDFLib
{
    public class Quants
    {
        [ExcelFunction(Name = "BlackScholesEuropean", Description = "Black_Scholes Price For Vanilla European Option")]
        public static double BSE([ExcelArgument("Spot Price of Underlying")] double spot, [ExcelArgument("Strike Price")] double strike,
            [ExcelArgument("Risk-Free Rate")] double rfr, [ExcelArgument("Annualised Volatility")] double vol, [ExcelArgument("Time to Maturity")] double tenor,
            [ExcelArgument("Option Type")] string opt_type)
        {
            double d_1 = (Math.Log(spot / strike) + (rfr + Math.Pow(vol, 2) / 2) * (tenor)) / (vol * Math.Sqrt(tenor));
            double d_2 = (d_1 - vol * Math.Sqrt(tenor));

            // Inverse of the Cumulative Standard Normal Distribution Function
            var NormINV = new CumulativeNormalDistribution(0, 1);
            NormINV.value(d_1);

            if (opt_type == "Put")
                return strike * Math.Pow(Math.E, -rfr * tenor) * NormINV.value(-d_2) - spot * NormINV.value(-d_1);
            else if (opt_type == "Call")
                return spot * NormINV.value(d_1) + strike * Math.Pow(Math.E, -rfr * tenor) * NormINV.value(d_2);
            else
                return 0;
        }
    }
}

