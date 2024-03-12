using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerManager : MonoBehaviour
{

    [Header("Sprites")]
    [SerializeField] Sprite _xSprite;
    [SerializeField] Sprite _oSprite;
    Sprite _currentSprite;

    [Header("GameObjects")]
    [SerializeField] TextMeshProUGUI _txtPlayerTurn;
    [SerializeField] Button[] _buttonsCat;
    [SerializeField] Button[] _btnStartResetOmitGame;

    [Header("Scripts")]
    ControlAll _controlAll;
    
    [Header("VAriables")]
    public int round = 0;
    public bool buttonClicked = false;
    string playerTurn;

    private bool started;

    void Start()
    {
        _controlAll = GetComponent<ControlAll>();
        _currentSprite = _xSprite;
        playerTurn = "X";

        foreach (var button in _buttonsCat)
        {
            button.onClick.AddListener(() => OnClickButton(button));
        }

        foreach (var button in _btnStartResetOmitGame)
        {
            button.onClick.AddListener(() => GameplayBtn(button));
        }

    }


    void OnClickButton(Button button)
    {
        if (!started)
            return;

        BtnValues btnValues = button.GetComponent<BtnValues>();
        if (btnValues._value == "")
            btnValues.BtnValue(_currentSprite.name);
        else
            return;

        round++;
        button.image.sprite = _currentSprite;
        _controlAll.ControlAllThings(button.name + "_" + playerTurn);
        CheckTurn();

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

    void GameplayBtn(Button button)
    {
        switch (button.name)
        {
            case "Btn_StartGame":
                StartGame();
                break;
            case "Btn_Reset":
                ResetAll();
                break;
            case "Btn_Omitir":
                round++;
                CheckTurn();
                _controlAll.ControlAllThings(playerTurn);
                break;
            case "Btn_Claim":
                Claim();
                break;
        }
    }

    void StartGame()
    {
        started = true;
        _controlAll.ControlAllThings("StartGame");
    }

    void CheckTurn()
    {
        if (round % 2 == 0) // Si el turno es par es el turno del jugador 1
        {
            playerTurn = "X";
            _txtPlayerTurn.text = "X";
            _currentSprite = _xSprite;
        }
        else // Si el turno es impar es el turno del jugador 2
        {
            playerTurn = "O";
            _txtPlayerTurn.text = "O";
            _currentSprite = _oSprite;
        }
    }

    void Claim()
    {
        _controlAll.ControlAllThings("Claim");
    }

    void ResetAll()
    {
        _controlAll.ControlAllThings("Restart");
        SceneManager.LoadScene(0);
    }


}
