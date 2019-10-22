using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateEarth : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Camera camera;
    private bool ispressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
	public void Update()
    {
        if(gameObject.tag == "LeftArrow")
        {
            if (ispressed)
            {
                camera.transform.LookAt(new Vector3(0,0,0));
                camera.transform.Translate(Vector3.left * Time.deltaTime*300);
            }
        }

        if(gameObject.tag == "RightArrow")
        {
            if (ispressed)
            {
                camera.transform.LookAt(new Vector3(0, 0, 0));
                camera.transform.Translate(Vector3.right * Time.deltaTime*300);
            }
        }


        if (gameObject.tag == "UpArrow")
        {
            if (ispressed)
            {
                camera.transform.LookAt(new Vector3(0, 0, 0));
                camera.transform.Translate(Vector3.up * Time.deltaTime * 300);
            }
        }

        if (gameObject.tag == "DownArrow")
        {
            if (ispressed)
            {
                camera.transform.LookAt(new Vector3(0, 0, 0));
                camera.transform.Translate(Vector3.down * Time.deltaTime * 300);
            }
        }

    }
}
