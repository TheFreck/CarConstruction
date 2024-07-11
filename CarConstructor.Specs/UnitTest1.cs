using Machine.Specifications;

namespace CarConstructor.Specs
{
    public class When_Creating_A_Car
    {
        Establish context = () =>
        {
            fuelLevel = 35;
        };

        Because of = () => car = new Car(fuelLevel);

        It Should_Have_Created_A_Fuel_Tank = () => car.fuelTank.ShouldNotBeNull();
        It Should_Have_Created_A_Fuel_Tank_Display = () => car.fuelTankDisplay.ShouldNotBeNull();
        It Should_Have_Created_An_Engine = () => car.engine.ShouldNotBeNull();
        It Should_Have_Filled_The_Fuel_Tank = () => car.fuelTankDisplay.FillLevel.ShouldEqual(fuelLevel);

        private static Car car;
        private static double fuelLevel;
    }
    public class When_Turning_Motor_On
    {
        Establish context = () =>
        {
            car = new Car();
            expectOn = true;
        };

        Because of = () => car.EngineStart();

        It Should_Have_Started_The_Engine = () => car.EngineIsRunning.ShouldEqual(expectOn);

        static Car car;
        static bool expectOn;
        static bool expectOff;
        private static object answer;
    }

    public class When_Turning_Motor_Off
    {
        Establish context = () =>
        {
            car = new Car();
            car.EngineStart();
            expectOff = false;
        };

        Because of = () => car.EngineStop();

        It Should_Have_Turned_The_Motor_Off = () => car.EngineIsRunning.ShouldEqual(expectOff);

        static Car car;
        static bool expectOn;
        static bool expectOff;
        private static object answer;
    }

    public class When_Idling
    {
        Establish context = () =>
        {
            car = new Car(1);
            car.EngineStart();
            Enumerable.Range(0, 3000).ToList().ForEach(s => car.RunningIdle());
            expect = 0.10;
        };

        Because of = () => car.fuelTankDisplay.FillLevel.ShouldEqual(expect);

        It Should_Use_Some_Of_Its_Fuel = () => car.fuelTankDisplay.FillLevel.ShouldEqual(expect);

        private static Car car;
        private static double expect;
    }

    public class When_FuelTankDisplay_Is_Complete
    {
        Establish context = () =>
        {
        };

        Because of = () => car = new Car(60);

        It Should_Show_The_Fuel_Tank_Complete = () => car.fuelTankDisplay.IsComplete.ShouldBeTrue();

        private static Car car;
    }

    public class When_Fuel_Tank_Is_On_Reserves
    {
        Establish context = () =>
        {
        };

        Because of = () => car = new Car(4);

        It Should_Display_On_Reserves = () => car.fuelTankDisplay.IsOnReserve.ShouldBeTrue();

        private static Car car;
    }
}