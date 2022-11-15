using System;

namespace HarapekoADV.Scenarios
{
    /// <summary>
    /// 終点のコンポーネント
    /// </summary>
    public class EndComponent : ScenarioComponent
    {
        internal EndComponent(string id, string[] args, string nextComponentID) : base(id, ComponentType.END, args, nextComponentID)
        {
            // _isFinished = true;
        }
    }
}