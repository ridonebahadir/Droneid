using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{

    private void Start()
    {
        gameObject.GetComponent<CharacterJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();

    }

}
