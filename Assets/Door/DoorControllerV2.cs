using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorControllerV2 : MonoBehaviour
{
    public Transform door;
    public float openAngle = -90f;
    public float openSpeed = 2f;
    
    public float interactionDistance = 1.5f;
    
    public KeyCode openKey = KeyCode.E;
    
    public TextMeshProUGUI openInteractionText;
    public TextMeshProUGUI closeInteractionText; 

    private bool isOpen = false;
    private Transform player;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        if (door == null)
        {
            Debug.LogError("Door is not assigned!");
            return;
        }
        player = Camera.main.transform;
        closedRotation = door.localRotation;
        openRotation = Quaternion.Euler(door.localEulerAngles.x, door.localEulerAngles.y + openAngle, door.localEulerAngles.z);
        closeInteractionText.gameObject.SetActive(true);
        openInteractionText.gameObject.SetActive(true);

    }

    void Update()
    {
        if (Vector3.Distance(player.position, door.position) <= interactionDistance) {
            if (isOpen) {
                closeInteractionText.gameObject.SetActive(true);
                openInteractionText.gameObject.SetActive(false);
            }
            else {
                closeInteractionText.gameObject.SetActive(false);
                openInteractionText.gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(openKey)) { 
                ToggleDoor();
            }

            if (isOpen) { 
                door.localRotation = Quaternion.Slerp(door.localRotation, openRotation, Time.deltaTime * openSpeed);
            }
            else
            {
                door.localRotation = Quaternion.Slerp(door.localRotation, closedRotation, Time.deltaTime * openSpeed);
            }
        }
        else {
            closeInteractionText.gameObject.SetActive(false);
            openInteractionText.gameObject.SetActive(false);
        }
    }

    public bool IsDoorOpen() {
        return isOpen;
    }

    public void ToggleDoor() {
        isOpen = !isOpen;
    }
}
