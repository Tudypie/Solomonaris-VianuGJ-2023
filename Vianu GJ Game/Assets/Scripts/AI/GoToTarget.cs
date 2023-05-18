using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTarget : MonoBehaviour
{
    public Transform Target;

    private UnityEngine.AI.NavMeshAgent agent;
    private Animator anim;

    private void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Run", true);
    }

    private void Update()
    {   
        agent.SetDestination(Target.transform.position);

        if(Vector3.Distance(transform.position, Target.transform.position) < 1f)
            Stop();
    }

    private void Stop()
    {
        anim.SetBool("Run", false);
        agent.enabled = false;
        enabled = false;
    }
}
