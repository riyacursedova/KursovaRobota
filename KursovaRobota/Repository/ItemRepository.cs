using System.Collections.Generic;
using System.Linq;
using KursovaRobota;

namespace KursovaRobota
{
    public class ItemRepository : IItemRepository
    {
        private readonly List<GameItem> _items = new List<GameItem>();

        public ItemRepository()
        {
            SeedItems();
        }

        public List<GameItem> GetAllItems()
        {
            return _items;
        }

        public GameItem GetItemById(int id)
        {
            return _items.FirstOrDefault(x => x.ItemID == id);
        }

        private void SeedItems()
{
    // 1. Death Knight (Legendary Two-Handed Sword)
    _items.Add(new Weapon
    {
        ItemID = 1,
        ItemName = "Shadowmourne",
        ItemDescription = "A two-handed axe forged from the shards of the Frozen Throne.",
        ItemPrice = 15000,
        RequiredClass = GamingClass.DeathKnight,
        MinDamage = 850, MaxDamage = 980, AttackSpeed = 3.7f, IsTwoHanded = true,
        Strength = 250, Stamina = 300, Agility = 0, Intellect = 0
    });

    // 2. Beginner Item
    _items.Add(new Weapon
    {
        ItemID = 2,
        ItemName = "Training Sword",
        ItemDescription = "A dull blade for beginners.",
        ItemPrice = 50,
        RequiredClass = null,
        MinDamage = 5, MaxDamage = 10, AttackSpeed = 2.0f, IsTwoHanded = false,
        Strength = 1, Stamina = 1
    });

    // 3. Warrior (Two-Handed Axe) - Gorehowl
    _items.Add(new Weapon
    {
        ItemID = 3,
        ItemName = "Gorehowl",
        ItemDescription = "The legendary axe of Grommash Hellscream.",
        ItemPrice = 4500,
        RequiredClass = GamingClass.Warrior,
        MinDamage = 400, MaxDamage = 600, AttackSpeed = 3.6f, IsTwoHanded = true,
        Strength = 120, Stamina = 100
    });

    // 4. Rogue (Dagger) - Perdition's Blade
    _items.Add(new Weapon
    {
        ItemID = 4,
        ItemName = "Perdition's Blade",
        ItemDescription = "A dagger dripping with magma.",
        ItemPrice = 3200,
        RequiredClass = GamingClass.Rogue,
        MinDamage = 180, MaxDamage = 250, AttackSpeed = 1.8f, IsTwoHanded = false,
        Agility = 80, Stamina = 40, Strength = 10
    });

    // 5. Hunter (Bow - Technically a Weapon in your system) - Thori'dal
    _items.Add(new Weapon
    {
        ItemID = 5,
        ItemName = "Thori'dal, the Stars' Fury",
        ItemDescription = "Legendary bow containing the energy of the Sunwell.",
        ItemPrice = 12000,
        RequiredClass = GamingClass.Hunter,
        MinDamage = 350, MaxDamage = 450, AttackSpeed = 2.8f, IsTwoHanded = true,
        Agility = 150, Stamina = 100, Intellect = 20
    });

    // 6. Mage/Warlock (Staff) - Atiesh
    _items.Add(new Weapon
    {
        ItemID = 6,
        ItemName = "Atiesh, Greatstaff of the Guardian",
        ItemDescription = "A staff of infinite power left by Medivh.",
        ItemPrice = 20000,
        RequiredClass = GamingClass.Mage, // Можна змінити на Warlock або Priest
        MinDamage = 100, MaxDamage = 150, AttackSpeed = 3.0f, IsTwoHanded = true,
        Intellect = 200, Stamina = 150, Strength = 0, Agility = 0
    });

    // 7. Shaman (Mace) - Doomhammer
    _items.Add(new Weapon
    {
        ItemID = 7,
        ItemName = "Doomhammer",
        ItemDescription = "A hammer forged in elemental fire.",
        ItemPrice = 5000,
        RequiredClass = GamingClass.Shaman,
        MinDamage = 300, MaxDamage = 420, AttackSpeed = 2.6f, IsTwoHanded = false,
        Agility = 90, Stamina = 90, Strength = 50
    });
    
    // 8. Paladin (Head) - Judgement Set
    _items.Add(new Armor
    {
        ItemID = 8,
        ItemName = "Judgement Crown",
        ItemDescription = "The iconic hood of the Judgement set.",
        ItemPrice = 800,
        RequiredClass = GamingClass.Paladin,
        Defense = 600,
        Material = ArmorMaterial.Plate,
        Slot = ArmorSlot.Head,
        Strength = 20, Intellect = 20, Stamina = 30
    });

    // 9. Paladin (Shoulders) - Judgement Set
    _items.Add(new Armor
    {
        ItemID = 9,
        ItemName = "Judgement Spaulders",
        ItemDescription = "Glowing holy pauldrons.",
        ItemPrice = 750,
        RequiredClass = GamingClass.Paladin,
        Defense = 550,
        Material = ArmorMaterial.Plate,
        Slot = ArmorSlot.Shoulders,
        Strength = 18, Intellect = 18, Stamina = 25
    });

    // 10. Rogue (Chest) - Bloodfang
    _items.Add(new Armor
    {
        ItemID = 10,
        ItemName = "Bloodfang Chestpiece",
        ItemDescription = "Armor worn by the darkest assassins.",
        ItemPrice = 1100,
        RequiredClass = GamingClass.Rogue,
        Defense = 300,
        Material = ArmorMaterial.Leather,
        Slot = ArmorSlot.Chest,
        Agility = 45, Stamina = 30, Strength = 10
    });

    // 11. Priest (Shoulders) - Vestments of Transcendance
    _items.Add(new Armor
    {
        ItemID = 11,
        ItemName = "Pauldrons of Transcendence",
        ItemDescription = "Glowing with holy light.",
        ItemPrice = 900,
        RequiredClass = GamingClass.Priest,
        Defense = 120,
        Material = ArmorMaterial.Cloth,
        Slot = ArmorSlot.Shoulders,
        Intellect = 40, Stamina = 25
    });

    // 12. Warrior (Legs) - Dreadnaught
    _items.Add(new Armor
    {
        ItemID = 12,
        ItemName = "Dreadnaught Legplates",
        ItemDescription = "Heavy plate armor for tanking dragons.",
        ItemPrice = 1500,
        RequiredClass = GamingClass.Warrior,
        Defense = 900,
        Material = ArmorMaterial.Plate,
        Slot = ArmorSlot.Legs,
        Strength = 50, Stamina = 80
    });
}
    }
}