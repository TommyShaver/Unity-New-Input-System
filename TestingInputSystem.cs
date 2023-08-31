using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class TestingInputSystem : MonoBehaviour
{
    //Notice the Using for this to work.
    //This is really a lot but if some pratice I am sure it will be easy.

    // This is just to make the square jump
    private Rigidbody2D _squareRigidbody2d;


    //feild varible
    private InputPlayer inputPlayer;

    private void Awake()
    {
        // Jump funciont for square.
        _squareRigidbody2d = GetComponent<Rigidbody2D>();

        //Construct the input.
        inputPlayer = new InputPlayer();
        //You must Enable Action Map.
        inputPlayer.Player.Enable();

        //Input, Action Map, Input action name, subscribe to it and set it to a funtion
        inputPlayer.Player.Jump.performed += Jump;
        inputPlayer.Player.Fire.performed += Fire;
    }

    private void FixedUpdate()
    {
        //Use the FixedUpdate to track movement for every frame recall.
        //This is where the function [PlayerMovementSideScoller(), PlayerMovementAllDirectoins()]
    }

    private void PlayerMovementSideScoller()
    {
        Vector2 inputVector = inputPlayer.Player.Movement.ReadValue<Vector2>();
        float moveSpeed = 5f;
        _squareRigidbody2d.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * moveSpeed, ForceMode2D.Impulse);
    }

    private void PlayerMovementAllDirectoins()
    {
        Vector2 inputVector = inputPlayer.Player.Movement.ReadValue<Vector2>();
        float moveSpeed = 5f;
        _squareRigidbody2d.velocity = inputVector * moveSpeed;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        float _jumpSpeed = 3f;
        Debug.Log(context);
        if (context.performed)
        {
            Debug.Log("Jump");
            _squareRigidbody2d.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        }
    }
    private void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Fire");
        }
    }
}
