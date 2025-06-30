using System;
using UnityEngine;

public class DisableGrabbingHand : MonoBehaviour
{
    [SerializeField] private GameObject leftHandModel;
    [SerializeField] private GameObject rightHandModel;

    public static Action<bool, bool> OnHandsGrab;

    private void OnEnable()
    {
        OnHandsGrab += SetHandsVisible;
    }

    private void OnDisable()
    {
        OnHandsGrab -= SetHandsVisible;
    }

    private void Start()
    {
        if (leftHandModel == null || rightHandModel == null)
        {
            Debug.LogError("Configure hand models links!");
        }  
    }

    public void SetHandsVisible(bool visible, bool isLeft)
    {
        if (isLeft)
        {
            leftHandModel.SetActive(visible);
        }
        else
        {
            rightHandModel.SetActive(visible);
        }
    }
}