using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.model
{
    internal class Car
    {
        private string model { get; set;}
        private string brand { get; set; }
        private string renavan { get; set; }
        private string plate { get; set; }
        private string situation { get; set; }

        public Car(string model, string brand, string renavan, string plate, string situation)
        {
            this.model = model;
            this.brand = brand;
            this.renavan = renavan;
            this.plate = plate;
            this.situation = situation;
        }
    }
}
