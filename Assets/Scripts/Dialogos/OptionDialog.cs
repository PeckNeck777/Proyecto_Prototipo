using UnityEngine;

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
