using UnityEngine;
using TMPro;

namespace Himeki.i18n
{

    [DisallowMultipleComponent]
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextMeshProFieldLocalisator : BaseTextFieldLocalisator
    {

        [Header("Fonts")]
        [SerializeField] private TMP_FontAsset overrideFont;

        private TextMeshProUGUI meshTextField;

        void Awake()
        {
            meshTextField = GetComponent<TextMeshProUGUI>();
        }

        public override void refreshText()
        {
            meshTextField.text = getLocalisedText();
        }

        public override void refreshFont()
        {
            var refreshedFont = (overrideFont != null) ?
                                overrideFont :
                                LocalisationManager.instance.getTextMeshFontPerCurrentLanguage();

            if (refreshedFont && meshTextField.font != refreshedFont)
            {
                meshTextField.font = overrideFont;
            }
        }

    }
}