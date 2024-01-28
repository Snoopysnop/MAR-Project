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
    public bool dead = false;

    private float timeLeft = 0f;
    private float timeLeftBeforeSwitchPoint = 0f;
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
        if (!dead)
        {
            playerDistance = Vector3.Distance(target.position, transform.position);

            if (playerDistance < awareAI)
            {
                LookAtPlayer();
            }

            if (playerDistance < awareAI)
            {
                if(playerDistance <= 1.2f)
                {
                    timeLeft -= Time.deltaTime;
                    if (timeLeft <= 0) {
                        timeLeft = 1f;
                        Dammage(5);
                    }
                    
                }
                if (playerDistance >=1f)
                {
                    Chase();
                }
                else
                {
                    GoToNextPoint();
                }
            }

            if (agent.remainingDistance < 0.5f)
            {
                timeLeftBeforeSwitchPoint -= Time.deltaTime;
                if (timeLeftBeforeSwitchPoint <= 0)
                {
                    timeLeftBeforeSwitchPoint = 0.3f;
                    GoToNextPoint();
                }
            }
        }
        else
        {
            agent.destination = transform.position;
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
    void Dammage(float value)
    {
        
        GameObject gameObject = GameObject.FindGameObjectWithTag("HealthBarPlayer");
        HealthBar hbTarget = gameObject.GetComponent<HealthBar>();
        hbTarget.Dammage(value);
    }
}
