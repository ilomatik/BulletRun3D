using Controllers;
using UnityEngine;

namespace Power.SpecialPowers
{
    [CreateAssetMenu(fileName = "Double Fire Special Power", menuName = "Special Power/Double Fire Special Power")]
    public class DoubleFireSpecialPower : SpecialPower
    {
        public override void UsePower()
        {
            inUse = true;
            GameController.Instance.fireController.SetDoubleFire(true);
        }

        public override void UnusePower()
        {
            inUse = false;
            GameController.Instance.fireController.SetDoubleFire(false);
        }
    }
}