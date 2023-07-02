using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_simulator
{
    public class HalfAdder : ILogicComponent
    {
        private bool[] inputs;
        private bool[] outputs;
        private List<Connection> connections;

        public HalfAdder()
        {
            inputs = new bool[2];
            outputs = new bool[2];
            connections = new List<Connection>();
        }

        public bool GetInput(int pin)
        {
            if (pin >= 0 && pin < inputs.Length)
            {
                return inputs[pin];
            }
            else
            {
                throw new InvalidPinException(pin + " is not a valid input pin.");
            }
        }

        public bool GetOutput(int pin)
        {
            if (pin >= 0 && pin < outputs.Length)
            {
                return outputs[pin];
            }
            else
            {
                throw new InvalidPinException(pin + " is not a valid output pin.");
            }
        }

        public void SetInput(int pin, bool value)
        {
            if (pin >= 0 && pin < inputs.Length)
            {
                inputs[pin] = value;
                CalculateOutput();
            }
            else
            {
                throw new InvalidPinException(pin + " is not a valid input pin.");
            }
        }

        public void ConnectOutput(int outputPin, ILogicComponent other, int inputPin)
        {
            if (outputPin >= 0 && outputPin < outputs.Length)
            {
                Connection connection = new Connection(this, outputPin, other, inputPin);
                connections.Add(connection);
            }
            else
            {
                throw new InvalidPinException(outputPin + " is not a valid output pin.");
            }
        }

        public void CalculateOutput()
        {
            bool inputA = inputs[0];
            bool inputB = inputs[1];

            bool sum = inputA ^ inputB;   // XOR operation
            bool carry = inputA && inputB;   // AND operation

            outputs[0] = sum;
            outputs[1] = carry;

            PropagateOutput();
        }

        private void PropagateOutput()
        {
            foreach (Connection connection in connections)
            {
                connection.Propagate();
            }
        }
    }
}