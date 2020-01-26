using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class VehicleStatusFilterProvider
    {
        private UserDisplay m_UserDisplay;

        public VehicleStatusFilterProvider()
        {
            m_UserDisplay = new UserDisplay();
        }

        public Vehicle.eVehicleGarageStatus GetFilter()
        {
            m_UserDisplay.ClearAndDisplayMessage("You have chosen to Display the license numbers of the vehicles whom are currently in the garage");
            m_UserDisplay.DisplayMessage("Would you like to filter according to the status of each vehicle? Press Y for 'Yes' or N For 'No'");
            bool userWantsToFilter = ValidateUserInput.validateYesOrNo();
            Vehicle.eVehicleGarageStatus vehicleStatus;

            if (userWantsToFilter)
            {
                vehicleStatus = ValidateUserInput.GetStateFromUser();
            }
            else
            {
                vehicleStatus = Vehicle.eVehicleGarageStatus.Undefined;
            }

            return vehicleStatus;
        }
    }
}