using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explode : MonoBehaviour
{
    public GameObject fractured;
    public Transform expTrans;
    public Slider forceSlider;
    public GameObject sidebar;
    public GameObject radbar;

    private void Start()
    {
        expTrans.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ExplodeThis();
        }
    }

    void ExplodeThis()
    {
        sidebar.SetActive(false);
        radbar.SetActive(true);
        var radius = Consts.MetersMultiplier * Consts.GetRadius(0, forceSlider.value, forceSlider.minValue, forceSlider.maxValue);
        ShatterObjects(radius);
        ExplodeObjects(radius * 2, radius);
        var _fracInstance = Instantiate(fractured, transform.position, transform.rotation);
        var retry = _fracInstance.GetComponent<Retry>();
        retry.forceSlider = forceSlider;
        retry.expTrans = expTrans;
        retry.sidebar = sidebar;
        retry.radbar = radbar;

        expTrans.gameObject.SetActive(true);

        foreach (Rigidbody body in _fracInstance.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (body.transform.position - transform.position).normalized * forceSlider.value * 0.1f;
            body.AddForce(force);
        }
        Destroy(gameObject);
    }

    void ShatterObjects(float radius)
    {
        Collider[] objs = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider obj in objs)
        {
            var script = obj.GetComponent<Shatter>();
            if (script is not null)
            {
                var pos = obj.gameObject.transform.position;
                var distance = Vector3.Distance(transform.position, pos);
                var category = GetShatterCategory(distance);
                script.ShatterObject(category);
            }
        }
    }

    int GetShatterCategory(float distance)
    {
        Debug.Log($"Distance: {distance}");
        var minAll = Consts.MetersMultiplier * Consts.GetRadius(4, forceSlider.value, forceSlider.minValue, forceSlider.maxValue);
        if (minAll >= distance) return 4;
        for (int i = 0; i < 4; i++)
        {
            var max = Consts.MetersMultiplier * Consts.GetRadius(i, forceSlider.value, forceSlider.minValue, forceSlider.maxValue);
            var min = Consts.MetersMultiplier * Consts.GetRadius(i + 1, forceSlider.value, forceSlider.minValue, forceSlider.maxValue);
            Debug.Log($"max: {max}, min: {min}");
            if (max > distance && min <= distance)
            {
                return i;
            }
        }
        return 0;
    }

    void ExplodeObjects(float force, float radius)
    {
        Collider[] objs = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider obj in objs)
        {
            foreach (Rigidbody body in obj.GetComponentsInChildren<Rigidbody>())
            {
                body.AddExplosionForce(force, transform.position, radius);
            }
        }
    }
}
