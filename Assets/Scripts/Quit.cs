using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Awake()
    {
        button.onClick.AddListener(Exit);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(Exit);
    }
    void Exit()
    {
        Application.Quit();
    }
}
