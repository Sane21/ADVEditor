using System;

namespace HarapekoADV.Scenarios
{
    /// <summary>
    /// 選択肢の表示による条件分岐
    /// </summary>
    public class IfComponent : ScenarioComponent
    {
        internal IfComponent(string id, string[] args, string nextComponentID) : base(id, ComponentType.IF, args, nextComponentID)
        {
            Debugger.Err("未実装です");
        }


        public override string[] GetNext()
        {
            // this._isFinished = true;
            return base.GetNext();
        }
    }
}