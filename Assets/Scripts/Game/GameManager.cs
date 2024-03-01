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
    bool winner = false; // Si hay un ganador

    [SerializeField] VFXControl _vfxControl;
    void Start()
    {
        
    }


    void Update()
    {
        if (!winner) // Si ya hay un ganador no se hace nada
        {
            Winner(); // Revisamos quien gano

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
                            if (catGame[row, col] != "") // Si ya hay algo en esa posicion no se hace nada
                            {
                                Debug.Log("Ya hay algo ahi");
                                return;
                            }
                            if (round % 2 == 0)
                            {
                                catGame[row, col] = "X";
                                _vfxControl.VFXEffect();
                                round++;
                                Instantiate(X, catButtons[i].transform.position, Quaternion.Euler(-45f, -90f, -90f));
                            }
                            else
                            {
                                catGame[row, col] = "O";
                                _vfxControl.VFXEffect();
                                round++;
                                Instantiate(O, catButtons[i].transform.position, Quaternion.identity);
                            }
                        }
                    }
                }
            }
        }
    }

    void Winner ()
    {
        for (int i = 0; i < 3; i++)
        {
            // Verifica las filas
            if (catGame[i, 0] != "" && catGame[i, 0] == catGame[i, 1] && catGame[i, 0] == catGame[i, 2])
            {
                Debug.Log("El ganador es " + catGame[i, 0]);
                winner = true;
                return;
            }

            // Verifica las columnas
            if (catGame[0, i] != "" && catGame[0, i] == catGame[1, i] && catGame[0, i] == catGame[2, i])
            {
                Debug.Log("El ganador es " + catGame[0, i]);
                winner = true;
                return;
            }
        }

        // Verifica la diagonal principal
        if (catGame[0, 0] != "" && catGame[0, 0] == catGame[1, 1] && catGame[0, 0] == catGame[2, 2])
        {
            Debug.Log("El ganador es " + catGame[0, 0]);
            winner = true;
            return;
        }

        // Verifica la diagonal secundaria
        if (catGame[0, 2] != "" && catGame[0, 2] == catGame[1, 1] && catGame[0, 2] == catGame[2, 0])
        {
            Debug.Log("El ganador es " + catGame[0, 2]);
            winner = true;
            return;
        }

        // Si no hay ganador
        if (round == 9)
        {
            Debug.Log("El juego es un empate");
        }
    }
}
