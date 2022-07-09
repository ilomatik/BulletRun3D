using Controllers;
using UnityEngine;

namespace Power.SpecialPowers
{
    [CreateAssetMenu(fileName = "Fire Rate Special Power", menuName = "Special Power/Fire Rate Special Power")]
    public class FireRateSpecialPower : SpecialPower
    {
        public override void UsePower()
        {
            inUse = true;
            GameController.Instance.fireController.SetFireRate(amount);
        }

        public override void UnusePower()
        {
            inUse = false;
            GameController.Instance.fireController.SetFireRate(defaultAmount);
        }
    }
}