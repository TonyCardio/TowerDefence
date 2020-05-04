using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Domain
{
    public class Game
    {
        GameStage stage;
        public event Action<GameStage> StateChanged;
        public Player Player { get; set; }
    }
}
