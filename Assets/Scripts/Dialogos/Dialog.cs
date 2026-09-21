using UnityEngine;

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
