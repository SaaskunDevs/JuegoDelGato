using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enum : MonoBehaviour
{
    enum EstadoJuego {
        Inicio,
        Jugando, //Cuando hagan un punto
        InicioyFnal, //Cuando se empieza y termina el juego
        Final
    }
    [SerializeField] string _EstadoJuego;
    GameManager _gameManager;
    PopUpInformation _popUpInformation;
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _popUpInformation = FindObjectOfType<PopUpInformation>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CambiarEstado(EstadoJuego.Inicio);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            CambiarEstado(EstadoJuego.Jugando);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            CambiarEstado(EstadoJuego.InicioyFnal);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            CambiarEstado(EstadoJuego.Final);
        }

        
    }

    void CambiarEstado(EstadoJuego estado)
    {
        switch (estado)
        {
            case EstadoJuego.Inicio:
                print("El juego ha iniciado");
                break;
            case EstadoJuego.Jugando:

                int round = Random.Range(0, 9);
                Debug.Log(round);
                if (round == _gameManager.round)
                {
                    _popUpInformation.ChooseInfo();
                }
                break;
            case EstadoJuego.InicioyFnal:
                print("El juego ha iniciado y terminado");
                break;
            case EstadoJuego.Final:
                print("El juego ha terminado");
                break;
        }
    }
}
