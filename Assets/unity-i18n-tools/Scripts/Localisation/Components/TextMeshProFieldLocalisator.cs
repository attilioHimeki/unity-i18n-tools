using UnityEngine;
using System.Collections;
using TMPro;

[DisallowMultipleComponent]
[RequireComponent(typeof(TextMeshProUGUI))]
public class TextMeshProFieldLocalisator : MonoBehaviour 
{

	[SerializeField] private string textKey;
	[SerializeField] private TMP_FontAsset overrideFont;

	private TextMeshProUGUI meshTextField;

	private void onLanguageChanged()
	{
		refresh();
	}

	void OnEnable () 
	{
		meshTextField = GetComponent<TextMeshProUGUI>();
		LocalisationManager.instance.OnLanguageChanged += onLanguageChanged;
		
		refreshText();
	}

	void OnDisable()
	{
		LocalisationManager.instance.OnLanguageChanged -= onLanguageChanged;
	}

	void OnDestroy()
	{
		LocalisationManager.instance.OnLanguageChanged -= onLanguageChanged;
	}

	public void refresh()
	{
		refreshText();
		refreshFont();
	}

	public void refreshText()
	{
		if(!string.IsNullOrEmpty(textKey))
		{
			var s = LocalisationManager.instance.getStringForKey(textKey);
			meshTextField.text = s;
		}
	}

	public void refreshFont()
	{
		if(overrideFont != null)
		{
			meshTextField.font = overrideFont;
		}
		else
		{
			var currentFont = LocalisationManager.instance.getTextMeshFontPerCurrentLanguage();

			if(currentFont != null)
				meshTextField.font = currentFont;	
		}
	}

}
