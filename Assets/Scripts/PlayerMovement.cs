using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour{
    private Vector2 moveInput;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    [SerializeField] float playerSpeed = 5f;

    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update() {
        Run();
        FlipSprite();
    }

    private void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    private void Run() {
        //determine if player's velocity is above 0 
        //will switch player animation from idle to running if player is moving
        bool playerHasSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon || Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;

        //responsible for controlling player movement velocity
        Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, moveInput.y * playerSpeed);
        myRigidBody.velocity = playerVelocity;

        //responsible for switching the animation of player from idle to running
        myAnimator.SetBool("isRunning", playerHasSpeed);
    }
    private void FlipSprite() {
        //determine if player's velocity is above 0
        bool playerHasSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        //if player is moving, change scale to (+/-) to flip the player sprite
        if(playerHasSpeed)
            transform.localScale = new Vector2 (Mathf.Sign(myRigidBody.velocity.x), 1f);
    }
}
