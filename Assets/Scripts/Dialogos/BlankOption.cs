using UnityEngine;


/*
 * De las opciones que se pueden elegir, al hacerlo el dialogo de acaba
 * No se hace nada, solo acaba el dialogo.
 */
[CreateAssetMenu(fileName = "BlankOption", menuName = "Scriptable Objects/BlankOption")]
public class BlankOption : SOOpcion
{
    [SerializeField]
    string mensaje;

    public override void OnSellected(DialogManager dMan)
    {
        ActionBlank();
        dMan.ResetDialogSystem();
    }

    private void ActionBlank()
    {
        Debug.Log(mensaje);
    }
}
