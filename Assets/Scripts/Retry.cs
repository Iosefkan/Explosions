using UnityEngine;
using UnityEngine.UI;

public class Retry : MonoBehaviour
{
    public GameObject retry;
    public Slider forceSlider;
    public Transform expTrans;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetThis();
        }   
    }

    void ResetThis()
    {
        ResetObjects();
        var obj = Instantiate(retry);
        obj.GetComponent<Explode>().forceSlider = forceSlider;
        obj.GetComponent<Explode>().expTrans = expTrans;
        Destroy(gameObject);
    }

    void ResetObjects()
    {
        GameObject[] fractured = GameObject.FindGameObjectsWithTag("fractured_building");
        foreach (GameObject obj in fractured)
        {
            var script = obj.GetComponent<Reset>();
            if (script is not null)
            {
                script.ResetObject();
            }
        }
    }
}
