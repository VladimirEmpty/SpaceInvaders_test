using BlackGUI.MVC.Model;


namespace Code.GUI
{
    public sealed class GameModel : IModel
    {
        private readonly Game Game;
        private readonly PlayerService PlayerService;
        public GameModel(
            Game game,
            PlayerService playerService)
        {
            Game = game;
            PlayerService = playerService;
        }

        public void Request()
        {
            
        }

        public void Update()
        {
            
        }

        public void StartNewGame()
        {
            Game.CreateGame();
        }

        public void RestartGame()
        {
            Game.DestoryGame();
            Game.CreateGame();
            PlayerService.ResetScroe();
        }
    }
}
