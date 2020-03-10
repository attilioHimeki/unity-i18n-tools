using System;
using UnityEngine;
using TMPro;

namespace Himeki.i18n
{

    [DisallowMultipleComponent]
    public class LocalisationManager : MonoBehaviour
    {

        public static LocalisationManager instance;

        [Header("Options")]
        [Tooltip("Automatically initialise the manager at startup.")]
        [SerializeField] private bool initialiseOnAwake = true;

        [Tooltip("Reload selected language from saved data.")]
        [SerializeField] private bool storeLanguageOnUserPrefs = true;

        [Tooltip("Defines the preferred behaviour in case a key is missing in the language file.")]
        [SerializeField] private MissingKeyFallback missingKeyFallback;

        [Header("Fonts")]
        [Tooltip("Default Font to use for regular text fields.")]
        [SerializeField] private Font defaultFont;

        [Tooltip("Default Font to use for TextMeshPro text fields.")]
        [SerializeField] private TMP_FontAsset defaultTextMeshFont;

        [Header("Languages Setup")]
        [Tooltip("Languages provider to be supported in the game.")]
        [SerializeField] private LanguagesSetup languagesSetup;

        [Header("Debug")]
        [Tooltip("Print Debug log messages in the console - Disable for release builds")]
        [SerializeField] private bool showLogMessages = false;

        private LanguageEntry currentLanguage;
        private LanguageEntry defaultLanguage;

        public delegate void LanguageChangedHandler();
        public event LanguageChangedHandler OnLanguageChanged;

        /// <summary>
        /// Handler called when trying to retrieve the user saved language. 
        /// Uses PlayerPrefs by default, but can be overridden using overrideStoredLanguageHandlers.
        /// </summary>
        private Func<string> retrieveSavedUserLanguageHandler;

        /// <summary>
        /// Handler called when storing the user saved language. 
        /// Uses PlayerPrefs by default, but can be overridden using overrideStoredLanguageHandlers.
        /// </summary>
        private Action<string> storeSavedUserLanguageHandler;

        /// <summary>
        /// Is the manager initialised and ready to use?
        /// Can be false if initialiseOnAwake, in that case the manager will need to be initialised manually.
        /// </summary>
        private bool initialised = false;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);

                if (initialiseOnAwake)
                {
                    initialise();
                }
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void initialise()
        {
            if (!initialised)
            {
                if(languagesSetup != null)
                {
                    if (languagesSetup.getSupportedLanguagesAmount() > 0)
                    {
                        defaultLanguage = languagesSetup.getDefaultLanguage();
                        if(defaultLanguage == null)
                        {
                            defaultLanguage = languagesSetup.getLanguage(0);

                            Debug.LogError("The default language defined in the setup cannot be found. Fallback to the first language provided.");
                        }
                        
                        currentLanguage = defaultLanguage;

                        retrieveSavedUserLanguageHandler = PlayerPrefsStoredLanguageHandlers.getLanguageFromPlayerPrefs;
                        storeSavedUserLanguageHandler = PlayerPrefsStoredLanguageHandlers.saveLanguageOnPlayerPrefs;

                        languagesSetup.warmUp();

                        if (storeLanguageOnUserPrefs)
                        {
                            loadSavedUserLang();
                        }

                        initialised = true;
                    }
                    else
                    {
                        Debug.LogError("No Languages defined in the Localisation Setup provided, make sure at least one language is supported. Skipping initialisation.");
                    }
                }
                else
                {
                    Debug.LogError("No Languages Setup provided, make sure to create and assign it. Skipping initialisation.");
                }
            }
        }

        public void loadSavedUserLang()
        {
            if (retrieveSavedUserLanguageHandler != null)
            {
                var languageCode = retrieveSavedUserLanguageHandler.Invoke();

                if (!string.IsNullOrEmpty(languageCode))
                {
                    printDebugLog("Loading saved language from User Prefs: " + languageCode);

                    setLanguage(languageCode);
                }
                else
                {
                    printDebugLog("No Saved user language found");
                }
            }
            else
            {
                printDebugLog("No Saved user language function assigned!");
            }
        }


