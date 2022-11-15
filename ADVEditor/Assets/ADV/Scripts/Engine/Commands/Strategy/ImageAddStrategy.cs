using UnityEngine;
using HarapekoADV.Images;

namespace HarapekoADV.Commands
{
    public class ImageAddStrategy : CommandStrategy
    {
        private string _address;
        private string _name;
        private ImageType _type;
        public void Initialise(string[] args)
        {
            _address = args[1];
            _name = args[2];
            switch (args[3])
            {
                case "ITEM":
                    _type = ImageType.Item;
                    break;
                case "BG":
                case "Background":
                    _type = ImageType.Background;
                    break;
                default:
                    _type = ImageType.ERR;
                    break;
            }
        }

        public void Act(ADVPresenter presenter)
        {
            if (_type == ImageType.ERR)
            {
                Debugger.Err("Image TYPE not defined");
                return;
            }
            presenter.Images.Add(
                ImageFactory.Create(_address, _name, _type, presenter.Images.gameObject.transform)
            );
            Debugger.Log("Addded");

        }
    }
}