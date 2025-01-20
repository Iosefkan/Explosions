using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeleteObj : MonoBehaviour
{
    [SerializeField] private Button delButton;

    private void Awake()
    {
        delButton.onClick.AddListener(Delete);
    }

    private void OnDestroy()
    {
        delButton.onClick.RemoveListener(Delete);
    }

    private void Delete()
    {
        Destroy(GetComponent<ChangePosition>().obj);
        gameObject.SetActive(false);
    }
}
