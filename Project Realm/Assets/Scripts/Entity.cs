using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Entity: any object that can move around
 * abstract means the class is not able to be instantiated.
 * 
 */
public abstract class Entity : MonoBehaviour {
    //A 2D Vector that holds the direction the entity is moving (up, down, left, right)
    protected Vector2 direction;

    //Enumerator to determine entity state
    protected enum PlayerState
    {
        Idle, Walking, Attacking, Dying
    }

    protected PlayerState animState;

    [SerializeField] //Lets a private or protected variable be modified in the editor
    protected int entitySpeed;

    protected Animator animator;

	// Use this for initialization
	protected virtual void Start () {
        animator = GetComponent<Animator>();
        animState = PlayerState.Idle;
	}
	
	/* Update is called once per frame.
     * A virtual method is an abstract method that also provides its own implementation.
     */
	protected virtual void Update () {
        Move();
	}

    private void Move()
    {
        /*transform gets the transform component of THIS gameObject.
          Translate is a function to move THIS gameObject towards a direction relative
           to itself.*/
        transform.Translate(direction.normalized * Time.deltaTime * entitySpeed);
        AnimateEntity(direction);
    }
    private void AnimateEntity(Vector2 direction)
    {
        if(direction.x > 0 || direction.x < 0 || direction.y > 0 || direction.y < 0)
        {
            animator.SetLayerWeight(1, 1);
        } else if(direction == Vector2.zero)
        {
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(0, 1);
        }
    }

    

}
