using UnityEngine;
using UnityEngine.UI;

public class CircleManager : MonoBehaviour
{
    [SerializeField] Transform circlesContainer;
    [SerializeField] Slider forceSlider;

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
        for (int i = 0; i < 5; i++)
        {
            var circle = (RectTransform)circlesContainer.GetChild(i);
            var size = force * 0.2f * ((i + 1f) / 5f);
            Debug.Log(size);
            circle.sizeDelta = new Vector2(size, size);
        }
    }
}
