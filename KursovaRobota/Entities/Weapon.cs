using System;
using System.Collections.Generic;
using System.Text; 

namespace KursovaRobota;

public class Weapon : Gear
{
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public float AttackSpeed { get; set; } 
    public bool IsTwoHanded { get; set; }
    
    public override string GetStats()
    {
        string hand = IsTwoHanded ? "Two-Hand" : "One-Hand";
        return $"[Weapon] {ItemName} | Dmg: {MinDamage}-{MaxDamage} | Spd: {AttackSpeed} | {hand} | Stats:{base.GetStats()} | ";
    }
}