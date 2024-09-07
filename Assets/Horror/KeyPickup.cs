using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public KeyManager keyManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            if (keyManager != null) {
                keyManager.AddKey();
            }
            Destroy(gameObject);
        }
    }
}
