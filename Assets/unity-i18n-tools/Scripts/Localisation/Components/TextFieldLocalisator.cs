using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Text))]
public class TextFieldLocalisator : BaseTextFieldLocalisator
{

    [Header("Fonts")]
    [SerializeField] private Font overrideFont;

    private Text textField;

    void Awake()
    {
        textField = GetComponent<Text>();
    }

    public override void refreshText()
    {
        if (!string.IsNullOrEmpty(textKey))
        {
            var s = LocalisationManager.instance.getStringForKey(textKey, parameters);

            textField.text = s;
        }
    }

    public override void refreshFont()
    {
        var refreshedFont = (overrideFont != null) ?
                            overrideFont :
                            LocalisationManager.instance.getFontPerCurrentLanguage();

        if (refreshedFont && textField.font != refreshedFont)
        {
            textField.font = overrideFont;
        }
    }



}
