using TMPro;
using UnityEngine;
using Monobehaviours.BaseClass;

namespace Monobehaviours.Manager
{
    public class GameManager : SingletonBase<GameManager>
    {
        [SerializeField] private TextMeshProUGUI _text;

        private int _score = 0;

        private void Start()
        {
            GetInstance().AddScore(0);
        }

        public void AddScore(int value)
        {
            _score += value;
            _text.text = _score.ToString();
        }
    }
}
