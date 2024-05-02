using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;
    private int i;

    bool StopMovement;
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++; // increase the index
            if (i == points.Length) // check if the platform was on the last point after the index increase
            {
                i = 0; // reset the index
            }


        }
        if (!StopMovement)
        {
            // moving the platform to the point position with the index "i"
           
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }


        if (Vector2.Distance(transform.position, points[1].position) < 0.02f)
        {
            StopMovement = true;
            AudioManager.Instance.StopSound(6);

        }
    }
}
