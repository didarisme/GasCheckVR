using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractiveObject : MonoBehaviour
{
    private Interactable interactable;
    private bool useInteraction = true;

    private void Start()
    {
        interactable = GetComponent<Interactable>();

        if (!interactable)
        {
            //Debug.Log("No interactable class " + this.name);
            useInteraction = false;
        }

        XRBaseInteractable baseInteractable = GetComponent<XRBaseInteractable>();
        baseInteractable.selectEntered.AddListener(OnSelectEnter);
        baseInteractable.selectExited.AddListener(OnSelectExit);
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        bool isLeftHand = RecognisedLeftHand(args.interactorObject.transform.tag);

        DisableGrabbingHand.OnHandsGrab?.Invoke(false, isLeftHand);

        if (useInteraction)
            interactable.OnInteractEnter(isLeftHand);
    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        bool isLeftHand = RecognisedLeftHand(args.interactorObject.transform.tag);

        DisableGrabbingHand.OnHandsGrab?.Invoke(true, isLeftHand);

        if (useInteraction)
            interactable.OnInteractExit(isLeftHand);
    }

    private bool RecognisedLeftHand(string handTag)
    {
        if (handTag == "Left Hand")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}