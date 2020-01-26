using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class TruckDetailsPopulator
    {
        private UserDisplay m_UserDisplay;

        public TruckDetailsPopulator()
        {
            m_UserDisplay = new UserDisplay();
        }

        public Truck populateTruckWithDetails(Vehicle i_Vehicle)
        {
            Truck truck = (Truck)i_Vehicle;
            truck.IsCarryingDangerousMaterials = setIfCarryingDangerousMaterials();
            truck.MaxAllowedWeight = setMaxCarrey();
            return truck;
        }

        private bool setIfCarryingDangerousMaterials()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please choose whether the truck will carry dangerous materials chose Y to 'Yes' and N to 'No'");
            return ValidateUserInput.validateYesOrNo();
        }

        private float setMaxCarrey()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please choose the truck maximum volume of cargo");
            return ValidateUserInput.ParseInputToFloat();
        }
    }
}
