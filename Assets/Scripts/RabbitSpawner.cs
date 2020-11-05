using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject rabbitPrefab;
    [SerializeField]
    float frequency;

    float _timeUntilNextSpawn;

    // Update is called once per frame
    void Update()
    {
        bool isTimeToSpawn = _timeUntilNextSpawn <= Time.time;
        if (isTimeToSpawn)
        {
            Instantiate(rabbitPrefab);
            _timeUntilNextSpawn += frequency;
        }


    }
}
