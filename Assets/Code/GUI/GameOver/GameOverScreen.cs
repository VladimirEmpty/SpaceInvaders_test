using UnityEngine;
using UnityEngine.UI;
using BlackGUI.UI;

namespace Code.GUI.GameOver
{
    public sealed class GameOverScreen : BaseUIElement
    {
        [SerializeField] private Button _restartButton;

        public Button RestartButton => _restartButton;
    }
}
