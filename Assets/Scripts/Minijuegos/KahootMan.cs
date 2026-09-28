using UnityEngine;

/*
 * Boton de respuestas correctas del minijuego del kahoot
 * Se presiona la respuesta correcta se avanza, se presiona
 * la incorrecta, se pierde
 */
public class KahootMan : MonoBehaviour
{
    [SerializeField] private KahotGame game;
    

    public void RespuestaCorr()
    {
        game.AumentarRespuestasCorrectas();
    }

    public void RespuestaIncorr()
    {
        game.RespuestasIncorrectas();
    }
}
