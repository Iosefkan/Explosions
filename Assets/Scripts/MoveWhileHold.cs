using UnityEngine;
using Unity.Cinemachine;

public class FreeLookCameraMouseControlV3 : MonoBehaviour
{
    public CinemachineInputAxisController inputController;

    void Update()
    {
        var isMouseHeld = Input.GetMouseButton(2);
        if (isMouseHeld != inputController.Controllers[0].Enabled)
        {
            inputController.Controllers[0].Enabled = isMouseHeld;
            inputController.Controllers[1].Enabled = isMouseHeld;
        }
    }
}