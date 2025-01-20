using UnityEngine;
using UnityEngine.EventSystems;

public class ActiveOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Activate();
        }
    }
    public void Activate()
    {
        var sidebar = GetComponent<SidebarRef>().sidebar;
        sidebar.SetActive(true);
        sidebar.GetComponent<SetSidebars>().Set(gameObject);
    }
}
