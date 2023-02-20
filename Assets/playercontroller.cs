using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float acceleration = 200;
    private Rigidbody rb;
    private Vector2 controlls;
    private bool firebuttondown = false;
    public GameObject bleehPrefab;

    private Transform gun_left;

    private CameraScript cs;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gun_left = transform.Find("gun_left");
        cs = Camera.main.GetComponent<CameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float v, h;
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
         controlls = new Vector2(h, v);


        float maxHorizontal = cs.worldWidith / 2;
        float maxVertical = cs.worldHeight / 2;




        if (Mathf.Abs(transform.position.x) > maxHorizontal)
        {
            Vector3 newPos = new Vector3(transform.position.x * -0.95f, 0, transform.position.z);
            transform.position = newPos;
        }
        if (Mathf.Abs(transform.position.z) > maxVertical)
        {
            Vector3 newPos = new Vector3(transform.position.x, 0, transform.position.z *-0.95f);
            transform.position = newPos;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
        
        firebuttondown = true;
        }


    }
    private void FixedUpdate()
    {

        rb.AddForce(transform.forward * controlls.y * acceleration, ForceMode.Acceleration);
        rb.AddTorque(transform.up * controlls.x * acceleration, ForceMode.Acceleration);


        if (firebuttondown)
        {
            GameObject Bullet = Instantiate(bleehPrefab, gun_left.position, Quaternion.identity);
            Bullet.transform.parent = null;
            Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 100,
                                                        ForceMode.VelocityChange);
            firebuttondown = false;
        }

    }



}
