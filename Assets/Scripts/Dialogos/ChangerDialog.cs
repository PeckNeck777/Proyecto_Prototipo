using UnityEngine;

/*
 * De las opciones que se pueden elegir, al hacerlo se cambia la escena
 * Para pasar a otro escenario o iniciar un minijuego.
 */
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
