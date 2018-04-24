using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public Player playerVariable;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerVariable = player.GetComponent<Player>();
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if(playerVariable.health<= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
