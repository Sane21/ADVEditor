using UnityEngine;
using HarapekoADV.Images;

namespace HarapekoADV.Commands
{
    public class ImagePlayStrategy : CommandStrategy
    {
        private string _name;
        private bool _isActive;

        public void Initialise(string[] args)
        {
            _name = args[1];
            if (args[2] == "TRUE" || args[2] == "True" || args[2] == "true")
            {
                _isActive = true;
            }
            else
            {
                _isActive = false;
            }
        }

        public void Act(ADVPresenter presenter)
        {
            presenter.Images.Activate(_name, _isActive);
            Debugger.Log("Played");
        }
    }
}