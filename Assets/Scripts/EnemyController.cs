using UnityEngine;
using System.Collections;

enum EnemyState { PATROL, CHASING }

public class EnemyController : MonoBehaviour {

    public Vector2 areaPatrol;
    public float patrolUpdate;
    public float chasingDistance;

    private Vector3 randomDestination;
    private Vector3 startPosition;

    private GameObject player;
    private Animator enemyAnimator;
    private NavMeshAgent agent;
    private EnemyState currentState;
    private float currentDistance;

	// Use this for initialization
	void Start () {

        enemyAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = transform.position;
        currentState = EnemyState.PATROL;
        StartCoroutine("Patrol");

    }
	
	// Update is called once per frame
	void Update () {

        currentDistance = Vector3.Distance(transform.position, player.transform.position);

        if (currentDistance < chasingDistance)
        {
            currentState = EnemyState.CHASING;
            StopCoroutine("Patrol");
            agent.SetDestination(player.transform.position);
        }
        else if(currentState == EnemyState.CHASING) {
            currentState = EnemyState.PATROL;
            StartCoroutine("Patrol");
        }
        enemyAnimator.SetFloat("speed", agent.velocity.magnitude);
	}

    IEnumerator Patrol() {
     
        randomDestination = startPosition + new Vector3(Random.Range(-areaPatrol.x, areaPatrol.x),
                                                    0,
                                                    Random.Range(-areaPatrol.y, areaPatrol.y));

        agent.SetDestination(randomDestination);
        yield return new WaitForSeconds(patrolUpdate);

        if (currentState == EnemyState.PATROL)
            StartCoroutine("Patrol");

   }
}
