using UnityEngine;


/*
 *   Define el texto de la opción de respuesta e invoca 
 *   escuchadores (listeners) dinámicos en los botones generados.
 */
public abstract class SOOpcion : ScriptableObject
{
    [SerializeField]
    string optionText;

    [Header("Opciones Alicia (Opcionales)")]
    public bool afectaAAlicia = false;
    public EstadosAlicia nuevoEstado;

    public string OptionText { get { return optionText; } }
    public virtual void ComprobarAlicia()
    {
        if(afectaAAlicia)
        {
            Stats.EstadoAlicia = nuevoEstado;
            Debug.Log("¡Alicia fue modificada a estado: " + nuevoEstado + " !");
        }
    }

    public abstract void OnSellected(DialogManager dMan);

}
