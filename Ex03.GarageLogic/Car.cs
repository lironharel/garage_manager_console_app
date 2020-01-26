using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Car : Vehicle
    {
        private const int k_NumberOfWheels = 4;
        private const int k_MaximumWheelPressure = 32;
        private eNumberOfDoors m_NumberOfDoors;
        private eCarColor m_Color;

        public Car()
        {
            Wheels = new List<Wheel>(k_NumberOfWheels);
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(k_MaximumWheelPressure));
            }
        }

        public enum eCarColor
        {
            Grey = 1,
            Blue = 2,
            White = 3,
            Black = 4
        }

        public enum eNumberOfDoors
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }

        public eCarColor Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }

            set
            {
                m_NumberOfDoors = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
Number of doors is: {1}
Car color is: {2}",
base.ToString(),
m_NumberOfDoors,
m_Color);
        }
    }
}
