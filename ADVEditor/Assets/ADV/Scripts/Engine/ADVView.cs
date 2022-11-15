using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HarapekoADV
{
    public class ADVView : MonoBehaviour
    {
        [SerializeField] private Image _backgroundImage;
        // [SerializeField] private GameObject _itemPipeline;
        [SerializeField] private Text _mainText;
        // [SerializeField] private GameObject _backLog;
        // [SerializeField] private Text _logText;

        public void Initialise()
        {
            _mainText.text = "";
        }

        public void FixedUpdate()
        {

        }

        public void SetText(string text)
        {
            _mainText.text = text;
        }

        public void SetText(string[] text)
        {
            _mainText.text = text[0];
        }

        public void SetBG(Image bg)
        {
            this._backgroundImage.sprite = bg.sprite;
        }

        public void SetBG(Sprite bg)
        {
            this._backgroundImage.sprite = bg;
        }
    }
}
