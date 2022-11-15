using System;
using HarapekoADV.Commands;

namespace HarapekoADV.Scenarios
{
    /// <summary>
    /// ADV View上になにかしらのコマンドを実行する
    /// 画像の移動とかフォントの変更とか
    /// 
    /// コマンドの特定までここでできるようになっておいても良いか
    /// </summary>
    public class CommandComponent : ScenarioComponent
    {
        private CommandType _type;
        public CommandType Type { get { return _type; } }
        internal CommandComponent(string id, string[] args, string nextComponentID, CommandType type) : base(id, ComponentType.CMD, args, nextComponentID)
        {
            _type = type;
        }


        public override string[] GetNext()
        {
            // this._isFinished = true;
            return base.GetNext();
        }
    }
}