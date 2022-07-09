using Controllers;
using UnityEngine;

namespace Power.SpecialPowers
{
    [CreateAssetMenu(fileName = "Player Speed Special Power", menuName = "Special Power/Player Speed Special Power")]
    public class PlayerSpeedSpecialPower : SpecialPower
    {
        public override void UsePower()
        {
            inUse = true;
            GameController.Instance.movementController.SetForwardSpeed(amount);
        }

        public override void UnusePower()
        {
            inUse = false;
            GameController.Instance.movementController.SetForwardSpeed(defaultAmount);
        }
    }
}