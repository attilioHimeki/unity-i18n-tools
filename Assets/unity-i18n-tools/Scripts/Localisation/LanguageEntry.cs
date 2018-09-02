using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class LanguageEntry  
{
	[SerializeField] private SystemLanguage language;
	[SerializeField] private TextAsset translationCSVFile;
	
	[SerializeField] private Font customFont;
	[SerializeField] private TMP_FontAsset customTextMeshFont;

	private Dictionary<string, string> translationDict;

	public void initialise()
	{
		if (translationCSVFile != null)
		{
			translationDict = CSVUtils.parseLocalisationFile(translationCSVFile.text);
		}
		else
		{
			translationDict = new Dictionary<string, string>();

			Debug.LogError("Missing translation file for " + language);
		}

	}

	public bool hasStringForKey(string key)
	{
		return translationDict.ContainsKey(key);
	}

	public string getStringForKey(string key)
    {
    	string result = "";
    	translationDict.TryGetValue(key, out result);
    	return result;
    }
	
	public SystemLanguage getLanguage()
	{
		return language;
	}

	public Font getCustomFont()
	{
		return customFont;
	}

	public bool hasCustomFont()
	{
		return customFont != null;
	}

	public TMP_FontAsset getCustomTextMeshFont()
	{
		return customTextMeshFont;
	}

	public bool hasCustomTextMeshFont()
	{
		return customTextMeshFont != null;
	}
	
}
