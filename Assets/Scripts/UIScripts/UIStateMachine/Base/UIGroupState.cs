using UnityEngine;
using OmnicatLabs.Tween;
using UnityEngine.Events;

/// <summary>
/// A State that takes in an existing CanvasGroup to fade in and out
/// </summary>
public class UIGroupState : UIState
{
    public CanvasGroup group;
    public float fadeTime = .3f;
    public EasingFunctions.Ease easing;

    private UnityAction inCallback;
    private UnityAction outCallback;

    public override void OnStateEnter(UIStateMachineController controller)
    {
        base.OnStateEnter(controller);
        group.FadeIn(fadeTime, inCallback, easing);
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        base.OnStateExit(controller);
        group.FadeOut(fadeTime, outCallback, easing);
    }

    public void SetInCallback(UnityAction function)
    {
        inCallback = function;
    }

    public void SetOutCallback(UnityAction function)
    {
        outCallback = function;
    }
}
