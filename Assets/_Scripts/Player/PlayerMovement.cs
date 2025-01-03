using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float _speed = 5;
    [SerializeField] private Transform _movePoint;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private Animator _myAnimator;

    [SerializeField] private bool _isFacingRight;
    private bool _canMove;

    void Awake() {
        if (_myAnimator == null) {
            _myAnimator = GetComponent<Animator>();
        }
    }

    void Start() {
        _movePoint.parent = null; // Detach partent
        _canMove = true;
        _isFacingRight = true;
    }

    void FixedUpdate() {
        float movement = Input.GetAxis("Horizontal");
        
        if(_canMove) {
            float movementAmout = _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, movementAmout);

            if (movement < 0 && _isFacingRight || movement > 0 && !_isFacingRight) {
                Flip();
            }
            
            if (Vector3.Distance(transform.position, _movePoint.position) <= 0.05f) {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
                    Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                    Move(new Vector3(0, Input.GetAxisRaw("Vertical"), 0));
                }
            }
        }
        else {
            _myAnimator.SetBool("isRunning", false);
        }
        if(transform.position == _movePoint.position) {
            _myAnimator.SetBool("isRunning", false);
        }
    }

    private void Move(Vector3 direction) {
        Vector3 newPosition = _movePoint.position + direction;
        if (!Physics2D.OverlapCircle(newPosition, 0.2f, _obstacleMask)) {
            _movePoint.position = newPosition;
            _myAnimator.SetBool("isRunning", true);
        }
    }
    public void Flip() {
        transform.Rotate(0, 180, 0);
        _isFacingRight = !_isFacingRight;
    }

    public void ResetMovePoint() {
        _movePoint.parent = gameObject.transform;
        _movePoint.position = gameObject.transform.position;
        _movePoint.parent = null;
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
