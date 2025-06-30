using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Content.Interaction;

public class OvenInspection : MonoBehaviour
{
    [Header("Checkboxes")]
    [SerializeField] private Toggle gasToggle;
    [SerializeField] private Toggle igniteToggle;

    [Header("Submit")]
    [SerializeField] private Button submitButton;

    [Header("Oven Reference")]
    [SerializeField] private Oven oven;

    [Header("Feedback")]
    [SerializeField] private GameObject resultWindow;
    [SerializeField] private Text resultText;
    [SerializeField] private Button nextButton;

    [Header("Knobs")]
    [SerializeField] private XRKnob[] knobs;

    private void Start()
    {
        submitButton.onClick.AddListener(CheckAnswers);
        nextButton.onClick.AddListener(NextRound);
        resultWindow.SetActive(false);
    }

    private void CheckAnswers()
    {
        bool userGasOK = gasToggle.isOn;
        bool userIgniteOK = igniteToggle.isOn;

        bool allBurnersOK = AllBurnersWorking();
        bool igniteOK = !oven.IgniteBroken;

        bool gasCorrect = (userGasOK == allBurnersOK);
        bool igniteCorrect = (userIgniteOK == igniteOK);

        resultWindow.SetActive(true);

        if (gasCorrect && igniteCorrect)
        {
            resultText.text = "Всё верно!";
        }
        else
        {
            resultText.text = "Неверно. Попробуй ещё раз.";
        }
    }

    private bool AllBurnersWorking()
    {
        foreach (var burner in oven.GetBurners())
        {
            if (burner.BurnerBroken)
                return false;
        }
        return true;
    }

    private void NextRound()
    {
        oven.ConfigureOven();

        gasToggle.isOn = false;
        igniteToggle.isOn = false;

        resultText.text = "";
        resultWindow.SetActive(false);

        foreach (XRKnob knob in knobs)
        {
            knob.value = 0;
        }
    }
}