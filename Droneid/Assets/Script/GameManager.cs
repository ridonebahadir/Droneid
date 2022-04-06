using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Transform Levels;
    public float LevelsX;
    //public Transform DroneIcon;
    //public float droneIconX;
    public int currentLevel;
    public GameObject StartPanel;
    public Transform Drone;
    public DroneMovement droneMovement;
    public SpawnWall spawnWall;
    public GameObject Confetti;
    public Drone drone;
    public GameObject[] laves;
    void Awake()
    {
        LevelsX = PlayerPrefs.GetFloat("ContentX");
        Levels.GetComponent<RectTransform>().position = new Vector3(LevelsX, Levels.transform.position.y, Levels.transform.position.z);
        currentLevel = PlayerPrefs.GetInt("Level");


        switch (currentLevel)
        {
            case 0:
            case 1:
            case 2:

                for (int i = 0; i < 3; i++)
                {
                    Levels.GetChild(i).GetChild(1).GetChild(3).gameObject.SetActive(false);
                    Levels.GetChild(i).GetChild(0).GetChild(3).gameObject.SetActive(false);
                }
                Levels.GetChild(currentLevel).GetChild(1).GetChild(3).gameObject.SetActive(true);
                Levels.GetChild(currentLevel).GetChild(0).GetChild(3).gameObject.SetActive(true);

                break;
            case 3:
            case 4:
            case 5:
                for (int i = 3; i < 6; i++)
                {
                    Levels.GetChild(i).GetChild(1).GetChild(3).gameObject.SetActive(false);
                    Levels.GetChild(i).GetChild(0).GetChild(3).gameObject.SetActive(false);
                }
                Levels.GetChild(currentLevel).GetChild(1).GetChild(3).gameObject.SetActive(true);
                Levels.GetChild(currentLevel).GetChild(0).GetChild(3).gameObject.SetActive(true);
                foreach (Transform item in Drone)
                {
                    item.gameObject.SetActive(false);
                }
                Drone.transform.GetChild(1).gameObject.SetActive(true);
                
                droneMovement.droneObject = Drone.transform.GetChild(1);
                break;
            case 6:
            case 7:
            case 8:
                for (int i = 6; i < 9; i++)
                {
                    Levels.GetChild(i).GetChild(1).GetChild(3).gameObject.SetActive(false);
                    Levels.GetChild(i).GetChild(0).GetChild(3).gameObject.SetActive(false);
                }
                Levels.GetChild(currentLevel).GetChild(1).GetChild(3).gameObject.SetActive(true);
                Levels.GetChild(currentLevel).GetChild(0).GetChild(3).gameObject.SetActive(true);
                foreach (Transform item in Drone)
                {
                    item.gameObject.SetActive(false);
                }
                Drone.transform.GetChild(2).gameObject.SetActive(true);
                
                droneMovement.droneObject = Drone.transform.GetChild(2);
                break;
            case 9:
            case 10:
            case 11:
                for (int i = 9; i < 12; i++)
                {
                    Levels.GetChild(i).GetChild(1).GetChild(3).gameObject.SetActive(false);
                    Levels.GetChild(i).GetChild(0).GetChild(3).gameObject.SetActive(false);
                }
                Levels.GetChild(currentLevel).GetChild(1).GetChild(3).gameObject.SetActive(true);
                Levels.GetChild(currentLevel).GetChild(0).GetChild(3).gameObject.SetActive(true);
                foreach (Transform item in Drone)
                {
                    item.gameObject.SetActive(false);
                }
                Drone.transform.GetChild(3).gameObject.SetActive(true);
                
                droneMovement.droneObject = Drone.transform.GetChild(3);
                break;
            default:
                break;
        }



        for (int i = 0; i <= currentLevel; i++)
        {
            Levels.GetChild(i).GetChild(1).GetChild(0).gameObject.SetActive(false);
            Levels.GetChild(i).GetChild(1).GetChild(1).gameObject.SetActive(true);
            Levels.GetChild(i).GetChild(1).GetChild(2).gameObject.SetActive(true);
            Debug.Log("curr "+currentLevel);
        }
      
       
    }

   public void StartButton()
    {
        droneMovement.enabled = true;
        StartPanel.SetActive(false);
        droneMovement.forwardSpeed = spawnWall.forwardSpeed;
        Confetti.SetActive(false);
    }
}
