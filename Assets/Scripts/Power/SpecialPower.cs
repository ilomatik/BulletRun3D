using Events;
using UnityEngine;

namespace Power
{
    public enum PowerType
    {
        TripleAngleFire,
        DoubleFire,
        IncreaseFireRate,
        BulletSpeed,
        PlayerSpeed
    }
    
    [CreateAssetMenu(fileName = "Special Power", menuName = "Player Power/Special Power")]
    public class SpecialPower : ScriptableObject
    {
        public GameEvent onSpecialPowerActive;
        public GameEvent onSpecialPowerDeActive;
        public string description;
        public PowerType powerType;
        public float amount;
        public bool inUse;

        private void OnEnable()
        {
            inUse = false;
        }

        public void UsePower()
        {
            inUse = true;
            ActivePower();
        }

        public void UnusePower()
        {
            inUse = false;
            DeActivePower();
        }

        private void ActivePower()
        {
            onSpecialPowerActive.RaisePowerType(powerType, amount);
        }
        
        private void DeActivePower()
        {
            onSpecialPowerDeActive.RaisePowerType(powerType, amount);
        }
    }
}