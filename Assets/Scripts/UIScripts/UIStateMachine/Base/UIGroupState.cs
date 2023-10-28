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
    [Tooltip("Easing is a type of smoothing that can be applied during the transition on the fade. You can google 'Easing Demo' for a visual representation of these options")]
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
