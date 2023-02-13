using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
Camera mainCamera;

    public float worldWidith;
    public float worldHeight;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        worldHeight = 2.0f * Camera.main.transform.position.y * Mathf.Tan(Camera.main.fieldOfView * 0.5f * Mathf.Deg2Rad);



        worldWidith = worldHeight * mainCamera.aspect;

        Debug.Log("Wielkość pola gry:" + worldWidith + "x"+ worldHeight);


    }
}
