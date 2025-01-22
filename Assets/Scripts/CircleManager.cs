using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CircleManager : MonoBehaviour
{
    [SerializeField] Transform circlesContainer;
    [SerializeField] Slider forceSlider;
    [SerializeField] TMP_Text vals;

    private void Awake()
    {
        forceSlider.onValueChanged.AddListener(ForceChanged);
        ForceChanged(forceSlider.value);
    }

    private void OnDestroy()
    {
        forceSlider.onValueChanged.RemoveListener(ForceChanged);
    }

    private void ForceChanged(float force)
    {
        var stringBuilder = new StringBuilder();
        for (int i = 0; i < 5; i++)
        {
            var radius = Consts.GetRadius(i, force, forceSlider.minValue, forceSlider.maxValue);
            stringBuilder.Append(radius.ToString("F2") + " м" + (i == 4 ? "" : "\n"));
            var circle = (RectTransform)circlesContainer.GetChild(5 - (i + 1));
            var size = 2 * Consts.MetersMultiplier * radius;
            circle.sizeDelta = new Vector2(size, size);
        }
        vals.text = stringBuilder.ToString();
    }
}
