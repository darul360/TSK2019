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
        float parametr = 26571f / 6371f; //odleglosc srodka ziemi od odbiornika + 20200 zeby bylo nad ziemia
        float posX = receiver.transform.position.x * parametr;
        float posY = receiver.transform.position.y * parametr;
        float posZ =  receiver.transform.position.z * parametr;
        Vector3 satelitePos = new Vector3(posX, posY, posZ);
        tempObject = Instantiate(sateliteDonor,satelitePos , Quaternion.identity);
        tempObject.tag = "SateliteClone";

    }
}
