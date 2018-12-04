using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tep : MonoBehaviour {
    [SerializeField] private GameObject ground, wall_left, wall_right;

    private float horizontalExt, verticlExt;

    private void Start()
    {
        horizontalExt = Camera.main.orthographicSize * Camera.main.aspect;
        verticlExt = Camera.main.orthographicSize;
        SetEnv();

    }

    private void SetEnv() {
        ground.transform.localScale = new Vector3(horizontalExt, 1f, 1f);
    }
}
