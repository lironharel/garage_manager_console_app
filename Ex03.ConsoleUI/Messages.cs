using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class Messages
    {
        public const string k_WelcomeUserMessage = "Welcome to Liron Harel's Garage management tool. How may we serve you today?";
        public const string k_EnterLicenseNumberMessage = "Please enter license plate number";
        public const string k_PleaseTryAgainMessage = "Please try again";
        public const string k_EnterAmountToAddMessage = "Please enter amount to add";
        public const string k_GoodByeMessage = "Thank you for using the best garage managment program, Bye Bye!";
        public const string k_GarageIsEmptyMessage = "No vehicles to display, garage is still empty";
        public const string k_LicensePlateByFilterMessage = "Press the number of the desired filter and then press enter";
        public const string k_RefuelSuccessMessage = "Refueled your vehicle succesfully. Enjoy.";
        public const string k_RechargeSuccessMessage = "Recharged your vehicle succesfully. Enjoy.";
        public const string k_ReInflateToMaxSuccessMessage = "Infalted your wheels to maximum. Enjoy.";
        public const string k_Menu = @"Press the number of the desired option and then press enter:
1. Add a new vehicle to the garage
2. Display all license plates numbers
3. Change vehicle status
4. Refuel a vehicle
5. Recharge an electric vehicle 
6. Inflate wheels to maximum
7. Display a vehicle's full details
8. Exit
";

        public const string k_EmptyInputMessage = "The input you have entered is empty. Please try again";

        public enum eMainMenuOptions
        {
            AddNewVehicle = 1,
            DisplayAllLicensePlates = 2,
            ChangeStatus = 3,
            RefuelFuelEngine = 4,
            RechargeElectricEngine = 5,
            InflateWheels = 6,
            DisplayVehicleDetails = 7,
            Exit = 8,
        }

        public static string getEnumAsString(Type i_EnumType)
        {
            int counter = 1;
            StringBuilder enumToString = new StringBuilder();

            foreach (Enum enumValue in Enum.GetValues(i_EnumType))
            {
                if (!enumValue.ToString().Equals("Undefined"))
                {
                    enumToString.Append(counter + ". " + enumValue + Environment.NewLine);
                    counter++;
                }
            }

            return enumToString.ToString();
        }
    }
}
