using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HarapekoADV.Images
{
    /// <summary>
    /// 
    /// </summary>
    public class ImagePipeline : MonoBehaviour
    {
        private Dictionary<string, ImagePresenter> _images;
        private Dictionary<string, Sprite> _backgroundImages;

        public void Initialise()
        {
            _images = new Dictionary<string, ImagePresenter>();
            _backgroundImages = new Dictionary<string, Sprite>();
        }

        /*
        public void Add(string address, string name, bool isBG)
        {
            Add(ImageFactory.Create(address, name, isBG));
        }
        // */

        public void Add(ImagePresenter image)
        {
            string key = image.GetName();
            if (_images.ContainsKey(key))
            {
                Debugger.Log("image name [" + key + "] is exists");
                return;
            }
            // image.gameObject.transform.SetParent(this.gameObject.transform);
            _images.Add(key, image);
            image.Activate(false);
        }

        public void Add(string key, Sprite sprite)
        {
            if (_backgroundImages.ContainsKey(key))
            {
                Debugger.Log("bg name [" + key + "] is exists");
                return;
            }
            _backgroundImages.Add(key, sprite);
        }

        public ImagePresenter Get(string key)
        {
            return _images[key];
        }

        public Sprite GetBG(string key)
        {
            return _backgroundImages[key];
        }

        public void Activate(string key)
        {
            if (!_images.ContainsKey(key))
            {
                Debugger.Log("not found image name [" + key + "]");
                return;
            }

            _images[key].Activate(true);
        }

        public void Activate(string key, bool isActive)
        {
            if (!_images.ContainsKey(key))
            {
                Debugger.Log("not found image name [" + key + "]");
                return;
            }

            _images[key].Activate(isActive);
        }
    }
}