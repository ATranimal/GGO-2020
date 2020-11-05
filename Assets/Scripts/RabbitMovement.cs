using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMovement : MonoBehaviour
{
    private float rabbitSpeed = 2.0f;
    private int currentWaypoint = 0;

    private Vector2[] waypoints =
    {
        new Vector2(1,1),
        new Vector2(1,2),
        new Vector2(2,2)
    };

    void Update()
    {
        MoveOnPath(waypoints);
    }

    void MoveTowardsPoint(Vector2 targetPoint)
    {
        float step = rabbitSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, step);
    }

    void MoveOnPath(Vector2[] points)
    {
        bool isAtWaypoint = Vector2.Distance((Vector2)transform.position, points[currentWaypoint]) < 0.2f;

        if (isAtWaypoint)
        { 
            bool isAtTheEnd = currentWaypoint == points.Length - 1;

            if (isAtTheEnd)
                Destroy(this);
            else
                currentWaypoint++;
        }

        Debug.Log(currentWaypoint);
        MoveTowardsPoint(points[currentWaypoint]);
    }
}
