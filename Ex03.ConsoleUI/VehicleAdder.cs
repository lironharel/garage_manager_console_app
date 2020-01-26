using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    internal class VehicleAdder
    {
        private UserDisplay m_UserDisplay;

        public VehicleAdder()
        {
            m_UserDisplay = new UserDisplay();
        }

        public Vehicle getVitalDetailsFromUser()
        {
            m_UserDisplay.ClearAndDisplayMessage("You have chosen to add a new vehicle");

            Vehicle m_CreatedVehicle = createVehicleFromFactory(getVehicleType());
            m_CreatedVehicle.LicenseNumber = getLicensePlateNumber();
            return m_CreatedVehicle;
        }

        public Vehicle populateVehicleWithDetails(Vehicle vehicle)
        {
            vehicle.ModelName = getCarModel();
            setCurrentAmountOfEnergy(vehicle);
            vehicle.SetEnergyPercentge();
            addWheelsManufacturer(vehicle.Wheels);
            setWheelsCurrentAirPressure(vehicle.Wheels);
            vehicle.OwnerName = getUsersName();
            vehicle.OwnerPhoneNumber = getUsersPhoneNumber();
            vehicle = CreateSpecificTypeOfVehicle(vehicle);

            return vehicle;
        }

        private Vehicle CreateSpecificTypeOfVehicle(Vehicle vehicle)
        {
            if (vehicle is Car)
            {
                vehicle = new CarDetailsPopulator().populateCarWithDetails(vehicle);
            }
            else if (vehicle is Motorcycle)
            {
                vehicle = new MotorcycleDetailsPopulator().populateMotorcycleWithDetails(vehicle);
            }
            else
            {
                vehicle = new TruckDetailsPopulator().populateTruckWithDetails(vehicle);
            }

            return vehicle;
        }

        private string getLicensePlateNumber()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please enter the license number of the vehicle you want to add");
            return ValidateUserInput.GetLicensePlateFromUser();
        }

        private VehicleFactory.eVehicleTypes getVehicleType()
        {
            m_UserDisplay.DisplayMessage("Please choose one of the following vehicle types:");
            return (VehicleFactory.eVehicleTypes)ValidateUserInput.InputIsInRangeOfEnum(typeof(VehicleFactory.eVehicleTypes));
        }

        private Vehicle createVehicleFromFactory(VehicleFactory.eVehicleTypes i_VehicleType)
        {
            return VehicleFactory.CreateVehicle(i_VehicleType);
        }

        private string getCarModel()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please enter the vehicle model name");
            string carModelName = ValidateUserInput.ValidateInputInNotEmpty();
            return carModelName;
        }

        private void addWheelsManufacturer(List<Wheel> wheels)
        {
            m_UserDisplay.ClearAndDisplayMessage("Please enter Wheels Manufacturer name");
            string ManufacturerOfWheels = ValidateUserInput.ValidateInputInNotEmpty();

            foreach (Wheel wheel in wheels)
            {
                wheel.Manufacturer = ManufacturerOfWheels;
            }
        }

        private void setWheelsCurrentAirPressure(List<Wheel> wheels)
        {
            m_UserDisplay.ClearAndDisplayMessage("Please enter the current air pressure of the wheels");

            float currentAirPressure = ValidateUserInput.ParseInputToFloat();

            try
            {
                foreach (Wheel wheel in wheels)
                {
                    wheel.PumpAir(currentAirPressure);
                }
            }
            catch (Exception exception)
            {
                m_UserDisplay.displayExceptionMessage(exception);
                m_UserDisplay.ReadLine();
                setWheelsCurrentAirPressure(wheels);
            }
        }

        private string getUsersName()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please tell us your name");
            return ValidateUserInput.ValidateInputInNotEmpty();
        }

        private string getUsersPhoneNumber()
        {
            m_UserDisplay.ClearAndDisplayMessage("Please tell us your phone number");
            return ValidateUserInput.ValidateInputInNotEmpty();
        }

        private void setCurrentAmountOfEnergy(Vehicle i_Vehicle)
        {
            if (i_Vehicle.EnergySource is Gas)
            {
                m_UserDisplay.ClearAndDisplayMessage("Please enter current amount of fuel in liters");
            }
            else
            {
                m_UserDisplay.ClearAndDisplayMessage("Please enter remaining time of engine operation in hours");
            }

            float amountOfEnergy = ValidateUserInput.ParseInputToFloat();

            try
            {
                i_Vehicle.EnergySource.FillEnergy(amountOfEnergy);
            }
            catch (Exception exception)
            {
                m_UserDisplay.displayExceptionMessage(exception);
                m_UserDisplay.ReadLine();
                setCurrentAmountOfEnergy(i_Vehicle);
            }
        }
    }
}
