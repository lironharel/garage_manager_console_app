using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class ElectricMotorcycle : Motorcycle
    {
        private const float k_MaximumChargeTimeOfBattery = 1.8f;

        public ElectricMotorcycle()
        {
            EnergySource = new Electric(k_MaximumChargeTimeOfBattery);
        }

        public override string ToString()
        {
            return string.Format(
@"Vehicle type is: Electric Motorcycle
{0}",
base.ToString());
        }
    }
}
