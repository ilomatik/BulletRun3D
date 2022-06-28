using DG.Tweening;
using Managers;
using Power;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpecialPowerButton : MonoBehaviour
{
    [Header("Components")] 
    [SerializeField] private Transform moveableObjectTransform;
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

    public void OnClick()
    {
        if (specialPower.inUse)
        {
            moveableObjectTransform.DOLocalMoveY(0f, moveDuration);
            specialPower.UnusePower();
            PowerManager.OnSpecialPowerUnselect?.Invoke(specialPower);
        }
        else
        {
            moveableObjectTransform.DOLocalMoveY(moveHeight, moveDuration);
            specialPower.UsePower();
            PowerManager.OnSpecialPowerSelect?.Invoke(specialPower);
        }
    }

    private void SetButtonInteractable(bool isInteractable)
    {
        if (specialPower.inUse) return;

        button.interactable = isInteractable;
    }
}