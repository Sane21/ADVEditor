using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HarapekoADV.Images
{
    public class ImagePresenter : MonoBehaviour
    {
        private ImageModel _model;
        private ImageView _view;

        internal void Initialise(string address, string name, ImageType type)
        {
            _model = new ImageModel(address, name, type);
            _view = GetComponent<ImageView>();
            _view.Initialise(_model.Address);
            _model.OnVisibleChanged += _view.gameObject.SetActive;
        }

        public string GetName()
        {
            return _model.Name;
        }

        public void Activate(bool isActive)
        {
            _model.IsActive = isActive;
        }

        public Image GetSprite()
        {
            return _view.Image;
        }
    }
}