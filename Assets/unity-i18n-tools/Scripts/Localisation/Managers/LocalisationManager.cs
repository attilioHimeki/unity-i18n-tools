using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class LocalisationManager : MonoBehaviour 
{

	public static LocalisationManager instance;

	private const string PLAYER_PREFS_LANG_ID = "currentLang";

	[SerializeField] private bool initialiseOnAwake = true;

	[SerializeField] private Font defaultFont;
	[SerializeField] private TMP_FontAsset defaultTextMeshFont;

	[SerializeField] private LanguageEntry[] supportedLanguages;
	
	[SerializeField] private MissingKeyFallback missingKeyFallback;

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

			loadLanguageFromPlayerPrefs();

			initialised = true;
		}
    }

	public void loadLanguageFromPlayerPrefs()
	{
		if(PlayerPrefs.HasKey(PLAYER_PREFS_LANG_ID))
		{
			var lang = PlayerPrefs.GetString(PLAYER_PREFS_LANG_ID);
			setLanguage(lang);
		}
		else
		{
			setLanguageFromSystemLanguage();
		}
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
		print("Settings language to " + entry.getLanguage());

		currentLanguage = entry;

		var isoCode = LanguageUtils.getISOCodeFromLanguage(entry.getLanguage());
		PlayerPrefs.SetString(PLAYER_PREFS_LANG_ID, isoCode);

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
}
