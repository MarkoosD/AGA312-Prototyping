using Prototype1;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : JMC
{
    private Vector3 startPos;
    private float repeatWidth;
    SpriteRenderer mySpriteRenderer;

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
