using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCity : MonoBehaviour
{
    public int tamanoX, tamanoY, probalidad;

    
    public GameObject[] prefab2;
    // Start is called before the first frame update
    void Start()
    {
        int[,] array2DDeclaration = new int[tamanoX, tamanoY];
        for (int x = 0; x < tamanoX; x++)
        {
            for (int y = 0; y < tamanoY; y++)
            {
                int r = Random.Range(1, 100);
                if (r <= probalidad && (x % 2) == 0 && (y % 2) == 0)
                {
                    array2DDeclaration[x, y] = 1;
                }
                else
                {
                    array2DDeclaration[x, y] = 0;
                }
            }
        }

        for (int x = 0; x < tamanoX-1; x++)
        {
            for (int y = 0; y < tamanoY-1; y++)
            {
                if (array2DDeclaration[x, y] == 1)
                {
                    //Debug.Log("se crea cubo en la posicion " + x + " , " + y);
                    createCube1(x-(tamanoX/2), y-(tamanoY/2));
                }
               
            }
        }
    }

    public void createCube1(int X,int Z)
    {   
        int r = Random.Range(0, 8);
        Instantiate(prefab2[r], new Vector3(X, 1, Z), Quaternion.identity);
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
