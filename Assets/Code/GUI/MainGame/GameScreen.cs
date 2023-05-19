using UnityEngine;
using TMPro;
using BlackGUI.UI;

namespace Code.GUI.MainGame
{
    public sealed class GameScreen : BaseUIElement
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public TextMeshProUGUI ScoreText => _scoreText;
    }
}
