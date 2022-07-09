using Controllers;
using UnityEngine;

namespace Power.SpecialPowers
{
    [CreateAssetMenu(fileName = "Angler Fire Special Power", menuName = "Special Power/Angler Fire Special Power")]
    public class AnglerFireSpecialPower : SpecialPower
    {
        public override void UsePower()
        {
            inUse = true;
            GameController.Instance.fireController.SetIsFireTripleFire(true);
        }

        public override void UnusePower()
        {
            inUse = false;
            GameController.Instance.fireController.SetIsFireTripleFire(false);
        }
    }
}