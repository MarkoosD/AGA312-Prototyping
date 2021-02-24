using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : JMC
{
    private float speed = 30f;
    private float leftBound = -15f;

    

    void Update()
    {
        if(_GM1.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime *  speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);

    }
}
