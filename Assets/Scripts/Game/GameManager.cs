using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string[,] catGame  = new string[,]{  {"", "", ""}, // Matriz de 3x3 para el gato
                                                {"", "", ""}, 
                                                {"", "", ""} };
    public GameObject[] catButtons; // Zonas donde se encuantran los botones

    public GameObject O; // Prefab de la O
    public GameObject X; // Prefab de la X

    int round = 0; // Ronda actual
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Obtenemos el click del mouse
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Obtenemos el rayo del mouse
            RaycastHit hit; // Variable para guardar la informacion del rayo
            if (Physics.Raycast(ray,out hit)) // Si el rayo colisiona con algo buscamos con que boton colisiono
            {
                for (int i = 0; i < catButtons.Length; i++)
                {
                    if (hit.transform.name == catButtons[i].name)
                    {
                        int row = i / 3; // Obtiene la fila en la matriz
                        int col = i % 3; // Obtiene la columna en la matriz

                        if (round % 2 == 0)
                        {
                            catGame[row, col] = "X";
                            round++;
                            Instantiate(X, catButtons[i].transform.position, Quaternion.Euler(-45f, -90f, -90f));
                        }
                        else
                        {
                            catGame[row, col] = "O";
                            round++;
                            Instantiate(O, catButtons[i].transform.position, Quaternion.identity);
                        }
                    }
                }
            }
        }
    }

    void Winner ()
    {
        
    }
}
