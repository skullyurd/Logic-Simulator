using Logic_simulator;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Simple AND gate
            AndGate andGate = new AndGate();
            Console.WriteLine("AND Gate");
            Console.WriteLine("A B Q");
            andGate.SetInput(0, false);
            andGate.SetInput(1, false);
            Console.WriteLine($"{andGate.GetInput(0)} {andGate.GetInput(1)} {andGate.GetOutput(0)}");
            andGate.SetInput(0, false);
            andGate.SetInput(1, true);
            Console.WriteLine($"{andGate.GetInput(0)} {andGate.GetInput(1)} {andGate.GetOutput(0)}");
            andGate.SetInput(0, true);
            andGate.SetInput(1, false);
            Console.WriteLine($"{andGate.GetInput(0)} {andGate.GetInput(1)} {andGate.GetOutput(0)}");
            andGate.SetInput(0, true);
            andGate.SetInput(1, true);
            Console.WriteLine($"{andGate.GetInput(0)} {andGate.GetInput(1)} {andGate.GetOutput(0)}");

            // Simple XOR gate
            XorGate xorGate = new XorGate();
            Console.WriteLine("\nXOR Gate");
            Console.WriteLine("A B Q");
            xorGate.SetInput(0, false);
            xorGate.SetInput(1, false);
            Console.WriteLine($"{xorGate.GetInput(0)} {xorGate.GetInput(1)} {xorGate.GetOutput(0)}");
            xorGate.SetInput(0, false);
            xorGate.SetInput(1, true);
            Console.WriteLine($"{xorGate.GetInput(0)} {xorGate.GetInput(1)} {xorGate.GetOutput(0)}");
            xorGate.SetInput(0, true);
            xorGate.SetInput(1, false);
            Console.WriteLine($"{xorGate.GetInput(0)} {xorGate.GetInput(1)} {xorGate.GetOutput(0)}");
            xorGate.SetInput(0, true);
            xorGate.SetInput(1, true);
            Console.WriteLine($"{xorGate.GetInput(0)} {xorGate.GetInput(1)} {xorGate.GetOutput(0)}");

            // Simple NOT gate
            NotGate notGate = new NotGate();
            Console.WriteLine("\nNOT Gate");
            Console.WriteLine("A Q");
            notGate.SetInput(0, false);
            Console.WriteLine($"{notGate.GetInput(0)} {notGate.GetOutput(0)}");
            notGate.SetInput(0, true);
            Console.WriteLine($"{notGate.GetInput(0)} {notGate.GetOutput(0)}");

            // Simple OR gate
            OrGate orGate = new OrGate();
            Console.WriteLine("\nOR Gate");
            Console.WriteLine("A B Q");
            orGate.SetInput(0, false);
            orGate.SetInput(1, false);
            Console.WriteLine($"{orGate.GetInput(0)} {orGate.GetInput(1)} {orGate.GetOutput(0)}");
            orGate.SetInput(0, false);
            orGate.SetInput(1, true);
            Console.WriteLine($"{orGate.GetInput(0)} {orGate.GetInput(1)} {orGate.GetOutput(0)}");
            orGate.SetInput(0, true);
            orGate.SetInput(1, false);
            Console.WriteLine($"{orGate.GetInput(0)} {orGate.GetInput(1)} {orGate.GetOutput(0)}");
            orGate.SetInput(0, true);
            orGate.SetInput(1, true);
            Console.WriteLine($"{orGate.GetInput(0)} {orGate.GetInput(1)} {orGate.GetOutput(0)}");

            // Half Adder
            HalfAdder halfAdder = new HalfAdder();
            Console.WriteLine("\nHalf Adder");
            Console.WriteLine("A B S C");
            halfAdder.SetInput(0, false);
            halfAdder.SetInput(1, false);
            Console.WriteLine($"{halfAdder.GetInput(0)} {halfAdder.GetInput(1)} {halfAdder.GetOutput(0)} {halfAdder.GetOutput(1)}");
            halfAdder.SetInput(0, false);
            halfAdder.SetInput(1, true);
            Console.WriteLine($"{halfAdder.GetInput(0)} {halfAdder.GetInput(1)} {halfAdder.GetOutput(0)} {halfAdder.GetOutput(1)}");
            halfAdder.SetInput(0, true);
            halfAdder.SetInput(1, false);
            Console.WriteLine($"{halfAdder.GetInput(0)} {halfAdder.GetInput(1)} {halfAdder.GetOutput(0)} {halfAdder.GetOutput(1)}");
            halfAdder.SetInput(0, true);
            halfAdder.SetInput(1, true);
            Console.WriteLine($"{halfAdder.GetInput(0)} {halfAdder.GetInput(1)} {halfAdder.GetOutput(0)} {halfAdder.GetOutput(1)}");
                               
            Console.WriteLine("\nTesting Section comes up next\n");
            Console.ReadLine();                                                                                                                     

            // Create gates
            AndGate andGateTest = new AndGate();
            OrGate orGateTest = new OrGate();
            NotGate notGateTest = new NotGate();
            XorGate xorGateTest = new XorGate();

            // Set invalid inputs to test InvalidPinException
            //andGate.SetInput(2, true);
            //notGate.SetInput(1, false);

            // Set inputs
            andGateTest.SetInput(0, true);
            andGateTest.SetInput(1, false);

            orGateTest.SetInput(0, true);
            orGateTest.SetInput(1, true);

            notGateTest.SetInput(0, true);

            xorGateTest.SetInput(0, true);
            xorGateTest.SetInput(1, false);

            // Get outputs
            bool andOutput = andGateTest.GetOutput(0);
            bool orOutput = orGateTest.GetOutput(0);
            bool notOutput = notGateTest.GetOutput(0);
            bool xorOutput = xorGateTest.GetOutput(0);

            Console.WriteLine("AND Gate Output: " + andOutput);
            Console.WriteLine("OR Gate Output: " + orOutput);
            Console.WriteLine("NOT Gate Output: " + notOutput);
            Console.WriteLine("XOR Gate Output: " + xorOutput);

            // Connect gates
            andGateTest.ConnectOutput(0, xorGateTest, 0);
            notGateTest.ConnectOutput(0, xorGateTest, 1);

            // Try connecting the same output pin again to test ConnectionAlreadyCreatedException
            //andGate.ConnectOutput(0, xorGate, 0);

            // Calculate new output after connecting gates
            bool newXorOutput = xorGateTest.GetOutput(0);
            Console.WriteLine("New XOR Gate Output: " + newXorOutput);
        }
        catch (InvalidPinException ex)
        {
            Console.WriteLine("InvalidPinException occurred: " + ex.Message);
        }
        catch (ConnectionAlreadyCreatedException ex)
        {
            Console.WriteLine("ConnectionAlreadyCreatedException occurred: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        Console.WriteLine("Press any key to exit...");
    }
}