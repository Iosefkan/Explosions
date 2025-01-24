using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreateBuilding : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject sidebar;

    private void Awake()
    {
        button.onClick.AddListener(Create);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(Create);
    }

    private void Create()
    {
        var building = GetComponent<GetBuildingType>().GetBuilding();
        building.AddComponent<ActiveOnClick>();
        building.GetComponent<SidebarRef>().sidebar = sidebar;
        var obj = Instantiate(building, new Vector3(-10, 0, 0), Quaternion.Euler(0, 0, 0));
        var size = obj.GetComponent<Collider>().bounds.size;
        var colliders = Physics.OverlapBox(obj.transform.position, size, obj.transform.rotation);
        while (colliders.Length != 1)
        {
            var pos = obj.transform.position;
            obj.transform.position = new Vector3(pos.x - size.x, pos.y, pos.z);
            colliders = Physics.OverlapBox(obj.transform.position, size, obj.transform.rotation);
        }
        sidebar.SetActive(true);
        sidebar.GetComponent<SetSidebars>().Set(obj);
    }
}
