using UnityEngine;
using System.Linq;

namespace Himeki.i18n
{
    public abstract class BaseTextFieldLocalisator : MonoBehaviour
    {
        [System.Serializable]
        public struct PlatformKeyOverride
        {
            public RuntimePlatform platform;
            public string textKey;
        }

        [SerializeField] protected string textKey;
        [SerializeField] protected PlatformKeyOverride[] textKeyOverrides;

        [Header("Parameters")]
        [SerializeField] protected string[] parameters;

        private bool ignorePlatformOverrides = false;

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

        public void setText(string key, bool ignoreOverrides, params string[] args)
        {
            textKey = key;
            parameters = args;
            ignorePlatformOverrides = ignoreOverrides;

            refreshText();
        }

        public string getLocalisedText()
        {
            var localisedKey = textKey;

            if(!ignorePlatformOverrides && textKeyOverrides.Length > 0)
            {
                var keyOverride = textKeyOverrides.FirstOrDefault(o => o.platform == Application.platform);

                if (!string.IsNullOrEmpty(keyOverride.textKey))
                {
                    localisedKey = keyOverride.textKey;
                }
            }

            return LocalisationManager.instance.getStringForKey(localisedKey, parameters);
        }

        public virtual void refreshText()
        { }

        public virtual void refreshFont()
        { }

    }
}