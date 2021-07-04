using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game2048
{
    [RequireComponent(typeof(Text))]
    public class ScoreText : MonoBehaviour
    {
        private Text _scoreText;
        private int _score;

        private void Awake()
        {
            _scoreText = GetComponent<Text>();
            _scoreText.text = "0";
            EventSystem.AddListener<CubeMergeEvent>(this, OnCubeMerge);
        }

        private void OnCubeMerge(CubeMergeEvent eventArg)
        {
            _score += eventArg.number * 2;
            _scoreText.text = _score.ToString();
        }

        private void OnDestroy()
        {
            EventSystem.RemoveListener<CubeMergeEvent>(this);
        }
    }
}