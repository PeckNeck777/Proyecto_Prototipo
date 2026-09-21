using UnityEngine;

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