        public void setLanguage(string isoLang)
        {
            setLanguage(LanguageUtils.getLanguageFromISOCode(isoLang));
        }

        public void setLanguage(SystemLanguage lang)
        {
            var entry = languagesSetup.getLanguage(lang);
            if(entry != null)
            {
                setLanguage(entry);
            }
            else
            {
                printDebugLog("Language not supported! System Language: " + lang);
            }
        }

        public void setLanguage(int index)
        {
            var entry = languagesSetup.getLanguage(index);
            if(entry != null)
            {
                setLanguage(entry);
            }
            else
            {
                printDebugLog("Language not supported! Index: " + index);
            }
        }

        public void setLanguage(LanguageEntry entry)
        {
            printDebugLog("Settings language to " + entry.getLanguage());

            currentLanguage = entry;

            if (storeLanguageOnUserPrefs)
            {
                if (storeSavedUserLanguageHandler != null)
                {
                    var isoCode = LanguageUtils.getISOCodeFromLanguage(entry.getLanguage());
                    printDebugLog("Storing saved language in User Prefs: " + isoCode);
                    storeSavedUserLanguageHandler.Invoke(isoCode);
                }
            }

            if (OnLanguageChanged != null)
                OnLanguageChanged();
        }

        public bool supportsLanguage(SystemLanguage language)
        {
            return languagesSetup.supportsLanguage(language);
        }

        public LanguageEntry getCurrentLanguage()
        {
            return currentLanguage;
        }

        public string getStringForKey(string key)
        {
            if (currentLanguage.hasStringForKey(key))
            {
                return currentLanguage.getStringForKey(key);
            }
            else
            {
                printDebugLog("Can't find string for key: " + key);

                switch (missingKeyFallback)
                {
                    case MissingKeyFallback.Empty:
                        return String.Empty;
                    case MissingKeyFallback.ShowKey:
                        return key;
                    case MissingKeyFallback.ShowErrorString:
                        return "Can't find string for key: " + key;
                    case MissingKeyFallback.TryShowingDefaultLangString:
                        return defaultLanguage.getStringForKey(key);
                }
            }

            return String.Empty;
        }

        public string getStringForKey(string key, params object[] args)
        {
            var s = getStringForKey(key);

            if (args.Length > 0)
            {
                s = string.Format(s, args);
            }

            return s;
        }

        public int getLanguagesAmount()
        {
            return languagesSetup.getSupportedLanguagesAmount();
        }

        public Font getFontPerLanguage(LanguageEntry lang)
        {
            if (lang.hasCustomFont())
                return lang.getCustomFont();

            return defaultFont;
        }

        public Font getFontPerCurrentLanguage()
        {
            return getFontPerLanguage(currentLanguage);
        }

        public TMP_FontAsset getTextMeshFontPerLanguage(LanguageEntry lang)
        {
            if (lang.hasCustomTextMeshFont())
                return lang.getCustomTextMeshFont();

            return defaultTextMeshFont;
        }

        public TMP_FontAsset getTextMeshFontPerCurrentLanguage()
        {
            return getTextMeshFontPerLanguage(currentLanguage);
        }

        private void setLanguageFromSystemLanguage()
        {
            SystemLanguage systemLang = Application.systemLanguage;

            setLanguage(systemLang);
        }

        public void overrideStoredLanguageHandlers(Func<string> retrieveHandler, Action<string> storeHandler)
        {
            retrieveSavedUserLanguageHandler = retrieveHandler;
            storeSavedUserLanguageHandler = storeHandler;
        }

        public void resetDefaultStoredLanguageHandlers()
        {
            retrieveSavedUserLanguageHandler = PlayerPrefsStoredLanguageHandlers.getLanguageFromPlayerPrefs;
            storeSavedUserLanguageHandler = PlayerPrefsStoredLanguageHandlers.saveLanguageOnPlayerPrefs;
        }

        public void clearLanguageChangedListeners()
        {
            OnLanguageChanged = null;
        }

        private void printDebugLog(string message)
        {
            if (showLogMessages)
            {
                Debug.Log(message);
            }
        }
    }
}
