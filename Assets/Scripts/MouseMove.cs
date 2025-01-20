using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public GameObject obj;
    public float rotationSpeed = 200f;

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            var verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            var horizInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            Vector3 translate = new Vector3(horizInput, verticalInput);
            transform.LookAt(obj.transform);
            transform.Translate(translate);
        }
    }
}
