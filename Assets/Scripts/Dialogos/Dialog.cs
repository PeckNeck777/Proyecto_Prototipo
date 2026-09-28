using UnityEngine;

/*
 *   Contenedor de datos que almacena un arreglo ordenado de 'Unidades' 
 *   para simular secuencias de conversación. Incluye además un arreglo dinámico de opciones ('SOOpcion'). 
 */

[CreateAssetMenu(fileName = "Dialog", menuName = "Scriptable Objects/Dialog")]
public class Dialog : ScriptableObject
{
    [SerializeField]
    Unidad[] conversation;

    [SerializeField]
    SOOpcion[] opciones;
    public Unidad[] Conversation { get { return conversation; } }

    public SOOpcion[] Opcions { get { return opciones; } }

    
}
