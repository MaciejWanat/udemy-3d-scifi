﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    private float _gravity = 9.8f;

    // Use this for initialization
	void Start ()
    {
        _controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CalculateMovement();
	}

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;

        _controller.Move(velocity * Time.deltaTime);
    }
}
