using System.Collections.Generic;
using System.Linq;
using KursovaRobota;

namespace KursovaRobota
{
    public interface IItemRepository
    {
        List<GameItem> GetAllItems();
        GameItem GetItemById(int id);
    }
}