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
        int flagx = Random.value > 0.5 ? 1 : -1;
        int flagz = Random.value > 0.5 ? 1 : -1;
        var building = GetComponent<GetBuildingType>().GetBuilding();
        building.AddComponent<ActiveOnClick>();
        building.GetComponent<SidebarRef>().sidebar = sidebar;
        var obj = Instantiate(building, new Vector3((Random.value + 0.01f) * flagx * 250f, 0, (Random.value + 0.01f) * flagz * 250f), Quaternion.Euler(0, Random.value * 360, 0));
        sidebar.SetActive(true);
        sidebar.GetComponent<SetSidebars>().Set(obj);
    }
}
