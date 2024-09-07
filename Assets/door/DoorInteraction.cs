using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorInteraction : MonoBehaviour
{
    public Transform door;
    public float interactionDistance = 3f;
    public KeyCode openKey = KeyCode.E;
    public TextMeshProUGUI interactionText; 

    private Transform player;
    private DoorController doorController; 
    
    public Material normalMaterial;    
    public Material highlightMaterial;
    private Renderer doorRenderer; 
    
    void Start()
    {
        player = Camera.main.transform;
        doorRenderer = door.GetComponent<Renderer>();
        doorController = door.GetComponent<DoorController>();
        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= interactionDistance)
        {
            interactionText.gameObject.SetActive(true);

            if (doorRenderer != null)
            {
                Material[] materials = doorRenderer.materials;
                for (int i = 0; i < materials.Length; i++)
                {
                    materials[i] = highlightMaterial;
                }
                doorRenderer.materials = materials;
            }         
            if (Input.GetKeyDown(openKey))
            {
                doorController.ToggleDoor();
            }
        }
        else
        {
            if (doorRenderer != null)
            {
                doorRenderer.material = normalMaterial;
            }    
            interactionText.gameObject.SetActive(false);
        }
    }
}
