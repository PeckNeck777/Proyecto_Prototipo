using UnityEngine;


/*
 * De las opciones que se pueden elegir, al hacerlo se carga otro dialogo
 * Ideal si se quiere dar continuidad en una serie de dialogos.
 */
[CreateAssetMenu(fileName = "OptionDialog", menuName = "Scriptable Objects/OptionDialog")] 
public class OptionDialog : SOOpcion
{
    [SerializeField]
    Dialog dialog;

    public override void OnSellected(DialogManager dMan)
    {
        ActionBooth(dMan);
    }

    private void ActionBooth(DialogManager dMan)
    {
        dMan.BootDialogManager(dialog);
    }
}
