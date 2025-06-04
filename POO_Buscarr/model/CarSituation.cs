using System;
using System.Collections.Generic;

namespace POO_Buscarr.Model
{
    public enum CarSituation
    {
        Available,
        Unavailable,
        InMaintenance
    }

    public static class CarSituationExtensions
    {
        private static readonly Dictionary<CarSituation, string> Labels = new Dictionary<CarSituation, string>
        {
            { CarSituation.Available, "Disponível" },
            { CarSituation.Unavailable, "Indisponível" },
            { CarSituation.InMaintenance, "Em manutenção" }
        };

        public static string GetLabel(this CarSituation situation)
        {
            return Labels[situation];
        }
    }
}
