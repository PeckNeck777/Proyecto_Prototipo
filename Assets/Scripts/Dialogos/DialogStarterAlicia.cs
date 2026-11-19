using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider))]
public class DialogStarterAlicia : MonoBehaviour
{
    [SerializeField]
    Dialog dialogAfter;
    [SerializeField]
    Dialog dialogTalkPending;
    [SerializeField]
    Dialog dialogDate;

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
        if (canIntercat)
        {
            if (!DialogManager.instance.CurrentlyInDialog)
            {
                if (interact.WasPressedThisFrame())
                {
                    Dialog dialogoAEjectuar = DialogoEjecutado();

                    if(interacted && dialogoAEjectuar != null)
                    {
                        DialogManager.instance.BootDialogManager(dialogAfter);
                    }
                    else
                    {
                        DialogManager.instance.BootDialogManager(dialogoAEjectuar);
                        interacted = true;
                    }

                    canIntercat = false;

                }

            }
        }
    }


    public Dialog DialogoEjecutado()
    {
        switch (Stats.EstadoAlicia)
        {
            case EstadosAlicia.NoHablado:
                return dialogTalkPending;
            
            case EstadosAlicia.Invitada:
                return dialogDate;

            case EstadosAlicia.NoInvitada:
                default:
                return dialogTalkPending;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!DialogManager.instance.CurrentlyInDialog)
        {
            DialogManager.instance.ShowDialogManager();
            DialogManager.instance.SetText("Press E to interact");
            DialogManager.instance.SetSpeaker(speakr);
            DialogManager.instance.SetPortrait(portrait);
            canIntercat = true;

        }
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
