using UnityEngine;
using HarapekoADV.Images;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace HarapekoADV.Commands
{
    public class BackgroundAddStrategy : CommandStrategy
    {
        private string _address;
        private string _name;
        private ImageType _type;
        private Sprite _sprite;
        public void Initialise(string[] args)
        {
            _address = args[1];
            _name = args[2];
            _type = ImageType.Background;
        }

        public void Act(ADVPresenter presenter)
        {
            if (_type == ImageType.ERR)
            {
                Debugger.Err("Image TYPE not defined");
                return;
            }

            AsyncOperationHandle<Sprite> handle = Addressables.LoadAssetAsync<Sprite>(_address);
            handle.WaitForCompletion();
            if (handle.Status == AsyncOperationStatus.Failed)
            {
                Debugger.Err("Background Load  error : " + _address);
                return;
            }

            _sprite = handle.Result;

            presenter.Images.Add(
                _name, _sprite
            );
            Debugger.Log("Addded " + _name);

        }

        /// <summary>
        /// 画像の読み込み
        /// </summary>
        /// <param name="path">画像のパス</param>
        private void LoadImage(string path)
        {
            Addressables.LoadAssetAsync<Sprite>(path).Completed += sprite =>
            {
                if (sprite.Result == null)
                {
                    Debugger.Err("ImageView Load Error : " + path);
                    return;
                }
                _sprite = sprite.Result;
            };

        }
    }
}
