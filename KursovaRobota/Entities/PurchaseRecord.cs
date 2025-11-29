using System;

namespace KursovaRobota
{
    public class PurchaseRecord
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{ItemName} (-{Price} Gold)";
        }
    }
}