using UnityEngine;

public abstract class SOOpcion : ScriptableObject
{
    [SerializeField]
    string optionText;

    public string OptionText { get { return optionText; } }
    public abstract void OnSellected(DialogManager dMan);

}
