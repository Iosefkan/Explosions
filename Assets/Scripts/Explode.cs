using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explode : MonoBehaviour
{
    public GameObject fractured;
    public Transform expTrans;
    public Slider forceSlider;

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
        ShatterObjects(forceSlider.value * 0.1f);
        ExplodeObjects(forceSlider.value, forceSlider.value * 0.1f);
        var _fracInstance = Instantiate(fractured, transform.position, transform.rotation);

        expTrans.gameObject.SetActive(true);

        _fracInstance.GetComponent<Retry>().forceSlider = forceSlider;
        _fracInstance.GetComponent<Retry>().expTrans = expTrans;
        foreach (Rigidbody body in _fracInstance.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (body.transform.position - transform.position).normalized * forceSlider.value;
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
                script.ShatterObject();
            }
        }
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
