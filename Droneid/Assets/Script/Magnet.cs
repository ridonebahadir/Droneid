using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetForce = 200f;

    List<Rigidbody> rgBalls = new List<Rigidbody>();

    Transform magnetPoint;
    void Start()
    {
        magnetPoint = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Rigidbody item in rgBalls)
        {
            item.AddForce((magnetPoint.position - item.position) * magnetForce * Time.fixedDeltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            rgBalls.Add(other.GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            rgBalls.Remove(other.GetComponent<Rigidbody>());
        }
    }
}
