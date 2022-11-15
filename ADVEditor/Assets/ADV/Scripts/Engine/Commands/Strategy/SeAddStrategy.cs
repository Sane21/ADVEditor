using UnityEngine;

namespace HarapekoADV.Commands
{
    public class SeAddStrategy : CommandStrategy
    {
        private BgmAddStrategy _strategy;

        public void Initialise(string[] args)
        {
            _strategy = new BgmAddStrategy();
            _strategy.Initialise(args);
        }
        public void Act(ADVPresenter presenter)
        {
            _strategy.Act(presenter);
        }
    }
}