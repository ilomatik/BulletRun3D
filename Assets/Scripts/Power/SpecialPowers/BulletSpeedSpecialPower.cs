using Controllers;
using UnityEngine;

namespace Power.SpecialPowers
{
    [CreateAssetMenu(fileName = "Bullet Speed Special Power", menuName = "Special Power/Bullet Speed Special Power")]
    public class BulletSpeedSpecialPower : SpecialPower
    {
        public override void UsePower()
        {
            inUse = true;
            GameController.Instance.fireController.SetBulletSpeed(amount);
        }

        public override void UnusePower()
        {
            inUse = false;
            GameController.Instance.fireController.SetBulletSpeed(defaultAmount);
        }
    }
}