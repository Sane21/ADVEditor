using System;

namespace HarapekoADV.Commands
{
    public class ErrorStrategy : CommandStrategy
    {
        private string[] _args;
        public void Initialise(string[] args)
        {
            _args = args;
        }
        public void Act(ADVPresenter presenter)
        {
            Debugger.Err(_args[0]);
        }
    }
}