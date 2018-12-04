using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {
    private Transform lookAt;
    private Vector3 offset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animDuration = 3.0f;
    private Vector3 animVectorOffset = new Vector3(0, 5, 5);


    private void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - lookAt.position;
    }
    private void LateUpdate()
    {
        moveVector = lookAt.position + offset;
        //x
        moveVector.x = 0.0f;
        //y
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);
        if (transition > 1f)
            transform.position = moveVector;
        else {
            //Anim start
            transform.position = Vector3.Lerp(moveVector + animVectorOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        }
    }
}
