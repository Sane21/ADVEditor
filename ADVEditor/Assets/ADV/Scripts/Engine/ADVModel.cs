using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HarapekoADV.Images;
using HarapekoADV.Scenarios;

namespace HarapekoADV
{
    public class ADVModel
    {
        private string _scenarioSouce;
        private string _characterSpritePath;
        private string _backgroundSpritePath;
        private Dictionary<string, bool> _imageList;
        private Scenario _scenario;
        internal Scenario Scenario { set; get; }

        public ADVModel(Scenario scenario)
        {
            _scenario = scenario;
        }

        public Commands.Command GetCommand()
        {
            return _scenario.GetNext();
        }
    }

}
