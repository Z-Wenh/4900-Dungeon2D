using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour{
    private Vector2 _moveInput;
    public Transform movePoint;
    public LayerMask movePointCollider;
    public LayerMask enemyCollider;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    [SerializeField] float playerSpeed = 5f;

    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        movePoint.parent = null;
    }

    void FixedUpdate() {
        Run();
        FlipSprite();
    }

    private void OnMove(InputValue value) {
        _moveInput = value.Get<Vector2>();
    }

    private void Run() {

        myRigidBody.velocity = new Vector2(_moveInput.x, _moveInput.y);
        //determine if player's velocity is above 0 
        //will switch player animation from idle to running if player is moving
        bool playerHasSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon || Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;

        //Utilize an invisible pointer that determines where the player object can move to.
        //Ensures that player can only move either horizontally or vertically, never diagonally.
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, playerSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, movePoint.position) <= .05f) {
            if(Mathf.Abs(_moveInput.x) == 1f) {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(_moveInput.x, 0f, 0f), 0.2f, movePointCollider)) {
                    movePoint.position += new Vector3(_moveInput.x, 0f, 0f);
                }
            }
            else if(Mathf.Abs(_moveInput.y) == 1f) {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, _moveInput.y, 0f), 0.2f, movePointCollider)) {
                    movePoint.position += new Vector3(0f, _moveInput.y, 0f);
                }
            }
        }

        //responsible for switching the animation of player from idle to running
        myAnimator.SetBool("isRunning", playerHasSpeed);
    }

    private void FlipSprite() {
        //determine if player's velocity is above 0
        bool playerHasSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        //if player is moving, change object scale to (+/-) to flip the player sprite
        if(playerHasSpeed) {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

}
