using UnityEngine;

/// <summary>
/// A state that takes some prefab to generate some UI.
/// </summary>
public class UIObjectState : UIState
{
    public GameObject uiPrefab;

    private GameObject prefabRef;

    public override void OnStateEnter(UIStateMachineController controller)
    {
        base.OnStateEnter(controller);
        prefabRef = Instantiate(uiPrefab, controller.canvas.transform);
    }

    public override void OnStateExit(UIStateMachineController controller)
    {
        base.OnStateExit(controller);
        Destroy(prefabRef);
    }
}
