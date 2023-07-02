using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_simulator
{
    public class NotGate : AbstractGate
    {
        public NotGate()
        {
            inputs = new bool[1];
            outputs = new bool[1];
            connections = new List<Connection>();
        }

        public override void CalculateOutput()
        {
            outputs[0] = !inputs[0];
            PropagateOutput();
        }
        public override void ConnectOutput(int outputPin, ILogicComponent other, int inputPin)
        {
            try
            {
                base.ConnectOutput(outputPin, other, inputPin);
            }
            catch (ConnectionAlreadyCreatedException ex)
            {
                throw ex;
            }
            catch (InvalidPinException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
