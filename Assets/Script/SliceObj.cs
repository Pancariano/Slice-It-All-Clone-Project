using EzySlice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceObj : MonoBehaviour
{
    public GameObject lm;
    public Rigidbody rb;
    public bool isCutting = false;
    public GameObject knife;

    private void Start()
    {
    }

    private void Update()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionX;
        freezeRotation();     
    }

    void freezeRotation()
    {
        if (isCutting)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
       
        
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
        else if(other.tag == "win")
        {
            lm.GetComponent<LevelManager>().win = false;
            lm.GetComponent<LevelManager>().playing = false;
            lm.GetComponent<LevelManager>().menu = false;
            lm.GetComponent<LevelManager>().win = true;
            
            Time.timeScale = 0.001f;
        }
        else if (other.tag == "Kesilebilir")
        {         
            isCutting = true;
            other.GetComponent<sliceable>().sliced();
            
        }
        else if(other.tag != "Kesilebilir" && other.tag != "sliced")
        {
            rb.isKinematic = true;
            knife.GetComponent<KnifeMovement>().isStucked = true;

        }
    }





}
