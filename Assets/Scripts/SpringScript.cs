using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour {

    public float springTimer = 0;
    public float areYouStillOnTimer = 0;
    public float fuckThisShit = 0;
    public float moveVar = .05f;
    bool moving = false;
    bool hasMovedBack = true;
    bool canMoveBack = false;
    bool touchingLikeAMotherFucker = false;
    bool updatedTimer = false;
    Collision2D collisionFromExit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            hasMovedBack = false;
            gameObject.transform.position -= new Vector3(0, moveVar, 0);
            moveVar -= .01f;
            if (moveVar == 0)
            {
                moveVar = .05f;
                moving = false;
                springTimer = Time.time + .5f;
            }
        }
        if (!moving && Time.time - springTimer > .5 && !hasMovedBack && canMoveBack)
        {
            gameObject.transform.position += new Vector3(0, .15f, 0);
            hasMovedBack = true;
            canMoveBack = false;
        }
        if (!touchingLikeAMotherFucker && canMoveBack)
        {
            if (!updatedTimer)
            {
                fuckThisShit = Time.time + .5f;
                updatedTimer = true;
            }
            if (fuckThisShit - Time.time < 0)
            {
                OnCollisionExit2D(collisionFromExit);
                updatedTimer = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hasMovedBack)
        {
            moving = true;
            touchingLikeAMotherFucker = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touchingLikeAMotherFucker = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touchingLikeAMotherFucker = false;
        collisionFromExit = collision;
        OnCollisionStay2D(collisionFromExit);
        if (collision.gameObject.tag == "Player" && !touchingLikeAMotherFucker && areYouStillOnTimer - Time.time < 0)
        {
            canMoveBack = true;
        }
    }
}