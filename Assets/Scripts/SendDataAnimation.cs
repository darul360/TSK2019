using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDataAnimation : MonoBehaviour
{
    private GameObject data;
    private GameObject [] allSatelites;
    private bool startShooting = false;
    float timer=0;
    int waitingTime = 1;



    public void sendData()
    {
        startShooting = true;
    }

    void Update()
    {
        if (startShooting)
        {
            
            timer += Time.deltaTime;
            if (timer > waitingTime)
            {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("SateliteClone"))
                {
                    Debug.Log("4" + GameObject.FindGameObjectsWithTag("SateliteClone").Length);
                    GameObject dataBit = Instantiate(GameObject.FindGameObjectWithTag("Data"), obj.transform.position, Quaternion.identity);
                    GameObject point = GameObject.FindGameObjectWithTag("clone");
                }
                timer = 0;
            }
        }

        if(GameObject.FindGameObjectsWithTag("Data").Length > 0)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Data"))
            {
                go.transform.position += (GameObject.FindGameObjectWithTag("clone").transform.position - go.transform.position).normalized * 35f * Time.deltaTime;
                if(Vector3.Distance(GameObject.FindGameObjectWithTag("clone").transform.position,go.transform.position) < 0.5f)
                {
                    Destroy(go);
                }
            }
        }
    }
}
