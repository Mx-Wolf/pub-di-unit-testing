using Aweton.Mxw.App;

namespace Aweton.Mxw.BrainPower
{
    public class BrainPowerSupply : IPowerSupply
    {
        bool IPowerSupply.IsOnBattery()
        {
            return true;
        }
    }
}
