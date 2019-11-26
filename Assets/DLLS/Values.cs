using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Values : MonoBehaviour
{
    bool flag = false;
    int oldVal = 0;
    public Text text;
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("clone") == null) flag = false;

        if(flag == false)
        if (GameObject.FindGameObjectsWithTag("SateliteClone").Length >= 4)
        {
            flag = true;
            GameObject clone = GameObject.FindGameObjectWithTag("clone");
            float x = clone.transform.position.x;
            float y = clone.transform.position.y;
            float z = clone.transform.position.z;
            int satelitesCount = GameObject.FindGameObjectsWithTag("SateliteClone").Length;
            oldVal = satelitesCount;
            
            if(x > 0)
               x = x - 0.7f / satelitesCount;
            if (x < 0)
               x = x + 0.7f / satelitesCount;
            if (y > 0)
               y = y - 0.3f / satelitesCount;
            if (y < 0)
               y = y + 0.3f / satelitesCount;
            if (z > 0)
                z = z - 0.8f / satelitesCount;
            if (z < 0)
                z = z + 0.8f / satelitesCount;


                text.text = "Wartość obliczona (x:" + x + ", y:" + y + ", z:" + z + ")"; 
        }

        if (GameObject.FindGameObjectsWithTag("SateliteClone").Length >= 4)
            if (GameObject.FindGameObjectsWithTag("SateliteClone").Length > oldVal)
        {
            GameObject clone = GameObject.FindGameObjectWithTag("clone");
            float x = clone.transform.position.x;
            float y = clone.transform.position.y;
            float z = clone.transform.position.z;

            if(x>0)
                x = x - 0.2f / (GameObject.FindGameObjectsWithTag("SateliteClone").Length - oldVal);
            else
                x = x + 0.2f / (GameObject.FindGameObjectsWithTag("SateliteClone").Length - oldVal);
            if(y>0)
                y = y - 0.2f / (GameObject.FindGameObjectsWithTag("SateliteClone").Length - oldVal);
            else
                y = y + 0.2f / (GameObject.FindGameObjectsWithTag("SateliteClone").Length - oldVal);
            if(z > 0)
                z = z - 0.2f / (GameObject.FindGameObjectsWithTag("SateliteClone").Length - oldVal);
            else
                z = z + 0.2f / (GameObject.FindGameObjectsWithTag("SateliteClone").Length - oldVal);
                text.text = "Wartość obliczona (x:"+ x + ", y:" + y + ", z:" + z + ")";
        }
    }
}
