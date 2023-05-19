using UnityEngine;
using UnityEngine.UI;
using BlackGUI.UI;

namespace Code.GUI.MainMenu
{
    public sealed class MainMenuScreen : BaseUIElement
    {
        [SerializeField] private Button _startButton;

        public Button StartButton => _startButton;
    }
}
