using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ContinuousDelivery.Services
{
    public class Translator
    {
        private readonly List<char> defaultDelimeters = new List<char>{',', '\n'};

        public Translator(string values)
        {
            values = ExtractNewDelimeter(values);
            AsInts = new List<int>();
            var stringIntegers = values.Split(defaultDelimeters.ToArray());         
            AsInts.AddRange(stringIntegers.Select(x => int.Parse(x)));
        }

        private string ExtractNewDelimeter(string values)
        {
            Regex delimeterFinder = new Regex("^//(.)");
            var match = delimeterFinder.Match(values);
            if (match.Success)
            {
                var delimeter = char.Parse(match.Groups[1].Value);
                defaultDelimeters.Add(delimeter);
                return values.Substring(4);
            }
            return values;
        }

        public List<int> AsInts { get; private set; }
    }
}