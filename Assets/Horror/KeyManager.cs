using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance { get; private set; }
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI winText;
    private int keyCount = 0;
    private GameObject Player;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {        
        Player = GameObject.FindGameObjectWithTag("Player");
        UpdateKeyText();
    }

    public void AddKey()
    {
        keyCount++;
        UpdateKeyText();
    }

    private void UpdateKeyText()
    {
        if (keyText != null)
        {
            keyText.text = "Keys: " + keyCount;
        }

        if (keyCount >= 1)
        {
            winText.text = "You Win!";
            winText.gameObject.SetActive(true);
            Player.SetActive(false);
        }
    }
}
