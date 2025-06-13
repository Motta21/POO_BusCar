using POO_Buscarr.model;
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
        private string Plate { get; set; }
        private string renavan { get; set; }
        private CarSituation situation { get; set; }

        public Car(string model, string plate, string renavam, CarSituation situation)
        {
            this.model = model;
            this.Plate = plate;
            this.renavan = renavam;
            this.situation = situation;
        }

    }
}