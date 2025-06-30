using UnityEngine;

public class FixedHandActivator : Interactable
{
    [SerializeField] private GameObject fLeftHandModel;
    [SerializeField] private GameObject fRightHandModel;

    private void Awake()
    {
        fLeftHandModel.SetActive(false);
        fRightHandModel.SetActive(false);
    }

    public override void OnInteractEnter(bool isLeftHand)
    {
        ActivateHand(isLeftHand, true);
    }

    public override void OnInteractExit(bool isLeftHand)
    {
        ActivateHand(isLeftHand, false);
    }

    private void ActivateHand(bool isLeftHand, bool activateHand)
    {
        if (isLeftHand)
        {
            fLeftHandModel.SetActive(activateHand);
        }
        else
        {
            fRightHandModel.SetActive(activateHand);
        }
    }
}
