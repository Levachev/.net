// See https://aka.ms/new-console-template for more information

using System;

class Application  {
    static void Main(){
        Simulator simulator = new Simulator(1000000);
        int succesCounter = simulator.simulate("simple", "random");
        Console.WriteLine("succes case number is "+succesCounter);
    }
}
