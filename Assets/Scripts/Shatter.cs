using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject[] shatterTos;

    public void ShatterObject(int catory)
    {
        var shatterTo = shatterTos[catory];
        var shat = Instantiate(shatterTo, transform.position, transform.rotation);
        shat.GetComponent<SidebarRef>().sidebar = GetComponent<SidebarRef>().sidebar;
        Destroy(gameObject);
    }
}
