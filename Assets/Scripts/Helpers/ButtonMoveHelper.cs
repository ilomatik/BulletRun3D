using DG.Tweening;
using Power;

public static class ButtonMoveHelper
{
    public static void ToUp(this SpecialPowerButton specialPowerButton, float endValue = 75f, float duration = 0.25f)
    {
        specialPowerButton.transform.DOLocalMoveY(endValue, duration);
    }

    public static void ToDown(this SpecialPowerButton specialPowerButton, float endValue = 0f, float duration = 0.25f)
    {
        specialPowerButton.transform.DOLocalMoveY(endValue, duration);
    }
}