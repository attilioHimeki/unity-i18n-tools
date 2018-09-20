using UnityEngine;
using System.Collections.Generic;
using TMPro;

[DisallowMultipleComponent]
public class LocalisationManager : MonoBehaviour 
{

	public static LocalisationManager instance;

	private const string PLAYER_PREFS_LANG_ID = "currentLang";

	[Header("Options")]
	[Tooltip("Automatically initialise the manager at startup.")]
	[SerializeField] private bool initialiseOnAwake = true;

	[Tooltip("Reload selected language using PlayerPrefs.")]
	[SerializeField] private bool storeLanguageOnUserPrefs = true;

	[Tooltip("Defines the preferred behaviour in case a key is missing in the language file.")]
	[SerializeField] private MissingKeyFallback missingKeyFallback;

	[Header("Fonts")]
	[Tooltip("Default Font to use for regular text fields.")]
	[SerializeField] private Font defaultFont;

	[Tooltip("Default Font to use for TextMeshPro text fields.")]
	[SerializeField] private TMP_FontAsset defaultTextMeshFont;

	[Header("Languages")]
	[Tooltip("List of languages to be supported in the game.")]
	[SerializeField] private LanguageEntry[] supportedLanguages;

	[Header("Debug")]
	[Tooltip("Print Debug log messages in the console - Disable for release builds")]
	[SerializeField] private bool showLogMessages = false;

	private LanguageEntry currentLanguage;
	private LanguageEntry defaultLanguage;

	public delegate void LanguageChangedHandler();
    public event LanguageChangedHandler OnLanguageChanged;

	private bool initialised = false;

	void Awake()
    {
		if (instance == null)
        {
            instance = this;
			DontDestroyOnLoad(gameObject);

			if(initialiseOnAwake)
				initialise();
        }
        else if (instance != this)
        {
            Destroy(gameObject);    
        }
    }

    public void initialise()
    {
		if(!initialised)
		{
			currentLanguage = supportedLanguages[0];
			defaultLanguage = supportedLanguages[0];
			
			foreach(var languageEntry in supportedLanguages)
			{
				languageEntry.initialise();
			}

			if(storeLanguageOnUserPrefs)
			{
				loadLanguageFromPlayerPrefs();
			}

			initialised = true;
		}
    }

	public void loadLanguageFromPlayerPrefs()
	{
		if(PlayerPrefs.HasKey(PLAYER_PREFS_LANG_ID))
		{
			var lang = PlayerPrefs.GetString(PLAYER_PREFS_LANG_ID);
			printDebugLog("Loading language from Player Prefs: " + lang);
			setLanguage(lang);
		}
		else
		{
			setLanguageFromSystemLanguage();
		}
	}

	public void saveLanguageOnPlayerPrefs(LanguageEntry entry)
	{
		var isoCode = LanguageUtils.getISOCodeFromLanguage(entry.getLanguage());
		PlayerPrefs.SetString(PLAYER_PREFS_LANG_ID, isoCode);

		printDebugLog("Language saved in Player Prefs: " + isoCode);
	}


	public void setLanguage(string isoLang)
    {
		setLanguage(LanguageUtils.getLanguageFromISOCode(isoLang));
    }

    public void setLanguage(SystemLanguage lang)
    {
    	for(int i = 0; i < supportedLanguages.Length; i++)
    	{
    		if(supportedLanguages[i].getLanguage() == lang)
    		{	
    			setLanguage(supportedLanguages[i]);

				break;
    		}
    	}
    }

	public void setLanguage(int index)
	{
		if(index >= 0 && index < supportedLanguages.Length)
		{
			setLanguage(supportedLanguages[index]);
		}
	}

	public void setLanguage(LanguageEntry entry)
	{
		printDebugLog("Settings language to " + entry.getLanguage());

		currentLanguage = entry;

		if(storeLanguageOnUserPrefs)
		{
			saveLanguageOnPlayerPrefs(entry);
		}

		if(OnLanguageChanged != null)
			OnLanguageChanged();
	}

	public bool supportsLanguage(SystemLanguage language)
	{
		for(int i = 0; i < supportedLanguages.Length; i++)
		{
			if(supportedLanguages[i].getLanguage() == language)
    		{	
    			return true;
    		}
		}

		return false;
	}

    public LanguageEntry getCurrentLanguage()
    {
    	return currentLanguage;	
    }

	public string getStringForKey(string key)
    {
		if(currentLanguage.hasStringForKey(key))
		{
    		return currentLanguage.getStringForKey(key);
		}
		else
		{
			printDebugLog("Can't find string for key: " + key);
			
			switch(missingKeyFallback)
			{
				case MissingKeyFallback.Empty:
					return StringUtils.EMPTY_STRING;
				case MissingKeyFallback.ShowKey:
					return key;
				case MissingKeyFallback.ShowErrorString:
					return "Can't find string for key: " + key;
				case MissingKeyFallback.TryShowingDefaultLangString:
					return defaultLanguage.getStringForKey(key);
			}
		}

		return StringUtils.EMPTY_STRING;
    }

    public int getLanguagesAmount()
    {
		return supportedLanguages.Length;
    }

    public Font getFontPerLanguage(LanguageEntry lang)
    {
    	if(lang.hasCustomFont())
			return lang.getCustomFont();

    	return defaultFont;	
    }

	public Font getFontPerCurrentLanguage()
	{
		return getFontPerLanguage(currentLanguage);
	}

	public TMP_FontAsset getTextMeshFontPerLanguage(LanguageEntry lang)
    {
    	if(lang.hasCustomTextMeshFont())
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

	public void clearLanguageChangedListeners()
	{
		OnLanguageChanged = null;
	}

	private void printDebugLog(string message)
	{
		if(showLogMessages)
		{
			Debug.Log(message);
		}
	}
}
