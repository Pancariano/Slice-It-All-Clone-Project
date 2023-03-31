using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class forceBack : MonoBehaviour
{
    public GameObject lm;
    public Rigidbody rb;
    public GameObject sharp;
    public GameObject knife;
    void Start()
    {
        
    }
    void Update()
    { }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "lose")
        {

            lm.GetComponent<LevelManager>().win = false;
            lm.GetComponent<LevelManager>().playing = false;
            lm.GetComponent<LevelManager>().menu = false;
            lm.GetComponent<LevelManager>().lose = true;
            Time.timeScale = 0;
        }
        else if(other.tag != "sliced")
        {
                rb.isKinematic = false;
                rb.freezeRotation = false;
                rb.constraints = RigidbodyConstraints.FreezeRotationX;
                rb.constraints = RigidbodyConstraints.FreezeRotationY;
                sharp.GetComponent<SliceObj>().isCutting = false;
                rb.maxAngularVelocity = 15f;
                rb.velocity = new Vector3(0, 0, -1f * knife.GetComponent<KnifeMovement>().xForce);
                rb.AddForce(new Vector3(0, knife.GetComponent<KnifeMovement>().yForce, 0));
                rb.angularVelocity = new Vector3(-0.02f * knife.GetComponent<KnifeMovement>().zRotate, 0, 0);
            }
        }
    }
