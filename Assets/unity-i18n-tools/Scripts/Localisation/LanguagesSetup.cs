using UnityEngine;
using System.Linq;

namespace Himeki.i18n
{

    [CreateAssetMenu(fileName = "Languages Setup", menuName = "Himeki/i18n/Languages Setup", order = 1)]
    public class LanguagesSetup : ScriptableObject
    {
        [Header("Languages")]
        [Tooltip("Default Game language.")]
        [SerializeField] private SystemLanguage defaultLanguage;
        [Tooltip("List of languages to be supported in the game.")]
        [SerializeField] private LanguageEntry[] supportedLanguages;

        public void warmUp()
        {
            for (int i = 0; i < supportedLanguages.Length; i++)
            {
                supportedLanguages[i].initialise();
            }
        }

        public int getSupportedLanguagesAmount()
        {
            return supportedLanguages.Length;
        }

        public SystemLanguage[] getSupportedLanguages()
        {
            return supportedLanguages.Select(entry => entry.getLanguage()).ToArray();
        }

        public bool supportsLanguage(SystemLanguage lang)
        {
            return supportedLanguages.Any(entry => entry.getLanguage() == lang);
        }

        public LanguageEntry getLanguage(int index)
        {
            if(supportedLanguages.Length > index)
            {
                return supportedLanguages[index];
            }

            return null;
        }

        public int getLanguageIndex(SystemLanguage lang)
        {
            for (int i = 0; i < supportedLanguages.Length; i++)
            {
                if (supportedLanguages[i].getLanguage() == lang)
                {
                    return i;
                }
            }

            return -1;
        }

        public LanguageEntry getLanguage(SystemLanguage lang)
        {
            for (int i = 0; i < supportedLanguages.Length; i++)
            {
                if (supportedLanguages[i].getLanguage() == lang)
                {
                    return supportedLanguages[i];
                }
            }

            return null;
        }

        public LanguageEntry getDefaultLanguage()
        {
            return getLanguage(defaultLanguage);
        }
    }
}
