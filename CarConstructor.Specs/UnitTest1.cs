using Machine.Specifications;

namespace CarConstructor.Specs
{
    public class When_Creating_A_Car
    {
        Establish context = () =>
        {
        };

        Because of = () => car = new Car();

        It Should_Return_A_Car_That_Is_Not_Running = () => car.EngineIsRunning.ShouldBeFalse();

        private static Car car;
    }
    public class When_Turning_Motor_On
    {
        Establish context = () =>
        {
            car = new Car();
        };

        Because of = () => car.EngineStart();

        It Should_Have_Started_The_Engine = () => car.EngineIsRunning.ShouldBeTrue();

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
        };

        Because of = () => car.EngineStop();

        It Should_Have_Turned_The_Motor_Off = () => car.EngineIsRunning.ShouldBeFalse();

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
        };

        Because of = () => Enumerable.Range(0, 3000).ToList().ForEach(s => car.RunningIdle());

        It Should_Have_Consumed_Fuel = () => car.fuelTankDisplay.FillLevel.ShouldEqual(.1);

        private static Car car;
    }

    public class When_Running_Out_Of_Fuel
    {
        Establish context = () =>
        {
            car = new Car(.5);
        };

        Because of = () => Enumerable.Range(0, 3000).ToList().ForEach(s => car.RunningIdle());

        It Should_Turn_The_Engine_Off = () => car.EngineIsRunning.ShouldBeFalse();

        private static Car car;
    }
}