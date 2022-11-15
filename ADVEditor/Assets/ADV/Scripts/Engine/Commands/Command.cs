using System;
using UnityEngine;

namespace HarapekoADV.Commands
{
    public class Command
    {
        /// <summary>
        /// コマンドの種類　Enum/CommandType参照 
        /// </summary>
        private CommandType _commandType;
        public CommandType CommandType
        {
            get { return _commandType; }
        }
        public CommandStrategy _strategy;


        public Command(CommandType commandType, CommandStrategy strategy)
        {
            _commandType = commandType;
            _strategy = strategy;
        }

        public void Act(ADVPresenter presenter)
        {
            Debugger.Log("CMDTYPE : " + _commandType);
            _strategy.Act(presenter);

        }

        // 実行前に必要な変数などを用意できるようにしたい、StrategyでACTとそれを定義したInterfaceかな

    }
}