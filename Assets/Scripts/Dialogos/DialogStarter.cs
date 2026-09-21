using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Collider))]
public class DialogStarter : MonoBehaviour
{
    [SerializeField]
    Dialog dialog;
    [SerializeField]
    Sprite portrait;
    [SerializeField]
    string speakr;
    [SerializeField]
    bool canIntercat = false;

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
                    DialogManager.instance.BootDialogManager(dialog);
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
