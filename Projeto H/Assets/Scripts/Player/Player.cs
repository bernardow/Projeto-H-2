using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform playerTransform;
    public Transform cameraTransform;

    Vector2 mouseRotation;
    public int sensibility;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 mouseControl = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        mouseRotation = new Vector2(mouseRotation.x + mouseControl.x * sensibility * Time.deltaTime,
                                    mouseRotation.y + mouseControl.y * sensibility * Time.deltaTime);

        playerTransform.eulerAngles = new Vector3(playerTransform.eulerAngles.x, mouseRotation.x, playerTransform.eulerAngles.z);

        mouseRotation.y = Mathf.Clamp(mouseRotation.y, -80, 80);

        cameraTransform.localEulerAngles = new Vector3(-mouseRotation.y, cameraTransform.localEulerAngles.y, cameraTransform.localEulerAngles.z);
    }
}
