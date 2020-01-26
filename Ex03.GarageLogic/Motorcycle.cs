using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private const int k_MaximumWheelPressure = 30;
        private eLicenseType m_LicenseType;
        private int m_EngineSize;

        public enum eLicenseType
        {
            A = 1,
            A1 = 2,
            B1 = 3,
            B2 = 4
        }

        public Motorcycle()
        {
            Wheels = new List<Wheel>(k_NumberOfWheels);
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(k_MaximumWheelPressure));
            }
        }

        public int EngineSize
        {
            get
            {
                return m_EngineSize;
            }

            set
            {
                this.m_EngineSize = value;
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
The Motorcycle license type is: {1}
The Motorcycle engine size is: {2}", 
base.ToString(),
m_LicenseType,
m_EngineSize);
        }
    }
}
