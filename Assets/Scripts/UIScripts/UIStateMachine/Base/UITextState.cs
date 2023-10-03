using UnityEngine;

/// <summary>
/// A State that takes an existing text field to manage
/// </summary>
public class UITextState : UIState
{
    [TextArea]
    public string text;

    public override void OnStateEnter(UIStateMachineController controller)
    {
        base.OnStateEnter(controller);

        controller.textArea.SetText(text);
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        base.OnStateExit(controller);

        controller.textArea.SetText("");
    }
}
