using UnityEngine;
using System.Collections;

public class SpawnPointScript : MonoBehaviour {

    public Transform enemyPrefab;

    public float spawnRate = 3f;

    private float spawnCooldown;

    private Transform spawnPoint;

    // Use this for initialization
    void Start () {
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        spawnCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        Spawn();
        if (spawnCooldown > 0) {
            spawnCooldown -= Time.deltaTime;
        }        
	}

    public void Spawn()
    {
        if (CanSpawn)
        {
            spawnCooldown = spawnRate;

            // Create a new enemy
            //var enemyTransform = Instantiate(enemyPrefab) as Transform;
            GameObject enemyObj = (GameObject)Instantiate(Resources.Load("poulpi"));

            // Assign position
            float yMax = Camera.main.orthographicSize - 0.5f;
            enemyObj.transform.position = new Vector3(spawnPoint.position.x, Random.Range(-yMax, yMax), spawnPoint.position.z);
        }
    }

    public bool CanSpawn
    {
        get
        {
            return spawnCooldown <= 0f;
        }
    }
}
