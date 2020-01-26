using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class UserMenu
    {
        private GarageController m_GarageController;
        private UserDisplay m_UserDisplay;

        public UserMenu()
        {
            m_GarageController = new GarageController(new Garage());
            m_UserDisplay = new UserDisplay();
        }

        public void ServeUser()
        {
            int userChoise = 0;
            m_UserDisplay.DisplayMessage(Messages.k_WelcomeUserMessage);
            m_UserDisplay.ReadLine();

            while (userChoise != (int)Messages.eMainMenuOptions.Exit)
            {
                m_UserDisplay.ClearAndDisplayMessage(Messages.k_Menu);
                userChoise = ValidateUserInput.getUserChoice();
                if (userChoise == (int)Messages.eMainMenuOptions.AddNewVehicle)
                {
                    m_GarageController.AddVehicleToGarage();
                }
                else if (userChoise == (int)Messages.eMainMenuOptions.DisplayAllLicensePlates)
                {
                    m_GarageController.displayLicenseNumbersList();
                }
                else if (userChoise == (int)Messages.eMainMenuOptions.ChangeStatus)
                {
                    m_GarageController.changeCarStatus();
                }
                else if (userChoise == (int)Messages.eMainMenuOptions.RefuelFuelEngine)
                {
                    m_GarageController.refuelGasVehicle();
                }
                else if (userChoise == (int)Messages.eMainMenuOptions.RechargeElectricEngine)
                {
                    m_GarageController.chargeElectricVehicle();
                }
                else if (userChoise == (int)Messages.eMainMenuOptions.InflateWheels)
                {
                    m_GarageController.InflateTires();
                }
                else if (userChoise == (int)Messages.eMainMenuOptions.DisplayVehicleDetails)
                {
                    m_GarageController.printVehicleDetails();
                }
            }

            m_UserDisplay.GoodByePrinter();
        }
    }
}
