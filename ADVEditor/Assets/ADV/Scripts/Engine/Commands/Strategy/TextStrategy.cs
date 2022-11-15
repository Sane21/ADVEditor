using System;
namespace HarapekoADV.Commands
{
    public class TextStrategy : CommandStrategy
    {
        private string[] _args;
        public void Initialise(string[] args)
        {
            _args = args;
        }

        public void Act(ADVPresenter presenter)
        {
            // テキストの表示を変えて、ログに登録する
            presenter.View.SetText(_args[0]);
            // Debugger.Log("TEXT : " + _args[0]);
        }
    }
}