using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private int botonID;
    [SerializeField] ButtonGame game;

    private void OnMouseDown()
    {
        if(game != null)
        {
            game.PresionarBotonCorrecto(botonID, gameObject);
        }
    }
}
