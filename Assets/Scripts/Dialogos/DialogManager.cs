using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    [SerializeField] private Dialog currentDialog;
    [SerializeField] private bool currentInDialog = false;

    [SerializeField] private TMP_Text currentText, textSpeaker;
    [SerializeField] private Image spritePortrait;
    [SerializeField] private GameObject dialogCanvas;

    private InputAction interact;
    private int dialogIndex = 0;
    private Unidad[] conversation;

    [SerializeField] private Transform optionParent;
    [SerializeField] private GameObject optionPrefb;

    public bool CurrentlyInDialog { get { return currentInDialog; } set { currentInDialog = value; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
        HideDialogManager();
    }

    private void Update()
    {
        if (currentInDialog)
        {
            if (interact.WasPressedThisFrame())
            {
           
                if (dialogIndex < conversation.Length)
                {
                    CurrntDialogUnit(conversation[dialogIndex]);
                    dialogIndex++;
                }
                else
                {
                    if (currentDialog.Opcions != null && currentDialog.Opcions.Length > 0)
                    {
                        if (optionParent.GetComponentsInChildren<Button>().Length == 0)
                        {
                            ShowOptions(currentDialog.Opcions);
                        }
                    }
                    else
                    {
                        ResetDialogSystem();
                    }
                }
            }
        }
    }

    public void ShowDialogManager()
    {
        if(dialogCanvas != null)
        {
            dialogCanvas.SetActive(true);
        }
        
    }

    public void HideDialogManager()
    {
        if (dialogCanvas != null)
        {
            dialogCanvas.SetActive(false);
        }
    }

    public void BootDialogManager(Dialog dialog)
    {
        ResetDialogSystem();
        ShowDialogManager();

        currentDialog = dialog;
        currentInDialog = true;
        conversation = dialog.Conversation;
        dialogIndex = 0;

        ClearOptions();

        if (conversation != null && conversation.Length > 0)
        {
            CurrntDialogUnit(conversation[dialogIndex]);
            dialogIndex++;
        }
    }

    public void SetText(string text)
    {
        currentText.text = text;
    }

    public void SetSpeaker(string speaker)
    {
        textSpeaker.text = speaker;
    }

    public void SetPortrait(Sprite sprite)
    {
        if (spritePortrait != null)
        {
            spritePortrait.sprite = sprite;
            spritePortrait.gameObject.SetActive(sprite != null);
        }
    }

    public void CurrntDialogUnit(Unidad unidad)
    {
        SetText(unidad.Line);
        SetPortrait(unidad.Portrait);
        SetSpeaker(unidad.Speaker);
    }

    public void ResetDialogSystem()
    {
        currentInDialog = false;
        currentDialog = null;
        SetText("");
        SetSpeaker("");
        SetPortrait(null);
        dialogIndex = 0;
        conversation = null;

        ClearOptions();
        HideDialogManager();
    }

    public void ShowOptions(SOOpcion[] options)
    {
        ClearOptions(); 
        optionParent.gameObject.SetActive(true);

        foreach (SOOpcion opti in options)
        {
            GameObject newOption = Instantiate(optionPrefb, optionParent);
            newOption.GetComponent<Button>().onClick.AddListener(() => { opti.OnSellected(this); });
            newOption.GetComponentInChildren<TMP_Text>().text = opti.OptionText;
        }
    }

    public void ClearOptions()
    {
        foreach (Button btn in optionParent.GetComponentsInChildren<Button>())
        {
            Destroy(btn.gameObject);
        }

        optionParent.gameObject.SetActive(false);
    }
}
