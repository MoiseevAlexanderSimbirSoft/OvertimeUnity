using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Serega_AI : MonoBehaviour
{
    private NavMeshAgent AI_Agent;
    private GameObject Player;
    public LoseMenu loseMenu;

    void Start()
    {
        AI_Agent = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void FixedUpdate()
    {
        AI_Agent.SetDestination(Player.transform.position);
        float Dist_Player = Vector3.Distance(Player.transform.position, gameObject.transform.position);
        if(Dist_Player < 1)
        {
            Player.SetActive(false);
            loseMenu.ShowLoseMenu();
        }
    }
}
