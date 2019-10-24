using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParametersDisplay : MonoBehaviour
{
    public Text text,text2;
    private GameObject marker,satelite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        marker = GameObject.FindGameObjectWithTag("clone");
        GameObject[] go = GameObject.FindGameObjectsWithTag("SateliteClone");
        foreach(GameObject gos in go)
        {
            if (gos.GetComponent<SelectSatelite>().IAMSelected)
            {
                text2.text = "Pozycja satelity : X(" + +gos.transform.position.x + "), Y(" + gos.transform.position.y + "), Z(" + gos.transform.position.z + ")";
            }
        }
        if(marker != null)
        {
            text.text = "Pozycja odbiornika : X(" + +marker.transform.position.x + "), Y("+marker.transform.position.y+"), Z("+marker.transform.position.z+")";
        }
    }
}
