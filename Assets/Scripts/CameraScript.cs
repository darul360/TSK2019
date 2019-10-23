using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Vector3 hitLocation;
    public RaycastHit hit;

    void Start()
    {
        
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        Physics.Raycast(ray, out hit);
        hitLocation = hit.point;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (gameObject.GetComponent<Camera>().fieldOfView > 1)
            {
                gameObject.GetComponent<Camera>().fieldOfView--;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (gameObject.GetComponent<Camera>().fieldOfView < 100)
            {
                gameObject.GetComponent<Camera>().fieldOfView++;
            }
        }

    }

}
