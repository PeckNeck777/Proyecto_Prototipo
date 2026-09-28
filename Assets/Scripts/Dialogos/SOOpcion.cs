using UnityEngine;


/*
 *   Define el texto de la opción de respuesta e invoca 
 *   escuchadores (listeners) dinámicos en los botones generados.
 */
public abstract class SOOpcion : ScriptableObject
{
    [SerializeField]
    string optionText;

    public string OptionText { get { return optionText; } }
    public abstract void OnSellected(DialogManager dMan);

}
