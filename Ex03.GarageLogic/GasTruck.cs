using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class GasTruck : Truck
    {
        private const Gas.eGasType k_FuelType = Gas.eGasType.Octan96;
        private const float k_MaximumFuelCapacity = 115;

        public GasTruck()
        {
            EnergySource = new Gas(k_FuelType, k_MaximumFuelCapacity);
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle type is: Gas Truck 
{0}",
base.ToString());
        }
    }
}
