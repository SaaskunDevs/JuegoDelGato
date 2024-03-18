using Saaskun;
using UnityEngine;

public class ControlAll : MonoBehaviour
{

    [SerializeField] private UDP_Sender sender;
    private int port = 8080;

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
                sender.SendData("Target", positionIndex.ToString() + "*" + emblem, port);
                
                break;
            case "StartGame":
                Debug.Log("Start Game");
                sender.SendData("GameManager", "StartGame", port);
                break;
            case "Restart":
                Debug.Log("Restart");
                sender.SendData("GameManager", "RestartGame", port);
                break;
            case "Claim":
                Debug.Log("Claim");
                sender.SendData("GameManager", "Claim", port);
                break;
            case "Omitir":
                sender.SendData("GameManager", "Omit", port);
                break;
            default:
                Debug.Log("No action found");
                break;
        }
    }
}
