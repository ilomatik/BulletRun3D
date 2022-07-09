using UnityEngine;

namespace Power
{
    public abstract class SpecialPower : ScriptableObject
    {
        public string description;
        public float defaultAmount;
        public float amount;
        public bool inUse;

        private void OnEnable()
        {
            inUse = false;
        }

        public abstract void UsePower();

        public abstract void UnusePower();
    }
}