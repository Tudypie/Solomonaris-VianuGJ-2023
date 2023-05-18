using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CapyRun : MonoBehaviour
{
    public Transform player;             
    [Space]
    public float runDistance = 10f;       
    public float runSpeed = 5f;           
    public float normalSpeed = 3.5f;       

    private NavMeshAgent navMeshAgent;     
    private Animator anim;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= runDistance)
        {   
            Vector3 direction = transform.position - player.position; 
            Vector3 targetPosition = transform.position + direction;   

            navMeshAgent.speed = runSpeed;      
            navMeshAgent.SetDestination(targetPosition);   

            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
            navMeshAgent.SetDestination(transform.position);   
            navMeshAgent.speed = normalSpeed;   

            Vector3 cameraDirection = player.position - transform.position;
            float targetYRotation = Mathf.Atan2(cameraDirection.x, cameraDirection.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetYRotation, 0f);

            float rotationSpeed = 5f; 
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        }
    }

    public void Stop()
    {   
        anim.SetBool("Caught", true);
        navMeshAgent.enabled = false;
        enabled = false;
    }

}
