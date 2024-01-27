using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float playerDistance;
    public float awareAI = 10f;
    public float AIMoveSpeed;
    public float damping = 6.0f;

    public Transform[] navPoints;
    public NavMeshAgent agent;
    public int destPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = navPoints[0].position;

        agent.autoBraking = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(target.position, transform.position);

        if(playerDistance < awareAI) {
            LookAtPlayer();
            Debug.Log("seen");
        }

        if(playerDistance < awareAI) {
            if(playerDistance > 2f) {
                Chase();
            }
            else {
                GoToNextPoint();
            }
        }

        if(agent.remainingDistance < 0.5f) {
            GoToNextPoint();
        }
    }

    void LookAtPlayer() {
        transform.LookAt(target);
    }

    void GoToNextPoint() {
        if(navPoints.Length == 0) {
            return;
        }
        agent.destination = navPoints[destPoint].position;
        destPoint = (destPoint + 1) % navPoints.Length;
    }

    void Chase() {
        transform.Translate(Vector3.forward * AIMoveSpeed * Time.deltaTime);
    }
}
