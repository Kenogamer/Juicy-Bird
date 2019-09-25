using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSwapper : MonoBehaviour
{
    public Camera Spring_Camera;
    public Camera Winter_Camera;
    public bool Ongoing;

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
