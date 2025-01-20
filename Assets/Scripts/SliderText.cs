using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_InputField text;

    private void Awake()
    {
        slider.onValueChanged.AddListener(SliderChanged);
        text.onValueChanged.AddListener(TextChanged);
    }

    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(SliderChanged);
        text.onValueChanged.RemoveListener(TextChanged);
    }

    private void SliderChanged(float value)
    {
        text.text = value.ToString("F2");
    }

    private void TextChanged(string textVal)
    {
        if (!float.TryParse(textVal, out var val))
        {
            return;
        }

        if (val > slider.maxValue)
        {
            slider.value = slider.maxValue;
            text.text = slider.maxValue.ToString("F2");
        }
        else if (val < slider.minValue)
        {
            slider.value = slider.minValue;
            text.text = slider.minValue.ToString("F2");
        }
        else
        {
            slider.value = val;
        }
    }
}
