using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetBuildingType : MonoBehaviour
{
    [SerializeField] private GameObject defaultBuilding;
    [SerializeField] private GameObject type2;

    [SerializeField] private Toggle defaultBuildingToggle;
    [SerializeField] private Toggle type2Toggle;

    GameObject returnBuilding = null;

    public void Awake()
    {
        defaultBuildingToggle.onValueChanged.AddListener(isOn => { if (isOn) returnBuilding = defaultBuilding; });
        type2Toggle.onValueChanged.AddListener(isOn => { if (isOn) returnBuilding = type2; });
    }

    public GameObject GetBuilding()
    {
        return returnBuilding ?? defaultBuilding;
    }

    public void OnDestroy()
    {
        defaultBuildingToggle.onValueChanged.RemoveAllListeners();
        type2Toggle.onValueChanged.RemoveAllListeners();
    }
}
