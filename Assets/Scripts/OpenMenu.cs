using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            menu.SetActive(!menu.activeSelf);
    }
}
