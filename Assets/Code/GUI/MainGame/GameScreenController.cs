using BlackGUI.MVC.Controller;

namespace Code.GUI.MainGame
{
    public sealed class GameScreenController : BaseUIElementUpdatableController<GameScreen, GameScreenModel>
    {
        public override string Tag => nameof(GameScreenController);

        public override void UpdateControllerHandling()
        {
            UpdateViewes();
        }

        protected override void HideElement()
        {
            
        }

        protected override void ShowElement()
        {
            UpdateViewes();
        }

        protected override void UpdateViewHandling(GameScreen view)
        {
            Model.Request();
            view.ScoreText.text = Model.Score.ToString();
        }
    }
}
