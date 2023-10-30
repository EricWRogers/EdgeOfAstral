using UnityEngine;

public class ChangeObjective : MonoBehaviour
{
    [TextArea]
    public string newObjective;
    public void Change()
    {
        ObjectiveText.instance.SetCurrObjective(newObjective);
    }
}
