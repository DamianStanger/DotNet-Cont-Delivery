using System;

namespace ContinuousDelivery.Models
{
    public class ViewException : ApplicationException
    {
        public ViewException(string message) : base(message)
        {
        }
    }
}