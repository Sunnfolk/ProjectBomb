using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    public Bomb _Bomb;
    
    public GameObject Light0;
    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;
    public GameObject Light5;
    public GameObject Light6;
    public GameObject Light7;
    public GameObject Light8;
    public GameObject Light9;
    public GameObject Wall;

    public static bool canActivateLight = false;
    
    void Start()
    {
        
    canActivateLight = false;
        
      Light0.SetActive(false);   
      Light1.SetActive(false);
      Light2.SetActive(false);
      Light3.SetActive(false);
      Light4.SetActive(false);
      Light5.SetActive(false);
      Light6.SetActive(false);
      Light7.SetActive(false);
      Light8.SetActive(false);
      Light9.SetActive(false);
      Wall.SetActive(false);
    }

    
    void Update()
    {
        if (canActivateLight)
        {
            Light0.SetActive(true);
            Light0.SetActive(true);   
            Light1.SetActive(true);
            Light2.SetActive(true);
            Light3.SetActive(true);
            Light4.SetActive(true);
            Light5.SetActive(true);
            Light6.SetActive(true);
            Light7.SetActive(true);
            Light8.SetActive(true);
            Light9.SetActive(true);
            Wall.SetActive(true);
        }
    }
}
