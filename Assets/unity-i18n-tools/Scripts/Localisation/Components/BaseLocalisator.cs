using UnityEngine;
using System.Linq;

namespace Himeki.i18n
{
    public abstract class BaseLocalisator : MonoBehaviour
    {

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

        private void onLanguageChanged()
        {
            refresh();
        }
    }

}