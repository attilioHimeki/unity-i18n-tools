using UnityEngine;

namespace Himeki.i18n
{
    public class BaseTextFieldLocalisator : MonoBehaviour
    {
        [SerializeField] protected string textKey;

        [Header("Parameters")]
        [SerializeField] protected string[] parameters;

        void OnEnable()
        {
            LocalisationManager.instance.OnLanguageChanged += onLanguageChanged;

            refresh();
        }
        void OnDisable()
        {
            LocalisationManager.instance.OnLanguageChanged -= onLanguageChanged;
        }
        void OnDestroy()
        {
            LocalisationManager.instance.OnLanguageChanged -= onLanguageChanged;
        }

        private void onLanguageChanged()
        {
            refresh();
        }

        public void refresh()
        {
            refreshText();
            refreshFont();
        }

        public void setText(string key, params string[] args)
        {
            textKey = key;
            parameters = args;

            refreshText();
        }

        public virtual void refreshText()
        { }

        public virtual void refreshFont()
        { }

    }
}