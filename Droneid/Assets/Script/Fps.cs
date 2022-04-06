using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fps : MonoBehaviour
{

    public float fps;
    public Text fpsText;
    
    void Update()
    {
        fps = (int)(Time.frameCount / Time.time);
        fpsText.text = fps.ToString();
    }
}
