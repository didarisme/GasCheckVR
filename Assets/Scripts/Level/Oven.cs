using UnityEngine;

public class Oven : MonoBehaviour
{
    [Header("Oven Parameters")]
    [SerializeField] private BurnerController[] burners;
    [SerializeField, Range(0f, 1f)] private float brokenChance = 0.1f;

    private bool igniteBroken = false;
    private int brokenIgnite = -1;

    public bool IgniteBroken => igniteBroken;

    private void Start()
    {


        ConfigureOven();
    }

    public void IgniteBtn()
    {
        for (int i = 0; i < burners.Length; i++)
        {
            if (i != brokenIgnite)
                burners[i].IgniteGas();
        }
    }

    public void ConfigureOven()
    {
        igniteBroken = Random.value < brokenChance;
        Debug.Log($"Ignite broken: {igniteBroken}");

        for (int i = 0; i < burners.Length; i++)
        {
            burners[i].ConfigureBurner();
        }

        if (igniteBroken)
        {
            BrokeIgnite();
        }
        else
        {
            brokenIgnite = -1;
        }
    }

    private void BrokeIgnite()
    {
        brokenIgnite = Random.Range(0, burners.Length);
        Debug.Log($"Ignite broken on burner index: {brokenIgnite}");
    }

    public BurnerController[] GetBurners()
    {
        return burners;
    }
}