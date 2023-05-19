using BlackGUI.MVC.Model;

namespace Code.GUI.MainGame
{
    public sealed class GameScreenModel : IModel
    {
        private readonly PlayerService PlayerService;

        public GameScreenModel(PlayerService playerService)
        {
            PlayerService = playerService;
        }

        public int Score { get; private set; }

        public void Request()
        {
            Score = PlayerService.PlayerScore;
        }

        public void Update()
        {
            
        }
    }
}
