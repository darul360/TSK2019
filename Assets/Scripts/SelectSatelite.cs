using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSatelite : MonoBehaviour
{
    public GameObject cameraScript;
    private List<GameObject> list;

    private void AddDescendantsWithTag(Transform parent, List<GameObject> list)
    {
        foreach (Transform child in parent)
        {
            list.Add(child.gameObject);
            AddDescendantsWithTag(child, list);
        }
    }

    void Update()
    {
        /*if(cameraScript.GetComponent<CameraScript>().hit.collider.gameObject.tag == "SateliteClone")
        {
            GameObject temp = cameraScript.GetComponent<CameraScript>().hit.collider.gameObject;
            AddDescendantsWithTag(temp.transform, list);
            Debug.Log(list.Count);
            foreach(GameObject go in list)
            {
                go.GetComponent<Renderer>().material.shader = shader;
            }
        }
*/    }
}
