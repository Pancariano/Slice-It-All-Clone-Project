using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stuck : MonoBehaviour
{
    [SerializeField] GameObject stuckPoint;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Stuck();
    }

    void Stuck()
    {
        Collider[] stuckPoints = Physics.OverlapBox(stuckPoint.transform.position, new Vector3(3, 0.5f, 0.1f), Quaternion.identity);

        foreach(Collider collider in stuckPoints)
        {
            if(collider.tag != "Kesilebilir" &&  collider.tag != "sliced") {
                rb.isKinematic = true;
            }
            
        }
    }
}
