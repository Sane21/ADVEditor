using System;

namespace HarapekoADV.Images
{
    public class ImageModel
    {
        private string _address;
        internal string Address { private set { _address = value; } get { return _address; } }
        private string _name;
        internal string Name { private set { _name = value; } get { return _name; } }
        private bool _isActive; // 画面に出しているかどうか
        internal bool IsActive { set { _isActive = value; OnVisibleChanged?.Invoke(_isActive); } get { return _isActive; } }

        internal event Action<bool> OnVisibleChanged;
        private ImageType _type;

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="address">画像のファイルパス</param>
        /// <param name="name">画像名</param>
        /// <param name="isBG">背景かどうか</param>
        internal ImageModel(string address, string name, ImageType type)
        {
            this._address = address;
            this._name = name;
            this._isActive = false;
            this._type = type;
        }


    }
}