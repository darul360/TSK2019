using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour {

    public GameObject cameraScript;
    public GameObject marker;
    public GameObject turnOnMarker;
    private GameObject instance;

    void OnMouseDown()
    {
        Vector3 dir = cameraScript.GetComponent<CameraScript>().hitLocation;
        GameObject tempObj = GameObject.FindGameObjectWithTag("clone");
        if (tempObj != null)
        {
            Destroy(tempObj);
            GameObject [] objects = GameObject.FindGameObjectsWithTag("SateliteClone");
            foreach(GameObject go in objects)
            {
                Destroy(go);
            }
        }

        instance = Instantiate(marker, dir, Quaternion.identity);
        instance.tag = "clone";
        turnOnMarker.SetActive(true);
        GetComponent<SendDataAnimation>().sendData();


    }
}
