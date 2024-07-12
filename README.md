# CarConstruction
https://www.codewars.com/kata/578b4f9b7c77f535fc00002f

DESCRIPTION:
You have to construct a car. Step by Step. Kata by Kata.
First you have to implement the engine and the fuel tank.

The default fuel level of a car is 20 liters.
The maximum size of the tank is 60 liters.
Of course every car's life begins with an engine not running. ;-)

Every call of a method from the car correlates to 1 second.

The fuel consumption in running idle is 0.0003 liter/second.
For convenience the start of the engine consumes nothing and we don't care, if the engine is warm or cold.

The fuel tank is on reserve, if the level is under 5 liters.
The fuel tank display shows the level as rounded for 2 decimal places.
Internally an accuracy up to 10 decimal places should be more than enough.
In difference to most real cars, the fuel tank display is always showing its information, also when the the engine is not running.

And consider the locigal things about fuel and engine... ;-)

In all tests only the whole car will be tested. Feel free to write your own tests for the other classes.

Under the text you will find the code of the interfaces.

Have fun coding it and please don't forget to vote and rank this kata! :-)


This kata is part of a series of katas for constructing a car:

Constructing a car #1 - Engine and Fuel Tank
Constructing a car #2 - Driving
Constructing a car #3 - On-Board Computer

The next parts will be coming soon...



<pre>
public interface ICar
{
    bool EngineIsRunning { get; }

    void EngineStart();

    void EngineStop();

    void Refuel(double liters);

    void RunningIdle();
}
</pre>
<pre>
public interface IEngine
{
    bool IsRunning { get; }

    void Consume(double liters);

    void Start();

    void Stop();
}
</pre>
<pre>
public interface IFuelTank
{
    double FillLevel { get; }

    bool IsOnReserve { get; }

    bool IsComplete { get; }

    void Consume(double liters);

    void Refuel(double liters);        
}
</pre>
<pre>
public interface IFuelTankDisplay
{
    double FillLevel { get; }

    bool IsOnReserve { get; }

    bool IsComplete { get; }
}
</pre>
