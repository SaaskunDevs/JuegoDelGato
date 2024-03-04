using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Variables")]
    int round = 0; // Ronda actual
    bool winner = false; // Si hay un ganador
    public string[,] catGame  = new string[,]{  {"", "", ""}, // Matriz de 3x3 para el gato
                                                {"", "", ""}, 
                                                {"", "", ""} };

    [Header("Prefabs")]
    public GameObject[] catButtons; // Zonas donde se encuantran los botones

    public GameObject O; // Prefab de la O
    public GameObject X; // Prefab de la X
    public TextMeshProUGUI playerTurn; // Texto para mostrar el turno del jugador

    [Header("Scripts")]
    [SerializeField] VFXControl _vfxControl;
    [SerializeField] PopUpInformation _popUpInformation;

    void Start()
    {
        
    }


    void Update()
    {
        if (!winner) // Si ya hay un ganador no se hace nada
        {
            Winner(); // Revisamos quien gano
            if (round % 2 == 0) // Si el turno es par es el turno del jugador 1
            {
                playerTurn.text = "Turno: X";
            }
            else // Si el turno es impar es el turno del jugador 2
            {
                playerTurn.text = "Turno: O";
            }
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
                                _vfxControl.VFXEffectX();
                                round++;
                                Instantiate(X, catButtons[i].transform.position, Quaternion.Euler(-45f, -90f, -90f));
                            }
                            else
                            {
                                catGame[row, col] = "O";
                                _vfxControl.VFXEffectO();
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
                _popUpInformation.PopUpWinner("¡Felicidades!", "Jugador: \n\n" + catGame[i, 0].ToString());
                return;
            }

            // Verifica las columnas
            if (catGame[0, i] != "" && catGame[0, i] == catGame[1, i] && catGame[0, i] == catGame[2, i])
            {
                Debug.Log("El ganador es " + catGame[0, i]);
                winner = true;
                _popUpInformation.PopUpWinner("¡Felicidades!", "Jugador: \n\n" + catGame[i, 0].ToString());
                return;
            }
        }

        // Verifica la diagonal principal
        if (catGame[0, 0] != "" && catGame[0, 0] == catGame[1, 1] && catGame[0, 0] == catGame[2, 2])
        {
            Debug.Log("El ganador es " + catGame[0, 0]);
            winner = true;
            _popUpInformation.PopUpWinner("¡Felicidades!", "Jugador: \n\n" + catGame[0, 0].ToString());
            return;
        }

        // Verifica la diagonal secundaria
        if (catGame[0, 2] != "" && catGame[0, 2] == catGame[1, 1] && catGame[0, 2] == catGame[2, 0])
        {
            Debug.Log("El ganador es " + catGame[0, 2]);
            winner = true;
            _popUpInformation.PopUpWinner("¡Felicidades!", "Jugador: \n\n" + catGame[0, 2].ToString());
            return;
        }

        // Si no hay ganador
        if (round == 9)
        {
            Debug.Log("El juego es un empate");
            _popUpInformation.PopUpWinner("Lastima", "Quedaron Empates");
        }
    }
}
