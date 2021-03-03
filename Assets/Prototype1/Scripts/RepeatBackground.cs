using Prototype1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : JMC
{
    private Vector3 startPos;
    private float repeatWidth;
    SpriteRenderer mySpriteRenderer;

    //Both enviroments running on top of eachother, fade the top one out (change the layer order in inspector)
    //RESET TIMER ON RESTART


    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
