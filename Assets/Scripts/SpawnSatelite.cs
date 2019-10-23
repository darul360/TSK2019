using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSatelite : MonoBehaviour
{
    private GameObject sateliteDonor;
    private GameObject tempObject;
    // Start is called before the first frame update
    public void Spawn()
    {
        GameObject receiver = GameObject.FindGameObjectWithTag("clone");
        sateliteDonor = GameObject.FindGameObjectWithTag("Satelite");
        float posX = 2 * receiver.transform.position.x;
        float posY = 2 * receiver.transform.position.y;
        float posZ = 2 * receiver.transform.position.z;
        Vector3 satelitePos = new Vector3(posX, posY, posZ);
        tempObject = Instantiate(sateliteDonor,satelitePos , Quaternion.identity);
        tempObject.tag = "SateliteClone";

    }
}
