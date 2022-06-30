using System;
using System.Collections.Generic;
using Power;
using UnityEngine;

namespace Managers
{
    public class PowerManager : MonoBehaviour
    {
        [SerializeField] private DefaultStatsHolder defaultStats;
        
        private List<SpecialPower> inUseSpecialPowers = new List<SpecialPower>();
        public static Action<bool> OnSpecialPowerListCountChange;

        public void AddSpecialPowerInUseList(SpecialPower addedSpecialPower)
        {
            inUseSpecialPowers.Add(addedSpecialPower);
            
            OnSpecialPowerListCountChange?.Invoke(inUseSpecialPowers.Count < 3);
        }

        public void RemoveSpecialPowerInUseList(SpecialPower removedSpecialPower)
        {
            inUseSpecialPowers.Remove(removedSpecialPower);
            
            OnSpecialPowerListCountChange?.Invoke(inUseSpecialPowers.Count < 3);
        }
    }
}
