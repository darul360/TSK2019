using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateCoordinates : MonoBehaviour
{
    private GameObject clone;
    public Vector2 coordinates;
    
    void Update()
    {
        clone = GameObject.FindGameObjectWithTag("clone");
        Vector3 positon = clone.transform.position;
        if (clone != null)
            coordinates = calcParams(positon);

    }

    Vector2 calcParams(Vector3 position)
    {
        float r = Mathf.Sqrt(Mathf.Pow(position.x, 2)) + Mathf.Sqrt(Mathf.Pow(position.y, 2)) + Mathf.Sqrt(Mathf.Pow(position.z, 2));
        float latitude = 1/Mathf.Sin(position.z/r) * (180 / Mathf.PI);
        float longitude;

            if (position.x > 0)
            {
                longitude = 1/Mathf.Tan(position.y / position.x) * (180 / Mathf.PI);
            }
            else if (position.y > 0)
            {
                longitude = 1/Mathf.Tan(position.y / position.x) * (180 / Mathf.PI) + 180;
            }
            else
            {
                longitude = 1/Mathf.Tan(position.y / position.x) * (180 / Mathf.PI) - 180;
            }

        return new Vector2(latitude, longitude);
    }
}
