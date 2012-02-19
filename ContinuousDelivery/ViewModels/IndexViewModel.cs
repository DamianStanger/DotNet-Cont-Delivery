using System;

namespace ContinuousDelivery.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Result = 0;
            Exception = null;
        }

        public IndexViewModel(int result, Exception exception)
        {
            this.Result = result;
            this.Exception = exception;
        }

        public int Result { get; private set; }
        public Exception Exception { get; private set; }
    }
}