using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void OnInteractEnter(bool isLeftHand);
    public abstract void OnInteractExit(bool isLeftHand);
}