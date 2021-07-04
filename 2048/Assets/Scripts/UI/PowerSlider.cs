using UnityEngine;
using UnityEngine.UI;

namespace Game2048
{
    [RequireComponent(typeof(Slider))]
    public class PowerSlider : MonoBehaviour
    {
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.gameObject.SetActive(false);
            EventSystem.AddListener<ChangeShotStateEvent>(this, OnChangeShot);
            EventSystem.AddListener<LoseGameEvent>(this, OnLoseGame);
        }

        private void OnLoseGame(LoseGameEvent obj)
        {
            EventSystem.RemoveListener<ChangeShotStateEvent>(this);
            EventSystem.RemoveListener<LoseGameEvent>(this);
        }

        private void Update()
        {
            if(_slider.IsActive())
            {
                _slider.value = Mathf.Sin(Time.time * 2f) / 2f + 0.5f;
            }
        }

        private void OnChangeShot(ChangeShotStateEvent eventArg)
        {
            if (eventArg.isEnable)
                _slider.gameObject.SetActive(true);
            else
                _slider.gameObject.SetActive(false);
        }
    }
}