using UnityEngine;

namespace HarapekoADV.Commands
{
    public class BgmAddStrategy : CommandStrategy
    {
        private string _adress;
        private string _name;

        public void Initialise(string[] args)
        {
            _adress = args[1];
            _name = args[2];
        }
        public void Act(ADVPresenter presenter)
        {
            AudioClip clip = AssetLoader.Load<AudioClip>(_adress);
            presenter.Sound.AddClip(_name, clip);
        }
    }
}