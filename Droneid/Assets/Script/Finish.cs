using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Transform planeEndPoint;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = planeEndPoint.transform.position;
    }

   
}
