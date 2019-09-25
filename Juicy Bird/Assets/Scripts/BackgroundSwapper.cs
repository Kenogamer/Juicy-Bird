using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSwapper : MonoBehaviour
{
    //starts a countdown and switches background if countdown is 30
    public Camera Spring_Camera;
    public Camera Winter_Camera;
    

    void Start()
    {
        StartCoroutine(SwitchBackground());
        Spring_Camera.enabled = false;
        Winter_Camera.enabled = true;
        
    }

    
    void Update()
    {
       
    }
    
    IEnumerator SwitchBackground()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            Spring_Camera.enabled = !Spring_Camera.enabled;
            Winter_Camera.enabled = !Winter_Camera.enabled;
        }

    }

}
