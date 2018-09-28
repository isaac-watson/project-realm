using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    private Vector2 oldDirection;

    //Vector to store the position of the enitity in the previous frame
    protected Vector2 oldPosition;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        entitySpeed = 8; //Should be changed to the player's class's default speed
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update(); //Calls the parent class's version of update
        GetInput(); //Check for input every frame
	}

    private void GetInput()
    {
        oldPosition = transform.position;
        oldPosition = oldPosition.normalized; 

        /*Since Move is called every frame, we want to make sure the player doesn't move
        when we let go of our input.*/
        direction = Vector2.zero;
        //
        animState = PlayerState.Idle;

        if(Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector2.up;
            oldDirection = Vector2.up;
            animState = PlayerState.Walking;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector2.down;
            oldDirection = Vector2.down;
            animState = PlayerState.Walking;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector2.left;
            oldDirection = Vector2.left;
            animState = PlayerState.Walking;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector2.right;
            oldDirection = Vector2.right;
            animState = PlayerState.Walking;
        }

       


        /* x > 0 -> right     x & y > 0 -> right
         * don't face left or right if x = 0
         * 
         */ 
        if(animState == PlayerState.Walking)
        {
            if(direction.x == 0)
            {
                if(direction.y > 0)
                {
                    animator.Play("astronaut_walk_up_16x16");
                } else
                {
                    animator.Play("astronaut_walk_down_16x16");
                }
            } else if(direction.x > 0)
            {
                animator.Play("astronaut_walk_right_16x16");
            } else
            {
                animator.Play("astronaut_walk_left_16x16");
            }
        } else if(animState == PlayerState.Idle)
        {
            if (oldDirection.x == 0)
            {
                if (oldDirection.y > 0)
                {
                    animator.Play("astronaut_ide_up_16x16");
                }
                else
                {
                    animator.Play("astronaut_ide_down_16x16");
                }
            }
            else if (oldDirection.x > 0)
            {
                animator.Play("astronaut_ide_right_16x16");
            }
            else
            {
                animator.Play("astronaut_ide_left_16x16");
            }
        }
       if(Input.GetKey(KeyCode.Alpha1))
        {
            transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * 100);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * 100);
        } 
    }
}
