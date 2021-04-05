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
    public float chaseRadius = 5.0f;
    public float attackRadius = 2.0f;
    public float attackRate = 3.0f;
    public float attackDamage = 10.0f;
    public AudioClip chaseSound;
    

    private IEnemyState currentState;
    public PatrolState patrol = new PatrolState();
    public ChaseState chase = new ChaseState();
    public AttackState attack = new AttackState();
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
