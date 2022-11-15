using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace HarapekoADV.Scenarios
{
    /// <summary>
    /// JSON形式のシナリオ同士の繋がりを, 構造として持つScenarioを作成する
    /// </summary>
    public class ScenarioAnalyser
    {
        private string _address;
        private int _count;
        private List<string> _idList;

        public Scenario Create(string _address)
        {
            Scenario scenario = new Scenario();
            _count = 0;
            _idList = new List<string>();
            TextAsset asset = LoadAsset(_address);
            string[] texts = DevideAsset(asset);
            foreach (string text in texts)
            {
                scenario.Add(CreateComponent(text));
            }
            scenario.SetFirstID("1");
            return scenario;
        }

        private ScenarioComponent CreateComponent(string text)
        {
            ScenarioComponent component = null;
            _count += 1;
            string id = _count.ToString();
            while (_idList.Contains(id))
            {
                _count += 1;
                id = _count.ToString();
            }
            _idList.Add(id);
            if (text == "@[EOF]")
            {
                component = ScenarioComponentFactory.Create(id, ComponentType.END, new string[] { "EOF" }, "EOF");
            }
            else if (text[0] == '@')
            {
                component = ScenarioComponentFactory.Create(id, ComponentType.CMD, DevideCommand(text), (_count + 1).ToString());
            }
            else
            {
                component = ScenarioComponentFactory.Create(id, ComponentType.BASE, new string[] { text }, (_count + 1).ToString());
            }
            return component;
        }

        private string[] DevideCommand(string text)
        {
            string command = "";
            List<string> options = new List<string>();
            foreach (char c in text)
            {
                if (c == '@')
                {
                    continue;
                }
                else if (c == '[' || c == ' ')
                {
                    continue;
                }
                else if (c == ']')
                {
                    options.Add(command);
                    break;
                }
                else if (c == ',')
                {
                    options.Add(command);
                    command = "";
                }
                else
                {
                    command += c;
                }
            }
            return options.ToArray();
        }

        private string[] DevideAsset(TextAsset asset)
        {
            string[] components = asset.text.Split('\n');
            return components;
        }

        private TextAsset LoadAsset(string _address)
        {
            TextAsset asset = null;
            AsyncOperationHandle<TextAsset> handle = Addressables.LoadAssetAsync<TextAsset>(_address);
            handle.WaitForCompletion();
            if (handle.Status == AsyncOperationStatus.Failed)
            {
                Debugger.Log("");
                return null;
            }
            asset = handle.Result;

            return asset;
        }
    }
}