using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerManager : MonoBehaviour
{
    [SerializeField] Color _colorSelected;
    [SerializeField] Color _colorUnselected;

    [Header("Sprites")]
    [SerializeField] Sprite _xSprite;
    [SerializeField] Sprite _oSprite;
    Sprite _currentSprite;

    [Header("GameObjects")]
    [SerializeField] TextMeshProUGUI _txtPlayerTurn;
    [SerializeField] Button[] _buttonsCat;
    [SerializeField] Button[] _btnPlayerTurn;
    [SerializeField] Button[] _btnStartResetOmitGame;
    [SerializeField] Button _btnChangeTurn;

    [Header("Scripts")]
    ControlAll _controlAll;
    
    [Header("VAriables")]
    public int round = 0;
    public bool buttonClicked = false;
    string playerTurn;

    void Start()
    {
        _controlAll = GetComponent<ControlAll>();
        _currentSprite = _xSprite;

        foreach (var button in _buttonsCat)
        {
            button.onClick.AddListener(() => OnClickButton(button));
        }
        foreach (var button in _btnPlayerTurn)
        {
            button.onClick.AddListener(() => ChangePlayerTurn(button));
        }
        foreach (var button in _btnStartResetOmitGame)
        {
            button.onClick.AddListener(() => StartResetOmitGame(button));
        }

        _btnChangeTurn.onClick.AddListener(activateTurns);
    }

    void Update()
    {
        if (!buttonClicked)
        {
            if (round % 2 == 0) // Si el turno es par es el turno del jugador 1
            {
                _txtPlayerTurn.text = "Turno del Jugador:\nX";
                _currentSprite = _xSprite;
            }
            else // Si el turno es impar es el turno del jugador 2
            {
                _txtPlayerTurn.text = "Turno del Jugador:\nO";
                _currentSprite = _oSprite;
            }
        }
        
    }
    void OnClickButton(Button button)
    {
        BtnValues btnValues = button.GetComponent<BtnValues>();
        if (btnValues._value == "")
            btnValues.BtnValue(_currentSprite.name);
        else
            return;

        Debug.Log("Button Clicked - " + button.name);
        button.image.sprite = _currentSprite;
        round++;

        // Verificar qué sprite se colocó
        if (_currentSprite.name.StartsWith("cross"))
        {
            Debug.Log("Se colocó una X");
            playerTurn = "X";
        }
        if (_currentSprite.name.StartsWith("Circle"))
        {
            Debug.Log("Se colocó una O");
            playerTurn = "O";
        }

        Debug.Log(button.name + "_" + playerTurn); //Btn_4_O
        _controlAll.ControlAllThings(button.name + "_" + playerTurn);

        //  // Enviar datos a través de UDP
        // string code = "ButtonClicked";
        // string message = button.name;
        // int port = 1900; // Reemplaza esto con el puerto al que deseas enviar los datos
        // _udpSender.SendData(code, message, port);
    }

    public void ChangePlayerTurn(Button button)
    {
        switch (button.name)
        {
            case "X_btn":
                _currentSprite = _xSprite;
                _txtPlayerTurn.text = "Turno del Jugador:\nX";
                break;
            case "O_btn":
                _currentSprite = _oSprite;
                _txtPlayerTurn.text = "Turno del Jugador:\nO";
                break;
        }
    }

    void StartResetOmitGame(Button button)
    {
        switch (button.name)
        {
            case "Btn_StartGame":
                //Inicio del juego
                break;
            case "Btn_Reset":
                ResetAll();
                break;
            case "Btn_Omitir":
                round++;
                break;
        }
    }

    public void ResetAll()
    {
        //_controlAll.ControlAllThings("Reset");
        SceneManager.LoadScene(0);
    }

    public void activateTurns()
    {
        buttonClicked = !buttonClicked;

        if(buttonClicked)
        {
            SelectOmitir();
            _btnChangeTurn.GetComponent<Image>().color = _colorSelected;
            _btnChangeTurn.GetComponentInChildren<TextMeshProUGUI>().text = "Activado";
        }
        else
        {
            UnselectOmitir();
            _btnChangeTurn.GetComponent<Image>().color = _colorUnselected;
            _btnChangeTurn.GetComponentInChildren<TextMeshProUGUI>().text = "Desactivado";
        }
    }
    void SelectOmitir()
    {
        Debug.Log("Select Omitir");
        foreach (var button in _btnPlayerTurn)
        {
            button.interactable = true;
        }
    }
    void UnselectOmitir()
    {
        Debug.Log("Unselect Omitir");
        foreach (var button in _btnPlayerTurn)
        {
            button.interactable = false;
        }
    }
}
