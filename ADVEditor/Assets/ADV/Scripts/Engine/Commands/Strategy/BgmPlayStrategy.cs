using UnityEngine;

namespace HarapekoADV.Commands
{
    public class BgmPlayStrategy : CommandStrategy
    {
        private bool _isPlay;
        private bool _isLoop;


        public void Initialise(string[] args)
        {
            _isPlay = false;
            _isLoop = false;
            if (args[1] == "TRUE" || args[1] == "True" || args[1] == "true")
            {
                _isPlay = true;
            }
            if (args[2] == "TRUE" || args[2] == "True" || args[2] == "true")
            {
                _isLoop = true;
            }

        }

        public void Act(ADVPresenter presenter)
        {
            presenter.Sound.PlayBGM(_isPlay, _isLoop);
        }
    }
}