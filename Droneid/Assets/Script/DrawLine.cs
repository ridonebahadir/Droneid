using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public Transform Packet;
    public Transform Human;
    public List<GameObject> list;
    bool draw;
    int child = 0;
    public int humanBetween;
    public GameObject thuder;
    float dist;
    bool isMove;
    private void FixedUpdate()
    {

       

        Human = list[Mathf.Clamp(child, 0, list.Count)].transform;
        dist = Vector3.Distance(Packet.transform.position, Human.position);
        if (draw)
        {
           
            if (dist<8)
            {
                isMove = true;
                LineRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
                DrawLineStart();
                Human.transform.parent = Packet.transform;
                Human.GetComponent<Human>().move = true;
                //Human.GetComponent<Animator>().SetBool("Hang", true);
                Instantiate(thuder,Human);
               
              



            }
            else
            {
                Human.GetComponent<Human>().breakk =false;
               
                LineRenderer.material.SetColor("_Color", new Color(1f, 1f, 1f, 0f));
                DrawLineStart();
                


            }
            
        }
        
       
        
    }
     void DrawLineStart()
    {
       
       
        // set the color of the line

        // set width of the renderer

        
        // set the position
        LineRenderer.SetPosition(0, Packet.position);
        LineRenderer.SetPosition(1, Human.position);


        if ((Packet.transform.position.z>=88+(humanBetween * child))&&(child<list.Count))
        {
            child++;

            return;
        }
        
    }
    public void DrawBool()
    {
        draw = true;
    }

}
