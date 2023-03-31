using EzySlice;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sliceable : MonoBehaviour
{
    public GameObject particle;
    public GameObject sm;
    public Material[] materials;
    public float explosionForce;
    public float explosionRadius;
    public bool gravity, kinematic;
    int matIndex;
    void Start()
    {

    } 
    void Update()
    {

    }
    public void sliced()
    {
        matIndex = Random.Range(0,materials.Length);
        SlicedHull sliceobj = Slice(this.gameObject, materials[matIndex]);

        if (sliceobj != null)
        {
            Instantiate(particle,transform.position,Quaternion.identity);
            GameObject SlicedObjTop = sliceobj.CreateLowerHull(this.gameObject, materials[matIndex]);
            GameObject SlicedObjDown = sliceobj.CreateUpperHull(this.gameObject, materials[matIndex]); 
            Destroy(this.gameObject);
            AddComponent(SlicedObjTop);
            AddComponent(SlicedObjDown);
            ScoreManager.score++;
        }
    }
    private SlicedHull Slice(GameObject obj, Material material)
    {
        return obj.Slice(new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z) , new Vector3(1,0,0), material);
        
    }
    void AddComponent(GameObject obj)
    {
        obj.AddComponent<BoxCollider>();
        var rigidbody = obj.AddComponent<Rigidbody>();
        rigidbody.useGravity = gravity;
        rigidbody.isKinematic = kinematic;
        rigidbody.AddExplosionForce(explosionForce, obj.transform.position, explosionRadius);
        obj.tag = "sliced";
        Destroy(obj, 3f);
    }
}
