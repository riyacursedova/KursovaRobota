using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KursovaRobota
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public GamingClass CharacterClass { get; set; } 
        public decimal GoldBalance { get; set; }
        public List<GameItem> Inventory { get; set; } = new List<GameItem>();
        public List<PurchaseRecord> PurchaseHistory { get; set; } = new List<PurchaseRecord>();

        public User() { }

        public User(int id, string username, string password, GamingClass gamingClass)
        {
            Id = id;
            Username = username;
            Password = password;
            CharacterClass = gamingClass; 
            GoldBalance = 0; 
        }
        
        public void AddGold(decimal amount)
        {
            if (amount < 0) throw new ArgumentException("Сума не може бути меншою за нуль.");
            GoldBalance += amount;
        }
        
        public bool SpendGold(decimal amount)
        {
            if (GoldBalance >= amount)
            {
                GoldBalance -= amount;
                return true; 
            }
            return false;
        }
    }
}