using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParametersDisplay : MonoBehaviour
{
    public Text text;
    private GameObject marker;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        marker = GameObject.FindGameObjectWithTag("clone");
        if(marker != null)
        {
            text.text = "Pozycja odbiornika : X(" + +marker.transform.position.x + "), Y("+marker.transform.position.y+"), Z("+marker.transform.position.z+")";
        }
    }
}
