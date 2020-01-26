using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class GarageController
    {
        private Garage m_Garage;
        private VehicleAdder m_VehicleAdder;
        private UserDisplay m_UserDisplay;
        private VehicleStatusFilterProvider m_LicenseNumberFilter;
        private ChangeStatusDetailsProvider m_ChangeStatus;
        private RechargeElectricDetailsProvider m_ChargeElectricVehicle;
        private RefuelGasDetailsProvider m_RefuelGasVehicle;

        public GarageController(Garage i_Garage)
        {
            m_Garage = i_Garage;
            this.m_VehicleAdder = new VehicleAdder();
            this.m_UserDisplay = new UserDisplay();
            this.m_LicenseNumberFilter = new VehicleStatusFilterProvider();
            this.m_ChangeStatus = new ChangeStatusDetailsProvider();
            this.m_ChargeElectricVehicle = new RechargeElectricDetailsProvider();
            this.m_RefuelGasVehicle = new RefuelGasDetailsProvider();
        }

        public void chargeElectricVehicle()
        {
            m_UserDisplay.ClearAndDisplayMessage("You have chosen to recharge an Electric type vehicle");
            string licenseNumber = m_ChargeElectricVehicle.GetLicenseNumberForCharging();
            float amountOfTimeToCharge = m_ChargeElectricVehicle.GetAmountOfMinutesToCharge();

            try
            {
                m_Garage.RechargeElectricVehicle(licenseNumber, amountOfTimeToCharge);
                m_UserDisplay.ClearAndDisplayMessage(string.Format("Vehicle with license number: {0}, with amount: {1} successfuly!", licenseNumber, amountOfTimeToCharge));
                m_UserDisplay.PressAnyKeyToContinue();
            }
            catch (Exception exception)
            {
                m_UserDisplay.ClearAndDisplayMessage(exception.Message);

                if (exception is ValueOutOfRangeException)
                {
                    m_UserDisplay.DisplayMessage(Messages.k_PleaseTryAgainMessage);
                    chargeElectricVehicle();
                }
                else
                {
                    m_UserDisplay.PressAnyKeyToContinue();
                }
            }
        }

        public void printVehicleDetails()
        {
            m_UserDisplay.ClearAndDisplayMessage("You have chosen to get a vehicle details");
            m_UserDisplay.DisplayMessage("Please enter the license number of the vehicle to show its details");

            try
            {
                string licenseNumber = ValidateUserInput.GetLicensePlateFromUser();
                m_Garage.IsVehicleInGarageException(licenseNumber);
                m_UserDisplay.Clear();
                m_UserDisplay.DisplayMessage(m_Garage.GetVehicleByLicenseNumber(licenseNumber).ToString());
            }
            catch (ArgumentException exception)
            {
                m_UserDisplay.displayExceptionMessage(exception);
            }
            finally
            {
                m_UserDisplay.PressAnyKeyToContinue();
            }
        }

        public void changeCarStatus()
        {
            m_UserDisplay.ClearAndDisplayMessage("You have chosen to change the status of a vehicle who is in the garage");
            try
            {
                m_Garage.ChangeVehicleStatus(m_ChangeStatus.GetLicenseNumberForChangingStatus(), m_ChangeStatus.GetGarageStatus());
                m_UserDisplay.ClearAndDisplayMessage("Vehicle status changed!");
            }
            catch (Exception exception)
            {
                m_UserDisplay.displayExceptionMessage(exception);
            }
            finally
            {
                m_UserDisplay.PressAnyKeyToContinue();
            }
        }

        public void displayLicenseNumbersList()
        {
            Vehicle.eVehicleGarageStatus vehicleStatus = m_LicenseNumberFilter.GetFilter();
            List<string> licenseNumbers;

            if (vehicleStatus.Equals(Vehicle.eVehicleGarageStatus.Undefined))
            {
                licenseNumbers = m_Garage.GetLicenseNumberList();
            }
            else
            {
                licenseNumbers = m_Garage.GetLicenseNumberList(vehicleStatus);
            }

            m_UserDisplay.Clear();
            m_UserDisplay.DisplayAccordingToSize(licenseNumbers, "There are no vehicles for your choice in the garage", "The list of plates that you requested: ");
            Console.ReadLine();
        }

        public void AddVehicleToGarage()
        {
            try
            {
                Vehicle vehicle = this.m_VehicleAdder.getVitalDetailsFromUser();
                m_Garage.AddVehicleToGarage(vehicle);
                vehicle = this.m_VehicleAdder.populateVehicleWithDetails(vehicle);
                m_UserDisplay.ClearAndDisplayMessage("Vehicle added to garage");
            }
            catch (Exception exception)
            {
                m_UserDisplay.ClearAndDisplayMessage(exception.Message);
            }
            finally
            {
                m_UserDisplay.PressAnyKeyToContinue();
            }
        }

        public void InflateTires()
        {
            m_UserDisplay.ClearAndDisplayMessage("You have chosen to Inflate a vehicle tires to maximum");
            m_UserDisplay.DisplayMessage("Please enter the license number of the vehicle you want to inflate air to");
            string licensePlate = ValidateUserInput.GetLicensePlateFromUser();

            try
            {
                m_Garage.FillAirToMaximum(licensePlate);
                m_UserDisplay.ClearAndDisplayMessage(string.Format("{0} Wheels pumped to Maximum!", licensePlate));
            }
            catch (Exception exception)
            {
                m_UserDisplay.ClearAndDisplayMessage(exception.Message);
            }
            finally
            {
                m_UserDisplay.PressAnyKeyToContinue();
            }
        }

        public void refuelGasVehicle()
        {
            string licenseNumber = m_RefuelGasVehicle.GetLicenseNumberForRefuel();
            Gas.eGasType fuelType = m_RefuelGasVehicle.GetFuelTypeForRefuel();
            float amountOfFuel = m_RefuelGasVehicle.GetAmountOfLitersToFuel();

            try
            {
                m_Garage.RefuelGasVehicle(licenseNumber, fuelType, amountOfFuel);
                m_UserDisplay.ClearAndDisplayMessage(string.Format("Vehicle with license number: {0}, was refueled with gas type: {1}, and amount: {2} successfuly!", licenseNumber, fuelType, amountOfFuel));
                m_UserDisplay.PressAnyKeyToContinue();
            }
            catch (Exception exception)
            {
                m_UserDisplay.ClearAndDisplayMessage(exception.Message);

                if (exception is ValueOutOfRangeException)
                {
                    m_UserDisplay.DisplayMessage(Messages.k_PleaseTryAgainMessage);
                    m_UserDisplay.ReadLine();
                    refuelGasVehicle();
                }
                else
                {
                    m_UserDisplay.PressAnyKeyToContinue();
                }
            }
        }
    }
}
