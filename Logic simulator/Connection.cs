using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_simulator
{
    public class Connection
    {
        private AbstractGate sourceGate;
        private int sourcePin;
        public int SourcePin { get; internal set; }
        private ILogicComponent destinationGate;
        private int destinationPin;
        private HalfAdder halfAdder;
        private int outputPin;
        private ILogicComponent other;
        private int inputPin;

        public Connection(AbstractGate sourceGate, int sourcePin, ILogicComponent destinationGate, int destinationPin)
        {
            this.sourceGate = sourceGate;
            this.sourcePin = sourcePin;
            this.destinationGate = destinationGate;
            this.destinationPin = destinationPin;
        }

        public Connection(HalfAdder halfAdder, int outputPin, ILogicComponent other, int inputPin)
        {
            this.halfAdder = halfAdder;
            this.outputPin = outputPin;
            this.other = other;
            this.inputPin = inputPin;
        }

        public AbstractGate SourceGate { get; internal set; }

        public void Propagate()
        {
            bool value = sourceGate.GetOutput(sourcePin);
            destinationGate.SetInput(destinationPin, value);
        }
    }
}
