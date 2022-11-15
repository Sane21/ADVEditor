using System;

namespace HarapekoADV.Commands
{
    public class CommandsFactory
    {
        public static Command Create(CommandType commandType, string[] args)
        {
            Command command = null;
            CommandStrategy strategy = null;

            switch (commandType)
            {
                case CommandType.TEXT:
                    strategy = new TextStrategy();
                    break;
                case CommandType.END:
                    strategy = new EndStrategy();
                    break;
                case CommandType.ERR:
                    strategy = new ErrorStrategy();
                    break;
                case CommandType.IMG_ADD:
                    strategy = new ImageAddStrategy();
                    break;
                case CommandType.IMG_PLAY:
                    strategy = new ImagePlayStrategy();
                    break;
                case CommandType.BG_ADD:
                    strategy = new BackgroundAddStrategy();
                    break;
                case CommandType.BG_CHANGE:
                    strategy = new BackgroundChangeStrategy();
                    break;
                case CommandType.SE_ADD:
                    strategy = new SeAddStrategy();
                    break;
                case CommandType.SE_PLAY:
                    strategy = new SePlayStrategy();
                    break;
                case CommandType.BGM_ADD:
                    strategy = new BgmAddStrategy();
                    break;
                case CommandType.BGM_SET:
                    strategy = new BgmSetStrategy();
                    break;
                case CommandType.BGM_PLAY:
                    strategy = new BgmPlayStrategy();
                    break;
            }

            if (strategy != null)
            {
                strategy.Initialise(args);
                command = new Command(commandType, strategy);
            }

            return command;
        }
    }
}