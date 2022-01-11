using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //handle to controller
    private CharacterController _controller;
    private bool _groundedPlayer;
    [SerializeField]
    private float _speed = 4.5f;
    private Vector3 _playerVelocity;
    [SerializeField]
    private float _jumpheight = 2.0f;
    [SerializeField]
    private float _gravity = -15.81f;
    private bool _canDoubleJump = false;

    //variable for player coins
    [SerializeField]
    private int _coins;
    
    private UIManager _UIManager;




    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_UIManager == null)
        {

            Debug.LogError("The UI Manager is NULL");
        }
    }

    
    void Update()
    {
        //get horizontal input
        
        _groundedPlayer = _controller.isGrounded;
        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
            
        }

        //define direction based on that input
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        //Move based on that direction
        _controller.Move(move * Time.deltaTime * _speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        //allow player to jump
        if(Input.GetKeyDown(KeyCode.Space) && _groundedPlayer)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpheight * -2.0f * _gravity );
            _canDoubleJump = true;

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump == true)
                {
                    _playerVelocity.y += Mathf.Sqrt(_jumpheight * -4.0f * _gravity);
                    _canDoubleJump = false;
                }
               

            }
        }

        _playerVelocity.y += _gravity * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);


       
    }

    public void AddCoins()
    {
        _coins++;

        _UIManager.UpdateCoinDisplay(_coins);
    }
}
