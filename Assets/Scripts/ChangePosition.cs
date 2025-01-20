using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChangePosition : MonoBehaviour
{
    public GameObject obj;
    [SerializeField] private Slider sliderX;
    [SerializeField] private Slider sliderY;
    [SerializeField] private Slider angle;
    [SerializeField] private LayerMask layerMask;

    private void Awake()
    {
        sliderX.onValueChanged.AddListener(SetX);
        sliderY.onValueChanged.AddListener(SetZ);
        angle.onValueChanged.AddListener(SetAngle);
    }

    private void OnDestroy()
    {
        sliderX.onValueChanged.RemoveListener(SetX);
        sliderY.onValueChanged.RemoveListener(SetZ);
        angle.onValueChanged.RemoveListener(SetAngle);
    }

    private void SetAngle(float angle)
    {
        if (obj is null) return;
        obj.transform.eulerAngles = new(obj.transform.localEulerAngles.x, angle, obj.transform.localEulerAngles.z);
    }

    private void SetX(float val)
    {
        if (obj is null) return;
        var y = DetectY();
        obj.transform.position = new Vector3(val, y, obj.transform.position.z);
    }
    
    private void SetZ(float val)
    {
        if (obj is null) return;
        var y = DetectY();
        obj.transform.position = new Vector3(obj.transform.position.x, y, val);
    }
     
    private float DetectY()
    {
        var cols = Physics.RaycastAll(new Vector3(obj.transform.position.x, obj.transform.position.z + 100f, obj.transform.position.z), -transform.up, 200f, layerMask);
        if (cols is null || cols.Length == 0)
        {
            return obj.transform.position.y;
        }
        var colsList = cols.ToList();
        colsList.Remove(colsList.FirstOrDefault(x => x.transform == obj.transform));
        return colsList.Max(col => col.point.y);
    }

}
