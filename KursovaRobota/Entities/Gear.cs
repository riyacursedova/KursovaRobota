using System;
using System.Collections.Generic;
using System.Text; 

namespace KursovaRobota;

public abstract class Gear : GameItem
{
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Intellect { get; set; }
    public int Stamina { get; set; }
    
    public override string GetStats()
    {
        var sb = new StringBuilder();
        if (Strength > 0) sb.Append($" +{Strength} Strength");
        if (Agility > 0) sb.Append($" +{Agility} Agility");
        if (Intellect > 0) sb.Append($" +{Intellect} Intellect");
        if (Stamina > 0) sb.Append($" +{Stamina} Stamina");
        return sb.ToString();
    }
}