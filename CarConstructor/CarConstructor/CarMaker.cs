using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConstructor
{
    public interface ICar
    {
        void EngineStart();
        void EngineStop();
        void Refuel(double fuel);
        void RunningIdle();
    }

    public interface IFuelTankDisplay
    {
        double FillLevel { get; set; }
        bool IsComplete { get; set; }
        bool IsOnReserve { get; set; }
    }
    public interface IEngine
    {
        void SetIsRunning(bool isRunning);
        bool GetIsRunning();
    }
    public interface IFuelTank
    {
        void SetFuelLevel(double fuelLevel);
        double GetFuelLevel();
    }
    public class Car : ICar
    {
        public IFuelTankDisplay fuelTankDisplay;
        public IEngine engine;
        public IFuelTank fuelTank;
        public bool EngineIsRunning => engine.GetIsRunning();

        public Car()
        {
            fuelTankDisplay = new FuelTankDisplay();
            engine = new Engine();
            fuelTank = new FuelTank();
        }

        public Car(double fuelLevel)
        {
            fuelTankDisplay = new FuelTankDisplay();
            engine = new Engine();
            fuelTank = new FuelTank();
            fuelTank.SetFuelLevel(fuelLevel);
            fuelTankDisplay.FillLevel = fuelLevel;
        }

        public void EngineStart()
        {
            engine.SetIsRunning(true);
        }

        public void EngineStop()
        {
            engine.SetIsRunning(false);
        }

        public void Refuel(double fuel)
        {
            fuelTank.SetFuelLevel(fuel);
        }

        public void RunningIdle()
        {
            var fuelConsumption = 0.0003;
            var newLevel = fuelTank.GetFuelLevel() - fuelConsumption;
            fuelTank.SetFuelLevel(newLevel);
            fuelTankDisplay.FillLevel = newLevel;
        }
    }

    public class Engine : IEngine
    {
        private bool IsRunning { get; set; }
        public void SetIsRunning(bool isRunning)
        {
            IsRunning = isRunning;
        }

        public bool GetIsRunning() => IsRunning;

    }
    public class FuelTank : IFuelTank
    {
        public double FuelLevel = 20;
        public void SetFuelLevel(double fuelLevel)
        {
            FuelLevel = fuelLevel;
        }
        public double GetFuelLevel() => FuelLevel;
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        public double MaxFuelLevel = 60;
        private double fillLevel;
        public double FillLevel
        {
            get { return double.Parse(fillLevel.ToString("0.00")); }
            set { fillLevel = value; }
        }
        public bool IsComplete
        {
            get { return fillLevel == MaxFuelLevel; }
            set { }
        }
        public bool IsOnReserve
        {
            get { return fillLevel < 5; }
            set { }
        }
    }
}
