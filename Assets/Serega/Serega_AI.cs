using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Serega_AI : MonoBehaviour
{
    private NavMeshAgent AI_Agent;
    private GameObject Player;
    public GameObject Panel_GameOver;
    private TextMeshProUGUI gameOverText;

    void Start()
    {
        AI_Agent = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
        gameOverText = Panel_GameOver.GetComponentInChildren<TextMeshProUGUI>();
    }
    
    void FixedUpdate()
    {
        AI_Agent.SetDestination(Player.transform.position);
        float Dist_Player = Vector3.Distance(Player.transform.position, gameObject.transform.position);
        if(Dist_Player < 1)
        {
            Player.SetActive(false);
            gameOverText.text = "Серега оказался быстрее";
            Panel_GameOver.SetActive(true);
        }
    }
}
