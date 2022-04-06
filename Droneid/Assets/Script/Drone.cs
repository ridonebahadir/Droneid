using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Drone : MonoBehaviour
{
    public GameObject[] pervane;
    public GameObject[] lave;
    private int health;
    public DroneMovement droneMovement;
    public Rigidbody rb;
    public BoxCollider boxCollider;
    public static int combo;
    public Text ComboText;
    
    bool CameraFollow;
    public Transform CameraStart;
    public GameObject BombParticle;
    public GameObject packet;
    public DroneCamera droneCamera;
    public GameObject RopeColiison;
    public int degdi;
    public int humans;
    public GameObject Confetti;
    //public GameObject capsule;
    private void FixedUpdate()
    {
        if (gameObject.transform.position.z>=0)
        {
            droneCamera.positionBehindDrone.z = Mathf.MoveTowards(droneCamera.positionBehindDrone.z, -10, 0.1f);
        }
        if (CameraFollow)
        {
            //Camera.main.transform.eulerAngles = new Vector3(0, 0, 0);
            Camera.main.transform.position = /*new Vector3(0, 0, 0);*/Vector3.Lerp(Camera.main.transform.position, CameraStart.transform.position, 1f * Time.deltaTime);
            Invoke("Restart", 4f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Engel")
        {
            health++;
            switch (health)
            {
                case 1:
                    pervane[0].transform.parent = null;
                    pervane[0].transform.position += Vector3.down * 30 * Time.deltaTime;
                    lave[0].SetActive(true);
                    break;
                case 2:
                    pervane[1].transform.parent = null;
                    pervane[1].transform.position += Vector3.down * 30 * Time.deltaTime;
                    lave[1].SetActive(true);
                    break;
                case 3:
                    lave[2].SetActive(true);
                    droneCamera.enabled = false;
                    Invoke("Wait", 2.5f);
                    gameObject.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
                    boxCollider.isTrigger = false;
                    transform.position += Vector3.down * 30 * Time.deltaTime;
                    gameObject.transform.GetChild(0).rotation = Quaternion.Euler(45, 0, 0);
                    rb.useGravity = true;
                    droneMovement.forwardSpeed = 0;
                    droneMovement.enabled = false;
                    break;
                default:
                    break;
            }
            
           
           
            //Camera.main.transform.parent = CameraStart;
        }
        if (other.tag == "Combo")
        {
            other.gameObject.SetActive(false);
            other.gameObject.transform.parent.GetChild(0).gameObject.SetActive(true);
            Confetti.gameObject.SetActive(true);
            Invoke("Closed",4f);
            //Invoke("late", 3f);
            combo++;
          
        }
        if (other.tag=="End")
        {
            humans=packet.transform.childCount/5;
        }
        if (other.tag == "Score")
        {
            
            degdi++;
            Debug.Log("de�di" + degdi);
            Invoke("Late", 0.3f);
        }
    }
     void Late()
    {

        for (int i = 1; i <= humans; i++)
        {
            packet.transform.GetChild(i).gameObject.transform.parent = null;

        }

    }
    void Wait()
    {
       
        CameraFollow = true;
    }
    public void Restart()
    {
        combo = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }
    void Closed()
    {
        Confetti.SetActive(false);
    }
}