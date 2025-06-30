using UnityEngine;

public class BurnerController : MonoBehaviour
{
    [Header("Burner Parameters")]
    [SerializeField] private float minGasAmount = 10f;
    [SerializeField, Range(0f, 1f)] private float brokenChance = 0.1f;

    [Space]
    [SerializeField] private GameObject fire;

    private float currentGasAmount = 0;
    private bool isBroken = false;

    private bool CanIgnite => currentGasAmount >= minGasAmount;

    public bool BurnerBroken => isBroken;

    public void ConfigureBurner()
    {
        isBroken = Random.value < brokenChance;
        Debug.Log($"{this.name} broken: {isBroken}");
        Extinguish();
    }

    public void ReleaseGas(float gasAmount)
    {
        if (isBroken)
        {
            currentGasAmount = 0;
            return;
        }

        currentGasAmount = gasAmount;

        if (!CanIgnite)
        {
            //Debug.Log("Not enough gas to ignite");
            Extinguish();
        }
    }

    public void IgniteGas()
    {
        //Debug.Log("Trying to ignite");
        if (CanIgnite)
        {
            fire.SetActive(true);
        }
    }

    public void Extinguish()
    {
        currentGasAmount = 0;
        fire.SetActive(false);
    }
}