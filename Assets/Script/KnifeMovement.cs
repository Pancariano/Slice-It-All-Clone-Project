using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class KnifeMovement : MonoBehaviour
{
    public GameObject sharp;
    Rigidbody rb;
    [SerializeField]
    public float xForce, yForce, zRotate;
    public bool isStucked;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Movement();
        
    }

    void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isStucked)
            { 
                transform.position= new Vector3(transform.position.x,transform.position.y + 0.25f, transform.position.z);
                isStucked= false;
            }
            rb.isKinematic = false;
            rb.freezeRotation = false;
            rb.constraints = RigidbodyConstraints.FreezeRotationX;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            sharp.GetComponent<SliceObj>().isCutting = false;
            rb.maxAngularVelocity = 15f;
            rb.velocity = new Vector3(0, 0, xForce);
            rb.AddForce(new Vector3(0, yForce, 0));
            rb.angularVelocity = new Vector3(zRotate, 0, 0);
            
        }
    }
}
