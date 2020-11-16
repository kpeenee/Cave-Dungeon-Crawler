using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform playerPos;

    private IEnemyState currentState;
    public PatrolState patrol = new PatrolState();
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerPos = FindObjectOfType<Player>().transform;
        currentState = patrol;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.DoStateAction(this);
    }
}
