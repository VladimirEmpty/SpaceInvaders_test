using BlackGUI.MVC.Controller;
using BlackGUI;

namespace Code.GUI.MainMenu
{
    public sealed class MainMenuScreenController : BaseUIElementController<MainMenuScreen, GameModel>
    {
        protected override void HideElement()
        {
            LastView.StartButton.onClick.RemoveAllListeners();
        }

        protected override void ShowElement()
        {
            LastView.StartButton.onClick.AddListener(OnClick);
        }

        protected override void UpdateViewHandling(MainMenuScreen view)
        {
            
        }

        private void OnClick()
        {
            Model.StartNewGame();
            BlackGUIConnector.Close<MainMenuScreen>();
        }
    }
}
