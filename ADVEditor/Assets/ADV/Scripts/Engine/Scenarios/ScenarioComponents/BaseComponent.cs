using System;

namespace HarapekoADV.Scenarios
{
    /// <summary>
    /// 基本の文字列表示のコンポーネント
    /// 引数の1つ目を反映する
    /// </summary>
    public class BaseComponent : ScenarioComponent
    {
        internal BaseComponent(string id, string[] args, string nextComponentID) : base(id, ComponentType.BASE, args, nextComponentID) { }


        public override string[] GetNext()
        {
            /*
            if (!IsFinished)
            {
                string[] arg = { _args[0] };
                if (_args.Length == 1)
                {
                    _isFinished = true;
                }
                else
                {
                    string[] args = new string[_args.Length - 1];
                    Array.Copy(_args, 1, args, 0, args.Length);
                    _args = args;
                }
                // Debugger.Log(_args[0] + _args.Length + IsFinished);
                return arg;
            }
            */
            // Debugger.Log(_args[0]);
            return _args;
        }
    }
}