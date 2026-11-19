using UnityEngine;
using UnityEngine.InputSystem;

/*
 *   Componente 'Trigger' asignado a objetos interactuables en el entorno 3D. 
 *   Detecta la proximidad del jugador, muestra el prompt de interacción e inyecta el 'Dialog' 
 *   correspondiente al gestor principal.
 */

[RequireComponent (typeof(Collider))]
public class DialogStarter : MonoBehaviour
{
    [SerializeField]
    Dialog dialog;
    [SerializeField]
    Dialog dialogSecond;
    [SerializeField]
    Sprite portrait;
    [SerializeField]
    string speakr;
    [SerializeField]
    bool canIntercat = false;
    [SerializeField]
    bool interacted = false;

    InputAction interact;

    private void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
    }


    private void Update()
    {
        if(canIntercat)
        {
            if (!DialogManager.instance.CurrentlyInDialog)
            {
                if (interact.WasPressedThisFrame())
                {
                    if(interacted && dialogSecond != null)
                    {
                        DialogManager.instance.BootDialogManager(dialogSecond);
                    }
                    else
                    {
                        DialogManager.instance.BootDialogManager(dialog);
                        interacted = true;
                    }
                    canIntercat = false;

                }

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!DialogManager.instance.CurrentlyInDialog)
        {
            DialogManager.instance.ShowDialogManager();
            DialogManager.instance.SetText("Press E to interact");
            DialogManager.instance.SetSpeaker(speakr);
            DialogManager.instance.SetPortrait(portrait);
            canIntercat = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!DialogManager.instance.CurrentlyInDialog)
        {
            DialogManager.instance.HideDialogManager();
            DialogManager.instance.SetText("");
            DialogManager.instance.SetSpeaker("");
            DialogManager.instance.SetPortrait(null);
            canIntercat = false;

        }
    }

    
}
