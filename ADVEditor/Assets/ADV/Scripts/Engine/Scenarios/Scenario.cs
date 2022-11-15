using System.Collections.Generic;
using HarapekoADV.Commands;

namespace HarapekoADV.Scenarios
{
    /// <summary>
    /// シナリオの構造体を管理する
    /// </summary>
    public class Scenario
    {
        /// <summary>
        /// ID, Component シーンコンポーネントとそのID
        /// </summary>
        private Dictionary<string, ScenarioComponent> _componentList;
        /// <summary>
        /// ID, flag 条件分岐のためのフラグとそのID
        /// </summary>
        private Dictionary<string, bool> _flagList;
        /// <summary>
        /// 最初のコンポーネントのID
        /// </summary>
        private string _firstID;
        /// <summary>
        /// 現在、再生中のComponent
        /// </summary>
        private ScenarioComponent _component;

        // コンストラクタ
        /// <summary>
        /// コンポーネントリストやフラグリストの初期化
        /// </summary>
        public Scenario()
        {
            _componentList = new Dictionary<string, ScenarioComponent>();
            _flagList = new Dictionary<string, bool>();
            _firstID = "";
            _component = null;
        }

        /// <summary>
        /// コンポーネントの追加
        /// </summary>
        /// <param name="id"></param>
        /// <param name="component"></param>
        public void Add(ScenarioComponent value)
        {
            string id = value.ID;
            _componentList.Add(id, value);
        }

        /// <summary>
        /// フラグの追加
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Add(string id, bool value)
        {
            _flagList.Add(id, value);
        }

        /// <summary>
        /// 初期シーンの選択
        /// </summary>
        /// <param name="id"></param>
        public void SetFirstID(string id)
        {
            if (_componentList.ContainsKey(id))
            {
                _firstID = id;
            }
        }

        /// <summary>
        /// 次の表示文字列あるいはコマンドを返す
        /// </summary>
        /// <returns></returns>
        public Command GetNext()
        {
            Command command = null;
            // 初期コンポーネントが未設定であった場合に処理を中断する
            if (_firstID == null || _firstID == "")
            {
                Debugger.Log("undefined first node");
                return CommandsFactory.Create(CommandType.ERR, null);
            }

            // コンポーネントが空の場合、初期コンポーネントを設定する
            if (_component == null)
            {
                _component = _componentList[_firstID];
            }

            /*
            // コンポーネントの終点に達していた場合、次のコンポーネントIDを取得し設定する
            if (_component.IsFinished)
            { */
            // 終点だった場合、終了コマンドを返す
            if (_component.ComponentType.Equals(ComponentType.END))
            {
                command = CommandsFactory.Create(CommandType.END, _component.GetNext());
                // return command;
            }
            /*
            else
            {
                string id = _component.GetNextComponentID();
                if (_componentList.ContainsKey(id))
                {
                    _component = _componentList[id];
                }
                else
                {
                    Debugger.Err("key not found : " + id);
                }
            }*/


            // }
            else if (_component.ComponentType.Equals(ComponentType.CMD)) // コンポーネントがコマンドだった場合 
            {
                Debugger.Log("here");
                // componentのIDから指定のコマンドを生成して返却
                CommandComponent commandComponent = (CommandComponent)_component;
                Debugger.Log("TYPE' : " + commandComponent.Type);
                command = CommandsFactory.Create(commandComponent.Type, _component.GetNext());
            }
            else
            {
                Debugger.Log("Type : " + _component.ComponentType);
                // else コマンドでも終点でもない場合はテキスト読み込み
                command = CommandsFactory.Create(CommandType.TEXT, _component.GetNext());
            }

            if (_component.ComponentType != ComponentType.END)
            {
                string id = _component.GetNextComponentID();
                if (_componentList.ContainsKey(id))
                {
                    _component = _componentList[id];
                }
                else
                {
                    Debugger.Err("key not found : " + id);
                }
            }


            return command;
        }
    }
}