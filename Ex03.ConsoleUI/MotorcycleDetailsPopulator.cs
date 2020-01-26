using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class MotorcycleDetailsPopulator
    {
        private UserDisplay m_UserDisplay;

        public MotorcycleDetailsPopulator()
        {
            m_UserDisplay = new UserDisplay();
        }

        public Motorcycle populateMotorcycleWithDetails(Vehicle i_Vehicle)
        {
            Motorcycle motorcycle = (Motorcycle)i_Vehicle;
            motorcycle.LicenseType = assignLicenseType();
            motorcycle.EngineSize = setEngineVolume();
            return motorcycle;
        }

        private Motorcycle.eLicenseType assignLicenseType()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please choose  Motorcycle LicenseType: ");
            return (Motorcycle.eLicenseType)ValidateUserInput.InputIsInRangeOfEnum(typeof(Motorcycle.eLicenseType));
        }

        private int setEngineVolume()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please choose the engine volume: ");
            return ValidateUserInput.ParseInputToInt();
        }
    }
}
