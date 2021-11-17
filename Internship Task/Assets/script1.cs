using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System;

public class script1 : MonoBehaviour, IVirtualButtonEventHandler
{
    Vector3 movement;
    public AudioSource ping;
    public AudioSource beep;
    public int n=0;
    float speed = 20.0f;
    public int status = 1;
    [SerializeField] private Material mymaterial;
    public GameObject s1, s2;
    public float xAngle, yAngle, zAngle;
    
    
    VirtualButtonBehaviour[] vrb;
    // Start is called before the first frame update
    void Start()

    {
        movement = new Vector3 (30, 0, 0);

        vrb = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vrb.Length; i++)
        {
            vrb[i].RegisterEventHandler(this);
        }
        s1.SetActive(true);
        s2.SetActive(true);

    }
    
    // Update is called once per frame

    void Update()
    {
        if(status%2 ==0)
        {
            s2.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        }
        

    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.VirtualButtonName == "VBs1")
        {
            ping.Play();
            n++;
            if (n == 6)
            {
                n = 1;

            }
            switch (n)
            {
                case 1:
                    mymaterial.color = Color.blue;
                    break;
                case 2:
                    mymaterial.color = Color.green;
                    break;
                case 3:
                    mymaterial.color = Color.red;
                    break;
                case 4:
                    mymaterial.color = Color.magenta;
                    break;
                case 5:
                    mymaterial.color = Color.cyan;
                    break;
                default:
                    mymaterial.color = Color.white;
                    break;




            }

      
        }
        else if (vb.VirtualButtonName == "VBs2")
        {
            beep.Play();
            status++;
         
        }


    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }
}

