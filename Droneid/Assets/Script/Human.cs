using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public bool move;
    public bool breakk;
    public GameObject bombParticleHuman;
    private Rigidbody rb;
    private Animator animator;
    private SphereCollider sphereCollider;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        sphereCollider = GetComponent<SphereCollider>();
    }
    private void Update()
    {
        if (move)
        {

            //transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), 0.1f);
           //transform.GetComponent<CharacterJoint>().connectedBody=gameObject.transform.parent.GetComponent<Rigidbody>();
            
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), Mathf.SmoothStep(0.0f, 1.0f, Mathf.SmoothStep(0.0f, 1.0f, 0.3f)));
            animator.enabled = false;
            rb.isKinematic = true;
            move = Vector3.Distance(transform.localPosition, new Vector3(0, 0, 0)) <= 0.01 ? false : true;
            Invoke("BoolChange", 2f);
            

        }
        if(breakk)
        {
            gameObject.transform.parent = null;
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Engel")
        {
            sphereCollider.enabled = false;
            foreach (Transform item in gameObject.transform)
            {
                item.gameObject.SetActive(false);
            }
            gameObject.transform.parent = null;
            Instantiate(bombParticleHuman, gameObject.transform.position, Quaternion.identity,transform);
          
        }
    }



}
