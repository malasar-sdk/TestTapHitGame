using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoving : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;

    public bool isKilled;
    public bool isPlayerOnPoint;
    public float speedPlayer;

    private int numWayPoint;

    public Transform[] wayPoints;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        isKilled = true;
        isPlayerOnPoint = false;
        numWayPoint = 0;
    }

    private void Update()
    {
        if (isKilled == true)
        {
            PlayerMove();
        }
    }

    public void PlayerMove()
    {
        if (Vector3.Distance(transform.position, wayPoints[numWayPoint].position) > 0.2f)
        {
            agent.isStopped = false;
            agent.SetDestination(Vector3.MoveTowards(transform.position, wayPoints[numWayPoint].position, Time.deltaTime * speedPlayer));

            isPlayerOnPoint = false;
            anim.SetBool("isShoot", false);
            anim.SetBool("isWalkPlayer", true);
        }
        else
        {
            isKilled = false;
            anim.SetBool("isWalkPlayer", false);

            agent.isStopped = true;

            if (numWayPoint < wayPoints.Length)
            {
                if (numWayPoint == 0)
                {
                    isPlayerOnPoint = false;
                    NpcSpawning.isOnPoint = false;
                    numWayPoint++;

                    anim.SetBool("isShoot", false);
                }
                else
                {
                    isPlayerOnPoint = true;
                    NpcSpawning.isOnPoint = true;

                    anim.SetBool("isShoot", true);

                    numWayPoint++;
                }
            }
        }
    }
}
