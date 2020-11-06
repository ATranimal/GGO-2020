using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject rabbitPrefab;
    [SerializeField]
    float timeBetweenSpawns;

    List<Vector2> listOfWaypoints = new List<Vector2>();

    float _timeUntilNextSpawn;

    private void Start()
    {
        for (int waypointNumber = 0; waypointNumber < transform.childCount; waypointNumber++)
        {
            var child = transform.GetChild(waypointNumber);
            Vector2 positionOfWaypoint = ((Vector2)child.position);
            listOfWaypoints.Add(positionOfWaypoint);
        }
            

        PrintWaypoints();
    }
    void Update()
    {
        bool isTimeToSpawn = _timeUntilNextSpawn <= Time.time;
        if (isTimeToSpawn)
        {
            Instantiate(rabbitPrefab);

            _timeUntilNextSpawn += timeBetweenSpawns;
        }
    }

    void PrintWaypoints()
    {
        foreach (var point in listOfWaypoints)
        {
            Debug.Log(point);
        }
    }
}
