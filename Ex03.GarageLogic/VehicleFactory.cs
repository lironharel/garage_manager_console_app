using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class VehicleFactory
    {
        public static Vehicle CreateVehicle(eVehicleTypes i_VehicleTypeAsInt)
        {
            eVehicleTypes vehicleType = (eVehicleTypes)i_VehicleTypeAsInt;
            Vehicle createdVehicle;
            switch (vehicleType)
            {
                case eVehicleTypes.GasMotorcycle:
                    createdVehicle = new GasMotorcycle();
                    break;
                case eVehicleTypes.ElectricMotorcycle:
                    createdVehicle = new ElectricMotorcycle();
                    break;
                case eVehicleTypes.GasCar:
                    createdVehicle = new GasCar();
                    break;
                case eVehicleTypes.ElectricCar:
                    createdVehicle = new ElectricCar();
                    break;
                case eVehicleTypes.GasTruck:
                    createdVehicle = new GasTruck();
                    break;
                default:
                    throw new Exception("This kind of vehicle is not supported in the garage");
            }

            return createdVehicle;
        }

        public enum eVehicleTypes
        {
            GasMotorcycle = 1,
            ElectricMotorcycle = 2,
            GasCar = 3,
            ElectricCar = 4,
            GasTruck = 5
        }
    }
}
