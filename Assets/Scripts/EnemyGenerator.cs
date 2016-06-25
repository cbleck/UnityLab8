using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

    public GameObject enemy;
    public float regenerationTime;
    private GameObject enemyReference;

	// Use this for initialization
	void Start () {
        StartCoroutine("GenerateEnemies");
    }
	

    IEnumerator GenerateEnemies()
    {
        enemyReference = Instantiate(enemy);

        enemyReference.transform.position = new Vector3(-6.459351f, 1.368566f, 6.74f);
        yield return new WaitForSeconds(regenerationTime);
        StartCoroutine("GenerateEnemies");
    }
}
