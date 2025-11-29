using System.Collections.Generic;
using KursovaRobota;

namespace KursovaRobota
{
    public interface IShopService
    {
        List<GameItem> GetAllItems();
        string BuyItem(User user, int itemId);
        void TopUpBalance(User user, decimal amount); // Add gold for balance
    }
}