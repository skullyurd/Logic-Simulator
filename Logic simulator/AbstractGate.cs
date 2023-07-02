using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_simulator
{
    public abstract class AbstractGate : ILogicComponent
    {
        protected List<Connection> connections;
        protected bool[] inputs;
        protected bool[] outputs;

        public abstract void CalculateOutput();

        public AbstractGate()
        {
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

        public virtual void ConnectOutput(int outputPin, ILogicComponent other, int inputPin)
        {
            foreach (Connection connection in connections)
            {
                if (connection.SourcePin == outputPin)
                {
                    throw new ConnectionAlreadyCreatedException("A connection already exists for output pin " + outputPin);
                }
            }

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

        public int GetInputCount()
        {
            return inputs.Length;
        }

        public int GetOutputCount()
        {
            return outputs.Length;
        }

        protected void PropagateOutput()
        {
            foreach (Connection connection in connections)
            {
                connection.Propagate();
            }
        }
    }
}
