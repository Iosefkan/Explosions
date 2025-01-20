using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject resetTo;

    public void ResetObject()
    {
        var res = Instantiate(resetTo, transform.position, transform.rotation);
        res.AddComponent<ActiveOnClick>();
        res.GetComponent<SidebarRef>().sidebar = GetComponent<SidebarRef>().sidebar;
        Destroy(gameObject);
    }
}
