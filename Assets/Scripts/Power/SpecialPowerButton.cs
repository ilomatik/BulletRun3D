using Events;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Power
{
    public class SpecialPowerButton : MonoBehaviour
    {
        [Header("Events")] 
        [SerializeField] private GameEvent onSpecialPowerButtonAdd;
        [SerializeField] private GameEvent onSpecialPowerButtonRemove;

        [Header("Components")] 
        [SerializeField] private TextMeshProUGUI buttonText;

        [Header("Variables")] 
        [SerializeField] private float moveHeight;
        [SerializeField] private float moveDuration;
        [SerializeField] private SpecialPower specialPower;

        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            buttonText.text = specialPower.description;
            PowerManager.OnSpecialPowerListCountChange += SetButtonInteractable;
        }

        private void OnDestroy()
        {
            PowerManager.OnSpecialPowerListCountChange -= SetButtonInteractable;
        }

        public void InvokeOnClickEvent()
        {
            if (specialPower.inUse)
            {
                onSpecialPowerButtonAdd.RaiseSpecialPower(specialPower);
            }
            else
            {
                onSpecialPowerButtonRemove.RaiseSpecialPower(specialPower);
            }
        }

        public void MoveButton()
        {
            if (specialPower.inUse)
            {
                this.ToDown(0f, moveDuration);
            }
            else
            {
                this.ToUp(moveHeight, moveDuration);
            }
        }

        public void SetPowerUsage()
        {
            if (specialPower.inUse)
            {
                specialPower.UnusePower();
            }
            else
            {
                specialPower.UsePower();
            }
        }

        private void SetButtonInteractable(bool isInteractable)
        {
            if (specialPower.inUse) return;

            button.interactable = isInteractable;
        }
    }
}