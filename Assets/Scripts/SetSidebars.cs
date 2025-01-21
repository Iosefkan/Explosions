using UnityEngine;
using UnityEngine.UI;

public class SetSidebars : MonoBehaviour
{
    [SerializeField] private Slider sliderX;
    [SerializeField] private Slider sliderY;
    [SerializeField] private Slider angle;

    public void Set(GameObject obj)
    {
        GetComponent<ChangePosition>().obj = obj;
        sliderX.value = obj.transform.position.x / Consts.MetersMultiplier;
        sliderY.value = obj.transform.position.z / Consts.MetersMultiplier;
        angle.value = obj.transform.localEulerAngles.y;
    }
}
