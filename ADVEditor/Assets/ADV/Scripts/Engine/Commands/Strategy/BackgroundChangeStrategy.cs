using UnityEngine;
using HarapekoADV.Images;

namespace HarapekoADV.Commands
{
    public class BackgroundChangeStrategy : CommandStrategy
    {
        private string _name;
        public void Initialise(string[] args)
        {
            _name = args[1];

        }

        public void Act(ADVPresenter presenter)
        {
            var img = presenter.Images.GetBG(_name);
            if (img == null)
            {
                Debugger.Err("BG change error : not found " + _name);
                return;
            }
            presenter.View.SetBG(img);
            Debugger.Log("Addded");

        }
    }
}
