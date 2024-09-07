using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform door;
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public KeyCode openKey = KeyCode.E;

    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        closedRotation = door.localRotation;
        openRotation = Quaternion.Euler(door.localEulerAngles.x, door.localEulerAngles.y + openAngle, door.localEulerAngles.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(openKey))
        {
            isOpen = !isOpen;
        }

        if (isOpen)
        {
            door.localRotation = Quaternion.Slerp(door.localRotation, openRotation, Time.deltaTime * openSpeed);
        }
        else
        {
            door.localRotation = Quaternion.Slerp(door.localRotation, closedRotation, Time.deltaTime * openSpeed);
        }
    }
}
