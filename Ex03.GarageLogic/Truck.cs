using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 12;
        private const int k_MaximumWheelPressure = 28;
        private bool m_IsCarryingDangerousMaterials;
        private float m_MaxAllowedWeight;

        public Truck()
        {
            Wheels = new List<Wheel>(k_NumberOfWheels);

            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(k_MaximumWheelPressure));
            }
        }

        public bool IsCarryingDangerousMaterials
        {
            get
            {
                return m_IsCarryingDangerousMaterials;
            }

            set
            {
                m_IsCarryingDangerousMaterials = value;
            }
        }

        public float MaxAllowedWeight
        {
            get
            {
                return m_MaxAllowedWeight;
            }

            set
            {
                m_MaxAllowedWeight = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
The truck is{1} carrying dangerous materials
The truck maximum allowed cargo weight is: {2}", 
base.ToString(),
m_IsCarryingDangerousMaterials == true ? string.Empty : " not",
m_MaxAllowedWeight);
        }
    }
}
