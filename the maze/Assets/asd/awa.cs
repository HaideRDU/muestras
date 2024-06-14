using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class awa : MonoBehaviour
{
    public int tamañoX, tamañoY, probalidad;
    public GameObject prefab1;
    public GameObject prefab2;
    public float distanciaMaxima = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < tamañoX; x++)
        {
            for (int y = 0; y < tamañoY; y++)
            {
                int r = Random.Range(1, 100);
                if (r <= probalidad)
                {
                    float posX = x * 2.0f;  // Ajusta la posición en X
                    float posY = 0.0f;
                    float posZ = y * 2.0f;  // Ajusta la posición en Z

                    float distance = Vector3.Distance(transform.position, new Vector3(posX, posY, posZ));

                    if (distance <= distanciaMaxima)
                    {
                        if ((x % 2) == 0 && (y % 2) == 0)
                        {
                            Instantiate(prefab1, new Vector3(posX, posY, posZ), Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(prefab2, new Vector3(posX, posY, posZ), Quaternion.identity);
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}