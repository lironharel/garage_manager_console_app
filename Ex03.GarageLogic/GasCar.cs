using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class GasCar : Car
    {
        private const Gas.eGasType k_FuelType = Gas.eGasType.Octan98;
        private const float k_MaximumFuelCapacity = 45;

        public GasCar()
        {
            EnergySource = new Gas(k_FuelType, k_MaximumFuelCapacity);
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle type is: Gas Car 
{0}",
base.ToString());
        }
    }
}
