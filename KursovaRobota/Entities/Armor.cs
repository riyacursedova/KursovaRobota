using System;
using System.Collections.Generic;
using System.Text; 

namespace KursovaRobota;

public class Armor : Gear
{
    public int Defense { get; set; }
    
    public ArmorMaterial Material { get; set; } 
    public ArmorSlot Slot { get; set; }         
    
    public override string GetStats()
    {
        return $"[Armor] {ItemName} | Slot: {Slot} ({Material}) | Def: {Defense} | Stats:{base.GetStats()} |";
    }
    
}