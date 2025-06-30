using System.Collections;
using UnityEngine;

public class Match : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private float fireDuration = 10f;

    private bool isLit = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        fire.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isLit) return;

        if (other.CompareTag("Matchbox"))
        {
            GetComponentInParent<Match>().Ignite();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isLit) return;

        if (other.TryGetComponent<BurnerController>(out var burner))
        {
            burner.IgniteGas();
        }
    }

    private void Ignite()
    {
        isLit = true;

        fire.SetActive(true);
        StartCoroutine(ExtinguisMatch());
    }

    private IEnumerator ExtinguisMatch()
    {
        yield return new WaitForSeconds(fireDuration);
        isLit = false;
        fire.SetActive(false);
        Debug.Log("Match extinguished.");
    }
}