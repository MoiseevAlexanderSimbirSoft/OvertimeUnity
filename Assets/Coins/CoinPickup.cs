using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public CoinManager coinManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            if (coinManager != null) {
                coinManager.AddCoin();
            }
            Destroy(gameObject);
        }
    }
}
