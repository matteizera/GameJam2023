using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Jump : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _playerVelocity;
    [SerializeField]
    private bool _groundedPlayer;
    [SerializeField]
    private float _jumpHeight = 1.0f;
    private float _gravityValue = -9.81f;
    private bool _jumpPressed;
    private Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        mAnimator = GetComponent<Animator>();   

    }

    // Update is called once per frame
    void Update()
    {
        MovementJump();
    }

    void MovementJump(){
        _groundedPlayer = _characterController.isGrounded;
        if(_groundedPlayer){
            _playerVelocity.y=0.0f;
        }

        if(_jumpPressed && _groundedPlayer){
            mAnimator.SetTrigger("isJumping");

            _playerVelocity.y =+ Mathf.Sqrt(_jumpHeight *-1f* _gravityValue );
            _jumpPressed = false;
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    public void OnJump(){
        if(_characterController.velocity.y==0 ){
            Debug.Log("jumping");
            _jumpPressed=true;
        }else{

        }
    }
}
