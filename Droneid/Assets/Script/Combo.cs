using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour
{
    public Text combotext;
    void Start()
    {
       
        combotext.text = "x";
    }
    private void FixedUpdate()
    {
        combotext.text = "x" + Drone.combo.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
           
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            
        }
    }
}
