using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Packet : MonoBehaviour
{
    
    public GameObject NextLevel;
    public GameObject RestartButton;
    //public GameObject MagnetPoint;
    public GameObject Confetti;
    public Text ScoreText;
    public GameObject Canvas;
    private bool isEnd;
    //public GameObject cubes;
    //public float smoothColorChange;
    //public GameObject corn;
    //public Transform spawnCorn;
    //public Queue<GameObject> poolCornlist;
    //public List<GameObject> poolCornPacketlist;
    public GameObject Camera;
    public DroneCamera droneCamera;
    public Transform CameraEndTransform;
    public Transform CameraEndParent;
    public int poolCornListSize;
    [Header("Shake")]
    public float shaheTime;
    public float shakePower;
    
    public int humans;
    public int kalanHumans;

    public Text HumanText;

    int human;
    int kalan;
    int child;
   
    private void FixedUpdate()
    {
        if (isEnd)
        {
            Camera.transform.position = Vector3.Lerp(Camera.transform.position, CameraEndTransform.position, 0.1f * Time.deltaTime);
            Camera.transform.LookAt(gameObject.transform);
           
        }
        int humanCount = transform.childCount - 1;
        HumanText.text ="Human = " + humanCount.ToString();
    }
    public int dedi = 0;
    //GameObject Human;
    private void OnTriggerEnter(Collider other)
    {
        
        //if (other.tag=="Humann")
        //{

        //    //Human = other.gameObject;
        //    other.transform.parent = gameObject.transform;
        //    other.transform.localPosition = new Vector3(0, 0, 0);
        //    //StartCoroutine(ObjeyiKimildat(other.gameObject));
        //    //other.transform.localPosition = Vector3.Lerp(other.transform.localPosition, new Vector3(0,0,0), 0.3f);
        //    other.GetComponent<Animator>().enabled = false;
        //    //other.GetComponent<Rigidbody>().isKinematic = false;
        //    other.GetComponent<CharacterJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();
        //    other.transform.GetChild(0).gameObject.SetActive(false);
            
          
        //}

       

        if (other.tag=="End")
        {
            humans = transform.childCount;
            kalanHumans = humans / 5;

            Camera.transform.parent = CameraEndParent;
           
            isEnd = true;


            for (int i = 0; i < Canvas.transform.childCount; i++)
            {
                Canvas.transform.GetChild(i).gameObject.SetActive(false);
            }

           droneCamera.enabled = false;
            Confetti.SetActive(true);

            //StartCoroutine(GrowUpCorn());
            //child = gameObject.transform.childCount;
            //human = (gameObject.transform.childCount-1) / 5;
            //kalan = (gameObject.transform.childCount-1) % 5;

            //RestartButton.gameObject.SetActive(true);
            NextLevel.gameObject.SetActive(true);
            Debug.Log("KALAN " + kalan);
        }
       


    }





    IEnumerator ObjeyiKimildat(GameObject Human)
    {
        float kimildamaSuresi = 1f; // Objeyi 3 saniyede hareket ettir
        float gecenSure = 0f;
        
       
        //Vector3 hedefKonum = Vector3.zero;

        while (gecenSure < kimildamaSuresi) // Hen�z kimildamaSuresi kadar s�re ge�medi�i m�ddet�e bu kodu �al��t�r
        {
            gecenSure += Time.deltaTime; // gecenSure her saniye 1 artar
            Mathf.Lerp(Human.transform.localPosition.x, 0, 1f * Time.deltaTime);
            Mathf.Lerp(Human.transform.localPosition.y, 0, 1f * Time.deltaTime);
            Mathf.Lerp(Human.transform.localPosition.z, 0, 1f * Time.deltaTime);
            yield return null; // 1 frame bekle (yumu�ak hareket i�in objenin konumunu bir anda de�il, frame frame de�i�tirmeliyiz)
        }

        // kimildamaSuresi kadar s�re ge�ti, objenin hedefKonum'a tam oturdu�undan emin ol
        Human.transform.localPosition = Vector3.zero;
    }


    int a = 1;
    //int b = 0;
    
    void Late()
    {
        //a = Mathf.Clamp(a, 0, gameObject.transform.childCount);
        for (int i = 1; i <= kalanHumans; i++)
        {
            //gameObject.transform.GetChild(i).GetComponent<CharacterJoint>().connectedBody = null;
            gameObject.transform.GetChild(i).gameObject.transform.parent = null;
        }
        //a+=human;
        //if ((0<kalan)&&(kalan<5))
        //{
        //    //gameObject.transform.GetChild(child-kalan).GetComponent<CharacterJoint>().connectedBody = null;
        //    gameObject.transform.GetChild(child - kalan).transform.position = gameObject.transform.position;
        //    kalan--;
        //}
       
        //switch (kalan)
        //{
           
        //    case 1:
        //        gameObject.transform.GetChild(gameObject.transform.childCount).GetComponent<CharacterJoint>().connectedBody = null;
               
        //        break;
        //    case 2:
        //        gameObject.transform.GetChild(gameObject.transform.childCount-1).GetComponent<CharacterJoint>().connectedBody = null;

        //        break;
        //    case 3:
        //        gameObject.transform.GetChild(gameObject.transform.childCount-2).GetComponent<CharacterJoint>().connectedBody = null;
              
        //        break;
        //    case 4:
        //        gameObject.transform.GetChild(gameObject.transform.childCount-3).GetComponent<CharacterJoint>().connectedBody = null;
              
        //        break;
        //    default:
        //        break;
        //}
       
        //a += 1;
        //b = a - 1;
        //ScoreText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        NextLevel.gameObject.SetActive(true);
        //ScoreText.text ="Score = "+ b.ToString();
    }

   

    public void Restart()
    {
        Drone.combo = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
