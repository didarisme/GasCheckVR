using UnityEngine;

public class TestInteraction : Interactable
{
    public override void OnInteractEnter(bool isLeftHand)
    {
        Debug.Log("Left");
    }

    public override void OnInteractExit(bool isLeftHand)
    {
        Debug.Log("Right");
    }
}
