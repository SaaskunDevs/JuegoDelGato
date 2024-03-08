using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAll : MonoBehaviour
{
    ControllerManager _controllerManager;
    PopUpInformation _popUpInformation;
    GameManager _gameManager;
    public int positionIndex;
    string emblem;
    void Start()
    {
        _controllerManager = GetComponent<ControllerManager>();
        _popUpInformation = GetComponent<PopUpInformation>();
        _gameManager = GetComponent<GameManager>();
    }
    public void ControlAllThings(string doSomething)
    {
        Debug.Log("Control ALL_ "+ doSomething);
        if (doSomething.StartsWith("Btn_"))
        {
            string[] parts = doSomething.Split('_');
            if (parts.Length >= 3)
            {
                positionIndex = int.Parse(parts[1]); // Obtiene el valor que se encuentra después del primer '_'
                emblem = parts[2]; // Obtiene el valor que se encuentra después del segundo '_'
            }
            doSomething = "Btn";
        }

        switch (doSomething)
        {
            case "Btn":
                Debug.Log(positionIndex);
                Debug.Log(emblem);
                //_gameManager.createIcon(positionIndex, emblem);
                break;
            case "EmpezarJuego":
                Debug.Log("Change Player Turn");
                break;
            case "Reset":
                _popUpInformation.ResetAll();
                Debug.Log("Reset Game");
                break;
            default:
                Debug.Log("No action found");
                break;
        }
    }
}
