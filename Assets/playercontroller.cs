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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gun_left = transform.Find("gun_left");
    }

    // Update is called once per frame
    void Update()
    {
        float v, h;
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
         controlls = new Vector2(h, v); 


        if(Mathf.Abs(transform.position.x) > 24)
        {
            Vector3 newPos = new Vector3(transform.position.x * -1, 0, transform.position.z);
            transform.position = newPos;
        }
        if (Mathf.Abs(transform.position.z) > 19)
        {
            Vector3 newPos = new Vector3(transform.position.x, 0, transform.position.z *-1);
            transform.position = newPos;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
        
        firebuttondown = true;
        }


    }
    private void FixedUpdate()
    {
        
        rb.AddForce (transform.forward*controlls.y, ForceMode.Acceleration);
        rb.AddTorque(transform.up * controlls.x * acceleration, ForceMode.Acceleration);

       
        if(firebuttondown){
            GameObject bleeh = Instantiate(bleehPrefab, gun_left.position, Quaternion.identity);
            bleeh.GetComponent<Rigidbody>().AddForce(bleeh.transform.forward, ForceMode.VelocityChange);
            Destroy(bleeh, 5);
        }
        firebuttondown = false;





    }
}
