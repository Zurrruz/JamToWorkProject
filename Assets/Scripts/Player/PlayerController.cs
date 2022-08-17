using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpSpeed;
    [SerializeField]
    private float _gravity;

    private Vector3 _moveDirection;

    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        if (_characterController.isGrounded)
        {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection *= _speed;

            if (Input.GetKey(KeyCode.Space))
            {
                _moveDirection.y += _jumpSpeed;
            }
        }

        _moveDirection.y -= _gravity* Time.fixedDeltaTime;

        _characterController.Move(_moveDirection * Time.deltaTime);
    }
}
