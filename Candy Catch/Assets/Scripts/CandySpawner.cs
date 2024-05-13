using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    float MaxX; // Max value of x positon of Candy

    public GameObject[] Candies; // Array of Candy objects

    [SerializeField]
    float spawnInterval;

    // Creating this instance allows easy access to the spawner
    // elsewhere in the code.
    public static CandySpawner instance;

    // This method says that if there is no reference of
    // this instance, then this is the instance. I think. 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawningCandies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnCandy()
    {
        int rand = Random.Range(0, Candies.Length); // Selects randomly from Candy array

        float randX = Random.Range(-MaxX, MaxX); // Random value for the candy spawner,
                                                 // between the max X value and its inverse. 

        // Generating a position with a randomized x value.
        Vector3 randomPos = new Vector3(randX, transform.position.y, transform.position.z);

        // Create an object (Which, where, rotation).
        //           Candy Array,  Random X,        Unchanged
        Instantiate(Candies[rand], randomPos, transform.rotation);
    }

    IEnumerator SpawnCandies()
    {
        // This coroutine begins by waiting for
        // 2 seconds before it does anything.

        yield return new WaitForSeconds(2f);

        // This while loop will spawn a new candy
        // every (spawnInterval) seconds
        while (true)
        {
            SpawnCandy();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // These two methods are just to start and stop the
    // couroutine that spawns the candy. 

    public void StartSpawningCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies"); // I don't know why, but the name as a string seems to work better than as a function.
    }
}
