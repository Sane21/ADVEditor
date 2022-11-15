using UnityEngine;

namespace HarapekoADV.Commands
{
    public class SePlayStrategy : CommandStrategy
    {
        private string _name;


        public void Initialise(string[] args)
        {
            _name = args[1];

        }

        public void Act(ADVPresenter presenter)
        {
            presenter.Sound.PlaySE(_name);
        }
    }
}