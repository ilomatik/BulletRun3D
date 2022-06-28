using System;
using UnityEngine;

namespace Power
{
    public enum Powers
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
        public string description;
        public Powers powers;
        public float amount;
        public bool inUse;

        public void UsePower()
        {
            Debug.Log("UsePower is working");
            inUse = true;
            ActivePower();
        }

        public void UnusePower()
        {
            Debug.Log("UnusePower is working");
            inUse = false;
        }

        private void ActivePower()
        {
            switch (powers)
            {
                case Powers.TripleAngleFire:
                    // side bullets move with 'amount' degree angle
                    break;
                case Powers.DoubleFire:
                    // fires double bullet in 'amount' seconds
                    break;
                case Powers.IncreaseFireRate:
                    // fire rate will be 'amount' second
                    break;
                case Powers.BulletSpeed:
                    // increase bullet speed 'amount' percent 
                    break;
                case Powers.PlayerSpeed:
                    // player speed *= 'amount'
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}