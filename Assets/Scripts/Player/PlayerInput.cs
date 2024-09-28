using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour{
    private Vector2 _moveInput;
    private bool _canMove;
    public Transform movePoint;
    public LayerMask movePointCollider;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    const float playerSpeed = 5f;

    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        movePoint.parent = null;
        _canMove = true;
    }

    void FixedUpdate() {
        Run();
    }

    void OnMove(InputValue value) {
        _moveInput = value.Get<Vector2>();
    }

    void Run() {
        if(_canMove) {
            myRigidBody.velocity = new Vector2(_moveInput.x, _moveInput.y);
            //determine if player's velocity is above 0 
            //will switch player animation from idle to running if player is moving
            bool playerHasSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon || Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;

            //Utilize an invisible pointer that determines where the player object can move to.
            //Ensures that player can only move either horizontally or vertically, never diagonally.
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, playerSpeed * Time.deltaTime);
            bool collideWithHorizontalWall = Physics2D.OverlapCircle(movePoint.position + new Vector3(_moveInput.x, 0f, 0f), 0.2f, movePointCollider);
            bool collideWithVerticalWall = Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, _moveInput.y, 0f), 0.2f, movePointCollider);

            if(Vector3.Distance(transform.position, movePoint.position) <= .05f) {
                if(Mathf.Abs(_moveInput.x) == 1f && !collideWithHorizontalWall) {
                    movePoint.position += new Vector3(_moveInput.x, 0f, 0f);
                }
                else if(Mathf.Abs(_moveInput.y) == 1f && !collideWithVerticalWall) {
                    movePoint.position += new Vector3(0f, _moveInput.y, 0f);
                }
            }

            //if player is moving, change object scale to (+/-) to flip the player sprite
            if(playerHasSpeed) {
                transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
            }
            //responsible for switching the animation of player from idle to running
            myAnimator.SetBool("isRunning", playerHasSpeed);
        }
        else {
            myRigidBody.velocity = new Vector2(0f,0f);
            myAnimator.SetBool("isRunning", _canMove);
        }
    }

    void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            _canMove = false;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")) {
            _canMove = true;
        }
    }
}
