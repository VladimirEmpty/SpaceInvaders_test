using UnityEngine;
using BlackGUI;
using BlackGUI.MVC.Controller;

namespace Code.GUI.GameOver
{
    public sealed class GameOverScreenController : BaseUIElementController<GameOverScreen, GameModel>    {
        protected override void HideElement()
        {
            Time.timeScale = 1f;
        }

        protected override void ShowElement()
        {
            Time.timeScale = default;
            LastView.RestartButton.onClick.AddListener(OnClick);
        }

        protected override void UpdateViewHandling(GameOverScreen view)
        {
            
        }

        private void OnClick()
        {
            Model.RestartGame();
            BlackGUIConnector.Close<GameOverScreen>();
        }
    }
}
