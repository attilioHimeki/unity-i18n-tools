using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Text))]
public class TextFieldLocalisator : MonoBehaviour 
{

	[SerializeField] private string textKey;
	[SerializeField] private Font overrideFont;

	private Text textField;

	private void onLanguageChanged()
	{
		refresh();
	}

	void OnEnable () 
	{
		textField = GetComponent<Text>();
		
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
			
			textField.text = s;
		}
	}

	public void refreshFont()
	{
		if(overrideFont != null)
		{
			textField.font = overrideFont;
		}
		else
		{
			var currentFont = LocalisationManager.instance.getFontPerCurrentLanguage();
			
			if(currentFont != null)
				textField.font = currentFont;	
		}
	}

	

}
