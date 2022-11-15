using System;
using HarapekoADV.Commands;

namespace HarapekoADV.Scenarios
{
    /// <summary>
    /// シナリオの構成要素　BASE基本, IF条件分岐, END終点, CMDコマンド
    /// </summary>
    public abstract class ScenarioComponent
    {
        /// <summary>
        /// ID 
        /// </summary>
        private string _id;
        public string ID
        {
            get { return _id; }
        }
        /// <summary>
        /// タイプ
        /// BASE, (IF), END, CMD
        /// </summary>
        private ComponentType _componentType;
        public ComponentType ComponentType
        {
            get { return _componentType; }
        }
        /// <summary>
        /// テキスト、コマンドの引数
        /// </summary>
        protected string[] _args;

        /*
        /// <summary>
        /// 最後まで流したかどうか
        /// </summary>
        protected bool _isFinished;
        public bool IsFinished
        {
            get { return _isFinished; }
        }
        // */

        /// <summary>
        /// 次のコンポーネントのID
        /// </summary>
        private string _nextComponentID;

        public ScenarioComponent(string id, ComponentType type, string[] args, string nextComponentID)
        {
            _id = id;
            _componentType = type;
            _args = args;
            _nextComponentID = nextComponentID;
            // _isFinished = false;
        }

        /// <summary>
        /// 次のコマンドの引数を返す
        /// </summary>
        /// <returns></returns>
        public virtual string[] GetNext()
        {
            return _args;
        }

        /// <summary>
        /// 次のコンポーネントのIDを決定する
        /// </summary>
        /// <returns></returns>
        public string GetNextComponentID()
        {
            return _nextComponentID;
        }


    }
}