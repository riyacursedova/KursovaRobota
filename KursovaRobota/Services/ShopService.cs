using System.Collections.Generic;
using KursovaRobota; 

namespace KursovaRobota
{
    public class ShopService : IShopService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUserRepository _userRepository;
        public ShopService(IItemRepository itemRepository, IUserRepository userRepository)
        {
            _itemRepository = itemRepository;
            _userRepository = userRepository;
        }

        public List<GameItem> GetAllItems()
        {
            return _itemRepository.GetAllItems();
        }

        public string BuyItem(User user, int itemId)
        {
            var item = _itemRepository.GetItemById(itemId);
            if (item == null)
            {
                return "Помилка: Товар не знайдено.";
            }

            if (item.RequiredClass != null && item.RequiredClass != user.CharacterClass)
            {
                return $"Неможливо купити! Цей предмет тільки для класу {item.RequiredClass}.";
            }

            if (user.SpendGold(item.ItemPrice))
            {
                user.Inventory.Add(item);
                user.PurchaseHistory.Add(new PurchaseRecord
                {
                    ItemName = item.ItemName,
                    Price = item.ItemPrice
                });
                _userRepository.UpdateUser(user);
                
                return $"Успіх! Ви придбали {item.ItemName}.";
            }
            else
            {
                return $"Недостатньо золота! Ціна: {item.ItemPrice.ToString()}, у вас: {user.GoldBalance.ToString()}.";
            }
        }

        public void TopUpBalance(User user, decimal amount)
        {
            try
            {
                user.AddGold(amount);
                _userRepository.UpdateUser(user);
            }
            catch (System.ArgumentException)
            {
                throw;
            }
        }
    }
}