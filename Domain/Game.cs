using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence.Domain
{
    public class Game
    {
        GameStage stage;
        public Player Player { get; set; }
        public Field Field { get; set; }
    }


}
