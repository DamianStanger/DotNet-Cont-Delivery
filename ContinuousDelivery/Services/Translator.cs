using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ContinuousDelivery.Services
{
    public class Translator
    {
        private readonly List<char> defaultDelimeters = new List<char>{',', '\n'};

        public Translator(string values)
        {
            ExtractNewDelimeter(values);
            AsInts = new List<int>();
            var stringIntegers = values.Split(defaultDelimeters.ToArray());
            foreach (var stringInteger in stringIntegers)
            {
                int tmp;
                Int32.TryParse(stringInteger, out tmp);
                AsInts.Add(tmp);
            }            

        }

        private void ExtractNewDelimeter(string values)
        {
            Regex delimeterFinder = new Regex("^//(.)");
            var match = delimeterFinder.Match(values);
            if (match.Success)
            {
                var delimeter = char.Parse(match.Groups[1].Value);
                defaultDelimeters.Add(delimeter);
            }
        }

        public List<int> AsInts { get; private set; }
    }
}