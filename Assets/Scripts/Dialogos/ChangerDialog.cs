using UnityEngine;

[CreateAssetMenu(fileName = "ChangerDialog", menuName = "Scriptable Objects/ChangerDialog")]
public class ChangerDialog : SOOpcion
{
    [SerializeField]
    int sceneName;
    public override void OnSellected(DialogManager dMan)
    {
        ActioChanger();
        dMan.ResetDialogSystem();
    }

    private void ActioChanger()
    {
        SceneMan.instance.ChangeScene(sceneName);
    }
}
