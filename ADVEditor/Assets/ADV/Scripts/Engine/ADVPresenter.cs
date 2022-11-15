using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HarapekoADV.Scenarios;
using HarapekoADV.Commands;
using HarapekoADV.Images;
using HarapekoADV.Sounds;

namespace HarapekoADV
{
    public class ADVPresenter : MonoBehaviour
    {
        private ADVModel _model;
        [SerializeField] private ADVView _view;

        [SerializeField] private ImagePipeline _images;
        private SoundManager _sound;

        public ADVView View
        {
            get { return _view; }
        }
        public ImagePipeline Images
        {
            get { return _images; }
        }
        public SoundManager Sound
        {
            get { return _sound; }
        }
        // Start is called before the first frame update
        void Start()
        {
            Initialise(TestScenario());
            // Test();
        }
        public void Initialise(Scenario scenario)
        {
            _model = new ADVModel(scenario);
            _view.Initialise();
            _images.Initialise();
            _sound = SoundManager.GetInstance();
            OnClicked();
        }
        private void Test()
        {
            AudioClip clip = AssetLoader.Load<AudioClip>(ENV_CONFIG.SAMPLE_RESOURCES_FOLODER_ADDRESS + "AudioSources/clap");
            _sound.AddClip("clap", clip);
            _sound.SetSESource("clap");
            clip = AssetLoader.Load<AudioClip>(ENV_CONFIG.SAMPLE_RESOURCES_FOLODER_ADDRESS + "AudioSources/unpaid");
            _sound.AddClip("unpaid", clip);
            _sound.SetBGMSource("unpaid");
            _sound.PlayBGM(true, true);
            _sound.PlaySE("clap");

        }

        // Update is called once per frame
        void Update()
        {
            _view.FixedUpdate();
        }

        public void OnClicked()
        {
            Command command = _model.GetCommand();
            if (command == null)
            {
                Debugger.Err("CMD null");
            }
            command.Act(this);


            while (command.CommandType != CommandType.TEXT && command.CommandType != CommandType.END)
            {
                command = _model.GetCommand();
                command.Act(this);
            }
            // */
        }

        public void SetScenario(string address)
        {
            ScenarioAnalyser analyser = new ScenarioAnalyser();
            _model.Scenario = analyser.Create(address);
        }

        Scenario TestScenario()
        {
            /*
            Scenario scenario = new Scenario();
            scenario.Add(ScenarioComponentFactory.Create("001", ComponentType.BASE, new string[] { "hogehoge" }, "002"));
            scenario.Add(ScenarioComponentFactory.Create("002", ComponentType.BASE, new string[] { "hoge", "fuga", "piyo" }, "004"));
            scenario.Add(ScenarioComponentFactory.Create("004", ComponentType.CMD, new string[] { "IMG_ADD", "SampleResources/Sprites/ramen", "ramen", "ITEM" }, "005"));
            scenario.Add(ScenarioComponentFactory.Create("005", ComponentType.CMD, new string[] { "IMG_PLAY", "ramen", "TRUE" }, "006"));
            scenario.Add(ScenarioComponentFactory.Create("006", ComponentType.BASE, new string[] { "it is ramen @seiyoken" }, "008"));
            scenario.Add(ScenarioComponentFactory.Create("003", ComponentType.END, new string[] { "end" }, "EOF"));
            scenario.Add(ScenarioComponentFactory.Create("007", ComponentType.CMD, new string[] { "BG_ADD", "SampleResources/Sprites/bg1", "chinanago" }, "009"));
            scenario.Add(ScenarioComponentFactory.Create("009", ComponentType.CMD, new string[] { "BG_CHANGE", "chinanago" }, "010"));
            scenario.Add(ScenarioComponentFactory.Create("008", ComponentType.CMD, new string[] { "IMG_PLAY", "ramen", "false" }, "007"));
            scenario.Add(ScenarioComponentFactory.Create("010", ComponentType.BASE, new string[] { "sakana" }, "003"));
            scenario.SetFirstID("001");
            return scenario;
            // */
            ScenarioAnalyser analyser = new ScenarioAnalyser();
            Scenario scenario = analyser.Create("SampleResources/TextSorces/Example");
            return scenario;
        }
    }

}