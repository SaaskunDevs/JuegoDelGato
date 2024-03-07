using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
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
    [SerializeField] Button[] _btnPlayerTurn;


    void Start()
    {
        _currentSprite = _xSprite;

        foreach (var button in _buttonsCat)
        {
            button.onClick.AddListener(() => OnClickButton(button));
        }
        foreach (var button in _btnPlayerTurn)
        {
            button.onClick.AddListener(() => ChangePlayerTurn(button));
        }
    }

    void Update()
    {
        
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

    public void ResetAll()
    {
        SceneManager.LoadScene(0);
    }
}
