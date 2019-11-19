using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculacions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("SateliteClone").Length >= 4)
        {
            GameObject[] satelites = GameObject.FindGameObjectsWithTag("SateliteClone");
            GameObject marker = GameObject.FindGameObjectWithTag("clone");
            List<float> pseudoranges = new List<float>();
            foreach(GameObject satelite in satelites)
            {
                pseudoranges.Add(pseudorangeCalc(satelite.transform.position));
            }

            float error = 1;
            while(error == 1)
            {
                for(int i=0; i<satelites.Length; i++)
                {
                    for(int j=0; j<3; j++)
                    {

                    }
                }
            }
          
           
        }

    }

    public float pseudorangeCalc(Vector3 satelitePos)
    {
        return Mathf.Sqrt(
            Mathf.Pow((0 - satelitePos.x), 2) +
            Mathf.Pow((0 - satelitePos.y), 2) +
            Mathf.Pow((0 - satelitePos.z), 2) 
            );
    }


    public double getAI1(double xi, double xu,double pi,double bu)
    {
        return ((xi - xu) / (pi - bu));
    }

    public void calcPosition(double pseudorange1,double pseudorange2, double pseudorange3, double pseudorange4,GameObject [] satelites)
    {

        //Vector4 firstCol = new Vector4(
        //        (float)getAI1(satelites[0].transform.position.x, 0, pseudorange1, 0),
        //        (float)getAI1(satelites[1].transform.position.x, 0, pseudorange1, 0),
        //        (float)getAI1(satelites[2].transform.position.x, 0, pseudorange1, 0),
        //        (float)getAI1(satelites[3].transform.position.x, 0, pseudorange1, 0)
        //    );

        //Vector4 secondCol = new Vector4(
        //        (float)getAI1(satelites[0].transform.position.y, 0, pseudorange2, 0),
        //        (float)getAI1(satelites[1].transform.position.y, 0, pseudorange2, 0),
        //        (float)getAI1(satelites[2].transform.position.y, 0, pseudorange2, 0),
        //        (float)getAI1(satelites[3].transform.position.y, 0, pseudorange2, 0)
        //    );

        //Vector4 thirdCol = new Vector4(
        //        (float)getAI1(satelites[0].transform.position.z, 0, pseudorange3, 0),
        //        (float)getAI1(satelites[1].transform.position.z, 0, pseudorange3, 0),
        //        (float)getAI1(satelites[2].transform.position.z, 0, pseudorange3, 0),
        //        (float)getAI1(satelites[3].transform.position.z, 0, pseudorange3, 0)
        //    );

        //Vector4 fourthCol = new Vector4(
        //        1f,
        //        1f,
        //        1f,
        //        1f
        //    );

        //Matrix4x4 firstMatrix = new Matrix4x4(firstCol, secondCol, thirdCol, fourthCol);
        //Matrix4x4 secondMatrix = firstMatrix.inverse;

        //Matrix4x4 result = firstMatrix * secondMatrix;
        //Debug.Log(result.m00 + " " + result.m01 + " " + result.m02);

    }
}
