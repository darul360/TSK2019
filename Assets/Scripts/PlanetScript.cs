using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour {

    public GameObject cameraScript;
    public GameObject marker;
    private GameObject instance;

    void OnMouseDown()
    {
        Vector3 dir = cameraScript.GetComponent<CameraScript>().hitLocation;
        Debug.Log(dir);
        GameObject tempObj = GameObject.FindGameObjectWithTag("clone");
        if (tempObj != null) Destroy(tempObj);

        instance = Instantiate(marker, dir, Quaternion.identity);
        instance.tag = "clone";
    }
}
