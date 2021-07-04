using System.Collections.Generic;
using UnityEngine;

namespace Game2048
{
    public class SoundController : MonoBehaviour
    {
        private static SoundController _instance;
        public static SoundController Instance => _instance;

        [SerializeField] private AudioClip _clip;
        private List<AudioSource> _audio;
        private int _currentAudio;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                Initialize();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Initialize()
        {
            _audio = new List<AudioSource>();
            for(var i = 0; i < 5; i++)
            {
                var audio = gameObject.AddComponent<AudioSource>();
                audio.clip = _clip;
                _audio.Add(audio);
            }
        }

        public void Blup()
        {
            _currentAudio++;
            _currentAudio %= 5;
            _audio[_currentAudio].Play();
        }
    }
}