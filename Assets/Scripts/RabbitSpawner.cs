using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RabbitSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject rabbitPrefab;

    [SerializeField]
    float timeBetweenSpawns = 5f;

    [SerializeField]
    float frequencyOfSpawnRateIncrease = 5f;

    [SerializeField]
    float timeOfTDStage = 60f;

    List<Vector2> listOfWaypoints = new List<Vector2>();

    float _timeUntilNextSpawn;
    float _timeUntilNextSpawnFrequencyIncrease;

    

    private void Start()
    {
        MakeListOfWaypoints();
    }
    void Update()
    {
        IncreaseSpawnFrequency();
        SpawnRabbit();
        EndStage();
    }

    void PrintWaypoints()
    {
        foreach (var point in listOfWaypoints)
        {
            Debug.Log(point);
        }
    }

    void IncreaseSpawnFrequency()
    {
        bool isTimeToIncreaseSpawnFrequency = _timeUntilNextSpawnFrequencyIncrease <= Time.time;
        if (isTimeToIncreaseSpawnFrequency)
        {
            if (timeBetweenSpawns > 1)
                timeBetweenSpawns--;
            _timeUntilNextSpawnFrequencyIncrease += frequencyOfSpawnRateIncrease;
        }
    }

    void SpawnRabbit()
    {
        bool isTimeToSpawn = _timeUntilNextSpawn <= Time.time;
        if (isTimeToSpawn)
        {
            var rabbit = Instantiate(rabbitPrefab, transform.position, Quaternion.identity);
            rabbit.GetComponent<RabbitMovement>().waypoints = listOfWaypoints;

            _timeUntilNextSpawn += timeBetweenSpawns;
        }
    }

    void MakeListOfWaypoints()
    {
        for (int waypointNumber = 0; waypointNumber < transform.childCount; waypointNumber++)
        {
            var child = transform.GetChild(waypointNumber);
            Vector2 positionOfWaypoint = ((Vector2)child.position);
            listOfWaypoints.Add(positionOfWaypoint);
        }
    }

    void EndStage()
    {
        if (Time.time >= timeOfTDStage)
            SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
