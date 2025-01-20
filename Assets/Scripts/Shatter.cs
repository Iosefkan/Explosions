using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject shatterTo;

    public void ShatterObject()
    {
        var shat = Instantiate(shatterTo, transform.position, transform.rotation);
        shat.GetComponent<SidebarRef>().sidebar = GetComponent<SidebarRef>().sidebar;
        Destroy(gameObject);
    }
}
