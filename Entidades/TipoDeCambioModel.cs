using System;

namespace Entidades
{
    public class TipoDeCambioModel
    {
        public int IdTipoCambio { get; set; }
        public int IdMoneda { get; set; }
        public decimal FactorConversion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
