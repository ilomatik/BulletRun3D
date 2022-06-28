using System;
using System.Collections.Generic;
using Power;
using UnityEngine;

namespace Managers
{
    public class PowerManager : MonoBehaviour
    {
        private List<SpecialPower> inUseSpecialPowers = new List<SpecialPower>();

        public static Action<SpecialPower> OnSpecialPowerSelect;
        public static Action<SpecialPower> OnSpecialPowerUnselect;
        public static Action<bool> OnSpecialPowerListCountChange;

        private void Awake()
        {
            OnSpecialPowerSelect += AddSpecialPowerInUseList;
            OnSpecialPowerUnselect += RemoveSpecialPowerInUseList;
        }

        private void OnDestroy()
        {
            OnSpecialPowerSelect += AddSpecialPowerInUseList;
            OnSpecialPowerUnselect += RemoveSpecialPowerInUseList;
        }

        private void AddSpecialPowerInUseList(SpecialPower addedSpecialPower)
        {
            inUseSpecialPowers.Add(addedSpecialPower);
            
            OnSpecialPowerListCountChange?.Invoke(inUseSpecialPowers.Count < 3);
        }

        private void RemoveSpecialPowerInUseList(SpecialPower removedSpecialPower)
        {
            inUseSpecialPowers.Remove(removedSpecialPower);
            
            OnSpecialPowerListCountChange?.Invoke(inUseSpecialPowers.Count < 3);
        }
    }
}
