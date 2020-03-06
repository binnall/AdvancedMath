using System;
using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;

namespace MathCalculations
{
    public class Calculations : CodeActivity
    {
        [RequiredArgument]
        [Input("Double input for the log input")]
        public InArgument<double> LogInput { get; set; }

        [RequiredArgument]
        [Input("Double for the raised to power")]
        public InArgument<double> RaisedToPower { get; set; }

        [RequiredArgument]
        [Input("Double Input for the power to be raised by")]
        public InArgument<double> Power { get; set; }

        [Output("Double output for the log")]
        public OutArgument<double> LogOutput { get; set; }

        [Output("Double output for the power")]
        public OutArgument<double> PowerOutput { get; set; }



        protected override void Execute(CodeActivityContext context)
        {
            double logInput = LogInput.Get(context);
            double powInput = RaisedToPower.Get(context);
            double power = Power.Get(context);

            double logRes = CalculateLog(logInput);
            double powRes = CalculatePower(powInput, power);

            LogOutput.Set(context, logRes);
            PowerOutput.Set(context, powRes);
        }

        public static double CalculateLog(double input) 
        {
            return Math.Log10(input);
        }

        public static double CalculatePower(double input, double power)
        {
            return Math.Pow(input, power);
        }
    }
}