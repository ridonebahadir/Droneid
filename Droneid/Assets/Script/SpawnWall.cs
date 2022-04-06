using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnWall : MonoBehaviour
{
    public int level;
    public GameObject[] walls;
    public GameObject human;
    public DrawLine drawLine;
    public GameObject DroneObj;
    public GameObject plane;
    public GameObject planeEndPoint;  
    public Slider slider;
    public TMP_Text sliderText;
    public int SpawnsPositionZ;
    public int EngelCount;
    public GameObject Finish;
    public Transform FinishTransform;
    int a;
    public GameManager gameManager;
    public DroneMovement droneMovement;
    private bool choose;
    //public int toplamEngelCount;



    List<int> numbersToChooseFrom = new List<int>(new int[] { 0, 1, 2,3,4,5,6,7,8,9,10,11,12 });
    List<int> numbersHuman = new List<int>(new int[] { 0,5,-5});
    private void Awake()
    {

        //for (int i = 0; i <12; i++)
        //{
        //    numbersToChooseFrom[i] = i;
        //}
        //numbersToChooseFrom = new List<int>(new int[toplamEngelCount]);
        EngelCount = PlayerPrefs.GetInt("Level");
        plane.transform.localScale = new Vector3(plane.transform.localScale.x, plane.transform.localScale.y,1+(0.4f*EngelCount));
        slider.maxValue = ((float)plane.transform.localScale.z)-1;

    }
    int randomDown;
    int randomUp;
    public float forwardSpeed;

    private void Start()
    {

        choose = false;
        switch (gameManager.currentLevel)
        {
            case 0:
            case 1:
            case 2:
                randomDown = 0; //Engel Seviyeleri
                randomUp = 4;
                forwardSpeed = 1f; //drone tip Hýz
                droneMovement.droneUpBorder = 30f; //drone tip yükseklik
                break;
            case 3:
            case 4:
            case 5:
                randomDown = 3;
                randomUp = 7;
                forwardSpeed = 1.3f;
                droneMovement.droneUpBorder = 35f;
                break;
            case 6:
            case 7:
            case 8:
                randomDown = 6;
                randomUp = 10;
                forwardSpeed = 1.6f;
                droneMovement.droneUpBorder = 40f;
                break;
            case 9:
            case 10:
            case 11:
                randomDown = 9;
                randomUp = 13;
                forwardSpeed = 1.9f;
                droneMovement.droneUpBorder = 45f;
                break;

            default:
                break;
        }


      
        drawLine.humanBetween=SpawnsPositionZ / 5;
        for (int i = 0; i <= EngelCount; i++)
        {
            if (!choose)
            {
                a = numbersToChooseFrom[Random.Range(1, randomUp)];
                //numbersToChooseFrom.Remove(a);
                Instantiate(walls[a], gameObject.transform.position + new Vector3(0, 0, i * SpawnsPositionZ), Quaternion.identity);
                choose = true;
            }
            else
            {
                a = numbersToChooseFrom[Random.Range(randomDown, randomUp)];
                //numbersToChooseFrom.Remove(a);
                Instantiate(walls[a], gameObject.transform.position + new Vector3(0, 0, i * SpawnsPositionZ), Quaternion.identity);
            }


           
           
           

        }
        Instantiate(Finish, new Vector3(0, -6.7f, planeEndPoint.transform.position.z), Quaternion.identity);
        int humanCount;
        if (PlayerPrefs.GetInt("Level") == 0)
        {
             humanCount = EngelCount + 7;
        }
        else
        {
             humanCount = EngelCount + 10;
        }
        for (int i = 0; i < humanCount; i++)
        {
            int a = numbersHuman[Random.Range(0, numbersHuman.Count)];
          
           GameObject clone= Instantiate(human, gameObject.transform.position + new Vector3(a, 0.1f, ((SpawnsPositionZ*i)/5)),/*Humanlarýn arasýný açarsan drawlinedan child Z positionu deðiþtir*/ Quaternion.Euler(0,180,0));
            drawLine.list.Add(clone);
        }
    }
    //private void FixedUpdate()
    //{
    //    slider.value = (DroneObj.transform.position.z * slider.maxValue)/(380*EngelCount);
    //    sliderText.text = "Level %" + Mathf.RoundToInt(slider.value * 100)/EngelCount + " Completed";
    //}

    public void NextLevel()
    {
        Drone.combo = 0;
        level=PlayerPrefs.GetInt("Level", level);
        level++;
        PlayerPrefs.SetInt("Level", level);
        gameManager.LevelsX -= 330;
        PlayerPrefs.SetFloat("ContentX", gameManager.LevelsX);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }
    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
