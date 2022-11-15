using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

namespace HarapekoADV.Images
{
    public class ImageView : MonoBehaviour
    {

        private Image _image;
        public Image Image { get; }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="path"></param>
        internal void Initialise(string path)
        {
            LoadImage(path);
            GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);

            Debugger.Log("pos : (" + transform.position.x + ", " + transform.position.y + ", " + transform.position.z);
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
                _image = this.gameObject.GetComponent<Image>();
                _image.sprite = Instantiate(sprite.Result);
            };

        }

    }
}