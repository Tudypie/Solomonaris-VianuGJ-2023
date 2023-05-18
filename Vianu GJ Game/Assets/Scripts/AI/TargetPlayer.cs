using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetPlayer : MonoBehaviour
{   
    public Transform Player;

    private NavMeshAgent agent;
    private Animator anim;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Run", true);
    }

    private void Update()
    {   
        agent.SetDestination(Player.transform.position);
    }

    public void Stop()
    {
        anim.SetBool("Caught", true);
        agent.enabled = false;
        enabled = false;
    }
}
