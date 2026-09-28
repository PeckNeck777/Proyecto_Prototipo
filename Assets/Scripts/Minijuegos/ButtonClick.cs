using UnityEngine;

/*
 * Para los botones a presionar
 * solo llama el metodo de presionar de manera correcta el boton
 */
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
