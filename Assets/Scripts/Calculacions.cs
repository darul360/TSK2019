using Accord.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculacions : MonoBehaviour
{
    float[] gu = new float[3];
    bool flag = false;

    public object Matrix { get; private set; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == false)
        if(GameObject.FindGameObjectsWithTag("SateliteClone").Length >= 4)
        {
            GameObject[] satelites = GameObject.FindGameObjectsWithTag("SateliteClone");
            GameObject marker = GameObject.FindGameObjectWithTag("clone");
            float[] rao = new float[satelites.Length];



            /*ROBIE MACIERZ SP*/
            float[,] sp = new float[3, satelites.Length];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < satelites.Length; j++)
                {
                        if (i == 0)
                            sp[i, j] = satelites[j].transform.position.x;
                        if (i == 1)
                            sp[i, j] = satelites[j].transform.position.y;
                        if (i == 2)
                            sp[i, j] = satelites[j].transform.position.z;
                    }
            }
                /*------------------*/


                //% ***** Select initial guessed positions and clock bias *****
                float x_guess = 0, y_guess = 0, z_guess = 0, bu = 0;
                gu[0] = x_guess; gu[1] = y_guess; gu[2] = z_guess;


                //% Calculating rao the pseudo - range as shown in Equation(2.1) the 
                //% clock bias is not included

                for (int i = 0; i < satelites.Length; i++)
            {
                rao[i] =
                Mathf.Sqrt(
                Mathf.Pow((gu[0] - sp[0, i]), 2) +
                Mathf.Pow((gu[1] - sp[1, i]), 2) +
                Mathf.Pow((gu[2] - sp[2, i]), 2)
                );
            }

            float[] pr = new float[satelites.Length]; 

            // Wylosowalem te wartości
            for(int h = 0; h < pr.Length; h++)
            {
                float bias = Random.Range(0.0001f, 0.001f);
                pr[h] = rao[h] - bias;
            }

            //% generate the fourth column of the alpha matrix in Eq.    
            float[,] alpha = new float[satelites.Length, 4];

                for(int i=0; i<satelites.Length; i++)
                {
                    for(int j=0; j<4; j++)
                    {
                        alpha[i,j] = 1;
                    }
                }


            float error = 1;
            while (error > 0.01)
            {
                for(int i=0; i<satelites.Length; i++)
                {
                    for(int j=0; j<3; j++)
                    {
                        alpha[i, j] = (gu[j] - sp[j, i]) / rao[i];
                    }
                    //alpha[i, 3] = 1;
                }

             //% **find delta rao
             //% includes clock bias
                float[] drao = new float[rao.Length];
                for(int i=0; i< drao.Length; i++)
                {
                    drao[i] = pr[i] - (rao[i] + bu);
                }

                float[,] pseudoInvers = alpha.PseudoInverse();
                float[] result = pseudoInvers.Multiply(drao);

                bu = bu + result[3];

                for(int k = 0; k < 3; k++)
                {
                    gu[k] = gu[k] + result[k];
                }

                error = result[0] * result[0] + result[1] * result[1] + result[2] * result[2];

                for (int i = 0; i < satelites.Length; i++)
                {
                    rao[i] =
                    Mathf.Sqrt(
                    Mathf.Pow((gu[0] - sp[0, i]), 2) +
                    Mathf.Pow((gu[1] - sp[1, i]), 2) +
                    Mathf.Pow((gu[2] - sp[2, i]), 2)
                    );
                }

            }



        }
          
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
