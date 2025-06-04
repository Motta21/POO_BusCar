using POO_Buscarr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Buscarr.model
{
    public class Car
    {
        private string model { get; set; }
        private string plate { get; set; }
        private string renavan { get; set; }
        private CarSituation situation { get; set; }

        public Car(string model, string plate, string revanan, CarSituation situation)
        {
            this.model = model;
            this.plate = plate;
            this.renavan = revanan;
            this.situation = CarSituation.Available;
        }
    }
}
