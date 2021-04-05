using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform playerPos;
    public LayerMask isPlayer;
    public Animator anim;
    public float radius = 5f;
    public AudioClip chaseSound;

    private IEnemyState currentState;
    public PatrolState patrol = new PatrolState();
    public ChaseState chase = new ChaseState();
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerPos = FindObjectOfType<Player>().transform;
        anim = GetComponent<Animator>();
        currentState = patrol;
    }

    // Update is called once per frame
    void Update()
    {
       currentState = currentState.DoStateAction(this);
    }
}
