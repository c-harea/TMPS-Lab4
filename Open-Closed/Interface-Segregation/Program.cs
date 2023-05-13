using System;

// Define interfaces
public interface IRead
{
    void Read();
}

public interface IWrite
{
    void Write();
}

// Classes implementing interfaces
public class Keyboard : IRead
{
    public void Read()
    {
        Console.WriteLine("Reading from keyboard...");
    }
}

public class Mouse : IRead
{
    public void Read()
    {
        Console.WriteLine("Reading from mouse...");
    }
}

public class Screen : IWrite
{
    public void Write()
    {
        Console.WriteLine("Writing to screen...");
    }
}

public class Printer : IWrite
{
    public void Write()
    {
        Console.WriteLine("Writing to printer...");
    }
}

// Client class using interfaces
public class Computer
{
    private IRead inputDevice;
    private IWrite outputDevice;

    public Computer(IRead inputDevice, IWrite outputDevice)
    {
        this.inputDevice = inputDevice;
        this.outputDevice = outputDevice;
    }

    public void ReadFromInputDevice()
    {
        inputDevice.Read();
    }

    public void WriteToOutputDevice()
    {
        outputDevice.Write();
    }
}

// Main program
public class Program
{
    public static void Main()
    {
        // Create instances of input and output devices
        Keyboard keyboard = new Keyboard();
        Screen screen = new Screen();

        // Create instance of computer and use it
        Computer computer1 = new Computer(keyboard, screen);
        computer1.ReadFromInputDevice();
        computer1.WriteToOutputDevice();

        // Create instances of different input and output devices
        Mouse mouse = new Mouse();
        Printer printer = new Printer();

        // Create another instance of computer and use it
        Computer computer2 = new Computer(mouse, printer);
        computer2.ReadFromInputDevice();
        computer2.WriteToOutputDevice();
    }
}
