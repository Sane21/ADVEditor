using UnityEngine;
using System.Collections.Generic;

namespace HarapekoADV.Sounds
{
    public class SoundManager : MonoBehaviour
    {
        private static SoundManager instance;
        private bool _isInitialised;
        private Dictionary<string, AudioClip> _clips;
        [SerializeField] private AudioSource _bgmSource;
        [SerializeField] private AudioSource _seSource;
        public float BGMVolume { set { if (_isInitialised) _bgmSource.volume = value; } get { return _isInitialised ? _bgmSource.volume : 0; } }
        public float SEVolume { set { if (_isInitialised) _seSource.volume = value; } get { return _isInitialised ? _seSource.volume : 0; } }

        void Awake()
        {
            if (instance = null)
            {
                instance = this;
            }
        }

        public static SoundManager GetInstance()
        {
            if (instance == null)
            {
                GameObject obj = Instantiate<GameObject>(AssetLoader.Load<GameObject>(ENV_CONFIG.SOOUND_PREFAB_ADRESS));
                instance = obj.GetComponent<SoundManager>();
                instance.Initialise();
            }
            return instance;
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialise()
        {
            _isInitialised = true;
            DontDestroyOnLoad(this.gameObject);
            BGMVolume = 0.5f;
            SEVolume = 0.5f;
            _clips = new Dictionary<string, AudioClip>();
        }

        public void AddClip(string name, AudioClip clip)
        {
            _clips.Add(name, clip);
        }

        public void SetBGMSource(string name)
        {
            if (_clips.ContainsKey(name))
            {
                _bgmSource.clip = _clips[name];
            }
            else
            {
                Debugger.Err("AudioClip not found @BGM : " + name);
            }
        }

        public void SetSESource(string name)
        {
            if (_clips.ContainsKey(name))
            {
                _seSource.clip = _clips[name];
            }
            else
            {
                Debugger.Err("AudioClip not found @SE : " + name);
            }
        }

        public void PlayBGM(bool isPlay, bool inLoop)
        {
            _bgmSource.loop = inLoop;
            if (isPlay)
            {
                _bgmSource.Play();
            }
            else
            {
                _bgmSource.Stop();
            }

        }

        public void PlaySE()
        {
            _seSource.PlayOneShot(_seSource.clip);
        }

        public void PlaySE(string name)
        {
            if (_clips.ContainsKey(name))
            {
                _seSource.PlayOneShot(_clips[name]);
            }
            else
            {
                Debugger.Err("AudioClip not found @SE_PLAY : " + name);
            }
        }

    }
}