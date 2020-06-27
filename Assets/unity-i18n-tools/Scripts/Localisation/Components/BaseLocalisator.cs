using UnityEngine;
using System.Linq;

namespace Himeki.i18n
{
    public abstract class BaseLocalisator : MonoBehaviour
    {
        [System.Serializable]
        public struct PlatformKeyOverride
        {
            public RuntimePlatform platform;
            public string key;
        }

        [SerializeField] private PlatformKeyOverride[] platformOverrides;

        [SerializeField] private string localisationKey;

        [Header("Parameters")]
        [SerializeField] protected string[] parameters;

        protected bool ignorePlatformOverrides = false;

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

        public virtual void refresh()
        { }

        public void setLocalisationKey(string key, bool ignoreOverrides, params string[] args)
        {
            localisationKey = key;
            parameters = args;
            ignorePlatformOverrides = ignoreOverrides;

            refresh();
        }

        public string getActiveLocalisationKey()
        {
            var activeKey = localisationKey;

            if(!ignorePlatformOverrides && platformOverrides.Length > 0)
            {
                var keyOverride = platformOverrides.FirstOrDefault(o => o.platform == Application.platform);

                if (!string.IsNullOrEmpty(keyOverride.key))
                {
                    activeKey = keyOverride.key;
                }
            }

            return activeKey;
        }

        private void onLanguageChanged()
        {
            refresh();
        }
    }

}