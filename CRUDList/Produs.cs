using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDList
{
    class Produs
    {
        private int idProdus;
        private string numeProdus;
        private double pretProdus;

        public Produs(int idProdus, string numeProdus, double pretProdus)
        {
            this.idProdus = idProdus;
            this.numeProdus = numeProdus;
            this.pretProdus = pretProdus;
        }

        public int IdProdus { get => idProdus; set => idProdus = value; }
        public string NumeProdus { get => numeProdus; set => numeProdus = value; }
        public double PretProdus { get => pretProdus; set => pretProdus = value; }

        public string Display
        {
            get
            {
                return string.Format($"{IdProdus} {NumeProdus} {PretProdus}");
            }
        }
    }
}
