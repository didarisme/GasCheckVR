using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    [SerializeField] private Transform[] fireObjects;
    private Transform playerCamera;

    private void Start()
    {
        GameObject camObj = GameObject.FindWithTag("MainCamera");
        if (camObj != null)
        {
            playerCamera = camObj.transform;
        }
        else
        {
            Debug.LogWarning("MainCamera not found. Make sure your XR rig's camera has the tag 'MainCamera'.");
        }
    }

    private void Update()
    {
        if (playerCamera == null) return;

        for (int i = 0; i < fireObjects.Length; i++)
        {
            if (fireObjects[i] != null)
            {
                fireObjects[i].LookAt(playerCamera);
            }
        }
    }
}