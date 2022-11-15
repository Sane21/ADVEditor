using UnityEngine;
using System;

namespace HarapekoADV.Commands
{
    public class EndStrategy : CommandStrategy
    {
        public void Initialise(string[] args)
        {

        }
        public void Act(ADVPresenter presenter)
        {
            Debugger.Log("おわりだよ～");
            presenter.Sound.PlayBGM(false, true);
            presenter.gameObject.SetActive(false);
            // Modelを終了状態にできるようにPresenterあたりとなんやかんやできるようにしたい
        }
    }
}