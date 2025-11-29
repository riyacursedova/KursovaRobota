using System;
using System.Text.Json.Serialization;

namespace KursovaRobota
{
    
    [JsonDerivedType(typeof(Weapon), typeDiscriminator: "weapon")]
    [JsonDerivedType(typeof(Armor), typeDiscriminator: "armor")]
    
    public abstract class GameItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public GamingClass? RequiredClass { get; set; }

        public abstract string GetStats();
    }
}