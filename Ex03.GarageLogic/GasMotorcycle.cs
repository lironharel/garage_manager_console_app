using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class GasMotorcycle : Motorcycle
    {
        private const Gas.eGasType k_FuelType = Gas.eGasType.Octan96;
        private const float k_MaximumFuelCapacity = 8.0f;

        public GasMotorcycle()
        {
            EnergySource = new Gas(k_FuelType, k_MaximumFuelCapacity);
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle type is: Gas Motorcycle 
{0}",
base.ToString());
        }
    }
}
