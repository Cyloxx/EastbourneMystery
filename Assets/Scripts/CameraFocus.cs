using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public GameObject focuedObject;
    private Vector3 offset = new Vector3(0, 0.6f, -15);
    [SerializeField] float smoothSpeed = 0.125f;

    // Start is called before the first frame update
    private void LateUpdate()
    {
        Vector3 desiredPosition = focuedObject.transform.position + offset;
        if (desiredPosition.y > 0.12f) { desiredPosition.y = 0.12f; }
        if (desiredPosition.y < 0) { desiredPosition.y = 0; }
        if(desiredPosition.x < -0.28f) { desiredPosition.x = -0.28f; }
        if(desiredPosition.x> 29.394f) { desiredPosition.x = 29.394f; }

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
