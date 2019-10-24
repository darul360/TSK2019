using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSatelite : MonoBehaviour
{
    public GameObject cameraScript;
    private List<GameObject> list;
    public Material on;
    public Material off;
    public GameObject one, two, three, four, five;
    public bool IAMSelected = false;

    void OnMouseDown()
    {
        GameObject[] satelites = GameObject.FindGameObjectsWithTag("SateliteClone");
        foreach(GameObject go in satelites)
        {
            if (go.GetComponent<SelectSatelite>().IAMSelected)
            {
                go.GetComponent<SelectSatelite>().one.GetComponent<Renderer>().material = off;
                go.GetComponent<SelectSatelite>().two.GetComponent<Renderer>().material = off;
                go.GetComponent<SelectSatelite>().three.GetComponent<Renderer>().material = off;
                go.GetComponent<SelectSatelite>().four.GetComponent<Renderer>().material = off;
                go.GetComponent<SelectSatelite>().five.GetComponent<Renderer>().material = off;
                go.GetComponent<SelectSatelite>().IAMSelected = false;
            }
        }
        one.GetComponent<Renderer>().material = on;
        two.GetComponent<Renderer>().material = on;
        three.GetComponent<Renderer>().material = on;
        four.GetComponent<Renderer>().material = on;
        five.GetComponent<Renderer>().material = on;
        IAMSelected = true;
    }

    void Update()
    {
        if (UnityEngine.Input.GetMouseButton(0))
        {
            if(cameraScript.GetComponent<CameraScript>().hit.collider == null)
            {
                one.GetComponent<Renderer>().material = off;
                two.GetComponent<Renderer>().material = off;
                three.GetComponent<Renderer>().material = off;
                four.GetComponent<Renderer>().material = off;
                five.GetComponent<Renderer>().material = off;
                IAMSelected = false;
            }
        }

        if (IAMSelected )
        {
            GameObject marker = GameObject.FindGameObjectWithTag("clone");
            if (Input.GetKey(KeyCode.A))
                transform.RotateAround(marker.transform.position, marker.transform.up, 50 * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                transform.RotateAround(marker.transform.position, -marker.transform.up, 50 * Time.deltaTime);
            if (Input.GetKey(KeyCode.W))
                transform.RotateAround(marker.transform.position, marker.transform.right, 50 * Time.deltaTime);
            if (Input.GetKey(KeyCode.S))
                transform.RotateAround(marker.transform.position, -marker.transform.right, 50 * Time.deltaTime);
        }
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir*Time.deltaTime; // rotate it
        point = dir + pivot; // calculate rotated point
        return point; // return it
    }

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("entered");
    }
}
