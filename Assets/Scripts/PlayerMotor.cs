using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {
    [SerializeField] private float speed = 15f;

    private CharacterController controller;
    private Vector3 moveVector3;
    private float gravity = 12.0f;
    private float verticalVelocity = 0.0f;

    private float animDuration = 3.0f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Time.time < animDuration)
            controller.Move(Vector3.forward * speed * Time.deltaTime);
        else
            PlayerControl();
    }

    private void PlayerControl() {

        moveVector3 = Vector3.zero;
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // x - left and right
        moveVector3.x = Input.GetAxisRaw("Horizontal") * speed;
        // y - up and down
        moveVector3.y = verticalVelocity;
        //z - forward and backward
        moveVector3.z = speed;
        controller.Move(moveVector3 * Time.deltaTime);
    }

    public void SetSpeed(float modifer) {
        speed = 15 + modifer;
    }
}
