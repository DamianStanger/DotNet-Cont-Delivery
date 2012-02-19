using System;

namespace ContinuousDelivery.Models
{
    public class IndexViewException : ApplicationException
    {
        public IndexViewException(string message) : base(message)
        {
        }
    }
}