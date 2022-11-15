using System.Collections.Generic;
using HarapekoADV.Scenarios;
using HarapekoADV.Commands;

namespace HarapekoADV
{
    public class ENV_CONFIG
    {
        public const string IMG_PREFAB_ADDRESS = "ADV/Prefabs/Image";
        public const string SOOUND_PREFAB_ADRESS = "ADV/Prefabs/SoundManager";
        public const string SAMPLE_RESOURCES_FOLODER_ADDRESS = "SampleResources/";

        private static Dictionary<string, CommandType> commandDictionary;
        public static CommandType GetCommandType(string key)
        {
            if (commandDictionary == null)
            {
                Initialise();
            }
            CommandType type = CommandType.ERR;
            if (commandDictionary.ContainsKey(key))
            {
                type = commandDictionary[key];
            }
            return type;
        }

        private static Dictionary<string, ComponentType> cmoponentDictionary;
        public static ComponentType GetComponentType(string key)
        {
            if (cmoponentDictionary == null)
            {
                Initialise();
            }
            ComponentType type = ComponentType.BASE;
            if (cmoponentDictionary.ContainsKey(key))
            {
                type = cmoponentDictionary[key];
            }
            else if (key[0] == '@')
            {
                type = ComponentType.CMD;
            }
            return type;
        }

        private static void Initialise()
        {
            commandDictionary = new Dictionary<string, CommandType>();
            Add("IMG_ADD", CommandType.IMG_ADD);
            Add("IMG_PLAY", CommandType.IMG_PLAY);
            Add("BG_ADD", CommandType.BG_ADD);
            Add("BG_CHANGE", CommandType.BG_CHANGE);
            Add("SE_ADD", CommandType.SE_ADD);
            Add("SE_PLAY", CommandType.SE_PLAY);
            Add("BGM_ADD", CommandType.BGM_ADD);
            Add("BGM_SET", CommandType.BGM_SET);
            Add("BGM_PLAY", CommandType.BGM_PLAY);

            cmoponentDictionary = new Dictionary<string, ComponentType>();
            Add("@[EOF]", ComponentType.END);
        }

        private static void Add(string key, CommandType value)
        {
            commandDictionary.Add(key, value);
        }
        private static void Add(string key, ComponentType value)
        {
            cmoponentDictionary.Add(key, value);
        }

    }
}