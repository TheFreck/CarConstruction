using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConstructor
{
    public interface ICar
    {
        bool EngineIsRunning { get; }
        void EngineStart();
        void EngineStop();
        void Refuel(double liters);
        void RunningIdle();
    }

    public interface IFuelTankDisplay
    {
        double FillLevel { get; }
        bool IsOnReserve { get; }
        bool IsComplete { get; }
    }
    public interface IEngine
    {
        bool IsRunning { get; }
        void Consume(double liters);
        void Start();
        void Stop();
    }
    public interface IFuelTank
    {
        double FillLevel { get; }
        bool IsOnReserve { get; }
        bool IsComplete { get; }
        void Consume(double liters);
        void Refuel(double liters);
    }

    public class Car : ICar
    {
        public IFuelTankDisplay fuelTankDisplay;
        private IEngine engine;
        private IFuelTank fuelTank;

        public Car()
        {
            fuelTank = new FuelTank();
            fuelTank.Refuel(20);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
        }

        public Car(double fuelLevel)
        {
            fuelTank = new FuelTank();
            fuelTank.Refuel(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
        }

        public bool EngineIsRunning => engine.IsRunning;

        public void EngineStart()
        {
            Console.WriteLine($"car says start: {fuelTank.FillLevel}");
            engine.Start();
        }

        public void EngineStop()
        {
            Console.WriteLine($"car says stop: {fuelTank.FillLevel}");
            RunningIdle();
            engine.Stop();
        }

        public void Refuel(double liters)
        {
            Console.WriteLine($"refuel: {fuelTank.FillLevel}");
            fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            if(engine.IsRunning) fuelTank.Consume(0.0003);
        }
    }

    public class Engine : IEngine
    {
        private readonly IFuelTank fuelTank;
        private bool isRunning;

        public Engine(IFuelTank tank)
        {
            fuelTank = tank;
        }
        public bool IsRunning => isRunning;

        public void Consume(double liters)
        {
            if (fuelTank.FillLevel >= liters && isRunning) fuelTank.Consume(liters);
            else
            {
                Console.WriteLine("engine ran out of gas");
                Stop();
            }
        }

        public void Start()
        {
            Console.WriteLine($"engine says start: {fuelTank.FillLevel}");
            isRunning = true;
        }

        public void Stop()
        {
            Console.WriteLine($"engine says stop: {fuelTank.FillLevel}");
            isRunning = false;
        }
    }
    public class FuelTank : IFuelTank
    {
        private double fillLevel;
        public double FillLevel => fillLevel;

        public bool IsOnReserve => fillLevel < 5;

        public bool IsComplete => fillLevel == 60;

        public void Consume(double liters)
        {
            fillLevel -= fillLevel + liters >= 0? liters : fillLevel;
        }

        public void Refuel(double liters)
        {
            if(liters > 0)
            {
                fillLevel += fillLevel + liters <= 60 ? liters : 60-fillLevel;
            }
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        private readonly IFuelTank fuelTank;
        public FuelTankDisplay(IFuelTank tank)
        {
            fuelTank = tank;
        }
        public double FillLevel => Math.Round(fuelTank.FillLevel,2);

        public bool IsOnReserve => fuelTank.IsOnReserve;

        public bool IsComplete => fuelTank.IsComplete;
    }
}
