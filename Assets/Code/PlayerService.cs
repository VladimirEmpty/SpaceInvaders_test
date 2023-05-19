using BlackGUI;

using Code.GUI.MainGame;

namespace Code
{
    public sealed class PlayerService
    {
        public int PlayerScore { get; private set; }

        public void AddScore(int score)
        {
            PlayerScore += score;
            BlackGUIConnector.UpdateControllersWithTag(nameof(GameScreenController));
        }
        public void ResetScroe() => PlayerScore = default;
    }
}
