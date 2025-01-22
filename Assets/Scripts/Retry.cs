using UnityEngine;
using UnityEngine.UI;

public class Retry : MonoBehaviour
{
    public GameObject retry;
    public Slider forceSlider;
    public Transform expTrans;
    public GameObject sidebar;
    public GameObject radbar;

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
        radbar.SetActive(false);
        var obj = Instantiate(retry);
        var explode = obj.GetComponent<Explode>();
        explode.forceSlider = forceSlider;
        explode.expTrans = expTrans;
        explode.sidebar = sidebar;
        explode.radbar = radbar;
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
