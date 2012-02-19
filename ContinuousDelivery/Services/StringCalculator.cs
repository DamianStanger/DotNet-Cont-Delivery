using System;
using System.Collections.Generic;
using System.Linq;
using ContinuousDelivery.Models;

namespace ContinuousDelivery.Services
{
    public class StringCalculator
    {
        public int PerformAddition(string stringValues)
        {
            if (String.IsNullOrEmpty(stringValues))
            {
                return 0;
            }

            var values = new Translator(stringValues);
            return Calculate(values.AsInts);            
        }

        private int Calculate(IEnumerable<int> individualValues)
        {
            var negatives = individualValues.Where(x => x < 0).Select(x => x.ToString());
            if (negatives.Count()>0)
            {
                string exceptionText = "Negative numbers are not permitted: " + string.Join(", ", negatives);
                throw new ViewException(exceptionText);
            }
            return individualValues.Sum();
        }
    }
}