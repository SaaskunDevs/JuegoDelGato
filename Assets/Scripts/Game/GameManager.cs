using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI.Table;

public class GameManager : MonoBehaviour
{

    [SerializeField] private UiManager uiManager;

    [Header("Game Variables")]
    public int round = 0; // Ronda actual
    public int roundToClaim = 4;

    bool winner = false; // Si hay un ganador
    public string[,] catGame  = new string[,]{  {"", "", ""}, // Matriz de 3x3 para el gato
                                                {"", "", ""}, 
                                                {"", "", ""} };

    [Header("Prefabs")]
    public GameObject[] catButtons; // Zonas donde se encuantran los botones

    public GameObject O; // Prefab de la O
    public GameObject X; // Prefab de la X
    public GameObject XEffect; // Prefab del efecto visual de la X
    public GameObject OEffect; // Prefab del efecto visual de la O
    public TextMeshProUGUI playerTurn; // Texto para mostrar el turno del jugador

    [Header("Scripts")]
    [SerializeField] PopUpInformation _popUpInformation;
    [SerializeField] TurnAnimation _turnAnimation;
    [SerializeField] UserTurnGrid turnGrid;
    [SerializeField] WinnerLine line;



    void Update()
    {

    }
    IEnumerator InstantiateXEffect(int i,float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(XEffect, catButtons[i].transform.position, Quaternion.identity);
    }
    IEnumerator InstanmiateOEffect(int i, float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(OEffect, catButtons[i].transform.position, Quaternion.identity);
    }

    void CheckIfWinner ()
    {
        for (int i = 0; i < 3; i++)
        {
            // Verifica las filas
            if (catGame[i, 0] != "" && catGame[i, 0] == catGame[i, 1] && catGame[i, 0] == catGame[i, 2])
            {
                Debug.Log("El ganador es " + catGame[i, 0] + " index: " + i);

                winner = true;
                GetWinnerPositions("row", i);
                _popUpInformation.PopUpWinner(catGame[i, 0].ToString());
                return;
            }

            // Verifica las columnas
            if (catGame[0, i] != "" && catGame[0, i] == catGame[1, i] && catGame[0, i] == catGame[2, i])
            {
                Debug.Log("El ganador es " + catGame[0, i] + " index: " + i);
                winner = true;
                GetWinnerPositions("col", i);
                _popUpInformation.PopUpWinner(catGame[0, i].ToString());
                return;
            }
        }

        // Verifica la diagonal principal
        if (catGame[0, 0] != "" && catGame[0, 0] == catGame[1, 1] && catGame[0, 0] == catGame[2, 2])
        {
            Debug.Log("El ganador es " + catGame[0, 0]);
            winner = true;
            GetWinnerPositions("diag", 0);
            _popUpInformation.PopUpWinner(catGame[0, 0].ToString());
            return;
        }

        // Verifica la diagonal secundaria
        if (catGame[0, 2] != "" && catGame[0, 2] == catGame[1, 1] && catGame[0, 2] == catGame[2, 0])
        {
            Debug.Log("El ganador es " + catGame[0, 2]);
            winner = true;
            GetWinnerPositions("diag", 1);
            _popUpInformation.PopUpWinner(catGame[0, 2].ToString());
            return;
        }

        // Si no hay ganador
        if (round == 9)
        {
            Debug.Log("El juego es un empate");
            _popUpInformation.PopUpEquals();
        }

        if (!winner && round == roundToClaim)
            _popUpInformation.ShowClaim();
    }

    void GetWinnerPositions(string type, int index)
    {
        if(type == "row")
        {
            switch (index)
            {
                case 0:
                    GetWinnerLineData(catButtons[0].transform.position, catButtons[2].transform.position);
                    break;
                case 1:
                    GetWinnerLineData(catButtons[3].transform.position, catButtons[5].transform.position);
                    break;
                case 2:
                    GetWinnerLineData(catButtons[6].transform.position, catButtons[8].transform.position);
                    break;
                default:
                    break;
            }
        }

        if (type == "col")
        {
            switch (index)
            {
                case 0:
                    GetWinnerLineData(catButtons[0].transform.position, catButtons[6].transform.position);
                    break;
                case 1:
                    GetWinnerLineData(catButtons[1].transform.position, catButtons[7].transform.position);
                    break;
                case 2:
                    GetWinnerLineData(catButtons[2].transform.position, catButtons[8].transform.position);
                    break;
                default:
                    break;
            }
        }

        if (type == "diag")
        {
            switch (index)
            {
                case 0:
                    GetWinnerLineData(catButtons[0].transform.position, catButtons[8].transform.position);
                    break;
                case 1:
                    GetWinnerLineData(catButtons[2].transform.position, catButtons[6].transform.position);
                    break;
                default:
                    break;
            }
        }
    }

    void GetWinnerLineData(Vector2 pos0, Vector2 pos1)
    {
        line.GetLinePos(pos0, pos1);
    }

    public void AddTarget(string data)
    {

        string[] split = data.Split("*");
        CreateIcon(int.Parse(split[0]), split[1]);
    }

    public void CreateIcon(int indexChoosen, string emblem)
    {
        int i = indexChoosen; // Obtiene el indice del boton presionado
        if (i >= 0 && i < catButtons.Length) // Si el indice esta dentro del rango de la matriz (3x3
        {
            int row = i / 3; // Obtiene la fila en la matriz
            int col = i % 3; // Obtiene la columna en la matriz
            if (catGame[row, col] != "") // Si ya hay algo en esa posicion no se hace nada
            {
                Debug.Log("Ya hay algo ahi");
                return;
            }
            if (emblem == "X")
            {
                catGame[row, col] = "X";
                round++;
                GameObject newX = Instantiate(X, catButtons[i].transform.position, Quaternion.identity);
                StartCoroutine(InstantiateXEffect(i, .7f));

                newX.GetComponent<MeshShader>().ActivateAnimation();
            }
            else
            {
                catGame[row, col] = "O";
                round++;
                GameObject newO = Instantiate(O, catButtons[i].transform.position, Quaternion.identity);
                StartCoroutine(InstanmiateOEffect(i, .7f));

                newO.GetComponent<MeshShader>().ActivateAnimation();
            }
            if (round % 2 == 0) // Si el turno es par es el turno del jugador 1
            {
                playerTurn.text = "Turno: X";
                _turnAnimation.SwitchTurn("X");
                turnGrid.ChangeTeam(0);
            }
            else // Si el turno es impar es el turno del jugador 2
            {
                playerTurn.text = "Turno: O";
                _turnAnimation.SwitchTurn("O");
                turnGrid.ChangeTeam(1);
            }

            
        }
        CheckIfWinner();
    }


    public void GameManagerDataEntered(string data)
    {
        Debug.Log(data);

        switch (data)
        {
            case "StartGame":
                uiManager.StartGame();
                break;
            case "RestartGame":
                RestartGame();
                break;
            case "Claim":
                uiManager.DisableClaim();
                break;
            case "X":
                turnGrid.ChangeTeam(0);
                break;
            case "O":
                turnGrid.ChangeTeam(1);
                break;
            default:
                break;
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
