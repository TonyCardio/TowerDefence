using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Domain
{
    public class Game
    {
        GameStage stage = GameStage.MainMenu;
        public event Action<GameStage> StateChanged;
        public Player Player { get; set; }


        public void ChoseLevel()
        {
            ChangeStage(GameStage.ChoosingLevel);
        }

        private void ChangeStage(GameStage stage)
        {
            this.stage = stage;
            StateChanged?.Invoke(stage);
        }
    }
}
