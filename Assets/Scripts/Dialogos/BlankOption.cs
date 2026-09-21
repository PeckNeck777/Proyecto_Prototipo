using UnityEngine;

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
