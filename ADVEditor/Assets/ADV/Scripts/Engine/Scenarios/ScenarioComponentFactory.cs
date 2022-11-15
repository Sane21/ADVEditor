using HarapekoADV.Commands;


namespace HarapekoADV.Scenarios
{
    public class ScenarioComponentFactory
    {

        public static ScenarioComponent Create(string id, ComponentType type, string[] args, string nextComponentID)
        {
            ScenarioComponent component = null;



            switch (type)
            {
                case ComponentType.BASE:
                    component = new BaseComponent(id, args, nextComponentID);
                    break;
                case ComponentType.CMD:
                    CommandType commandType;
                    commandType = ENV_CONFIG.GetCommandType(args[0]);
                    /*
                    switch (args[0])
                    {
                        case "IMG_ADD":
                            commandType = CommandType.IMG_ADD;
                            Debugger.Log("ADD");
                            break;
                        case "IMG_PLAY":
                            commandType = CommandType.IMG_PLAY;
                            Debugger.Log("PLAY");
                            break;
                        case "BG_ADD":
                            commandType = CommandType.BG_ADD;
                            Debugger.Log("BGADD");
                            break;
                        case "BG_CHANGE":
                            commandType = CommandType.BG_CHANGE;
                            Debugger.Log("BGCHANGE");
                            break;
                        case "SE_ADD":
                            commandType = CommandType.SE_ADD;
                            break;
                        case "SE_PLAY":
                            commandType = CommandType.SE_PLAY;
                            break;
                        case "BGM_ADD":
                            commandType = CommandType.BGM_ADD;
                            break;
                        case "BGM_SET":
                            commandType = CommandType.BGM_SET;
                            break;
                        case "BGM_PLAY":
                            commandType = CommandType.BGM_PLAY;
                            break;
                        default:
                            commandType = CommandType.ERR;
                            break;
                    }// */
                    component = new CommandComponent(id, args, nextComponentID, commandType);
                    break;
                case ComponentType.END:
                    component = new EndComponent(id, args, nextComponentID);
                    break;
                case ComponentType.IF:
                    Debugger.Log("IF COMPONENT は未完成です");
                    break;
            }
            // */

            return component;
        }
    }
}