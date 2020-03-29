
using UnityEngine;
using Himeki.i18n;
using TMPro;

public class TextFieldTest : MonoBehaviour
{

	public TextMeshProUGUI languageLabel;
	
	private int languageIndex = 0;

	public void onNextButtonPressed()
	{
		languageIndex++;
		if (languageIndex > LocalisationManager.instance.getLanguagesAmount() - 1)
		{
			languageIndex = 0;
		}

		setLanguage(languageIndex);
	}

	public void onPreviousButtonPressed()
	{
		languageIndex--;
		if (languageIndex < 0)
		{
			languageIndex = LocalisationManager.instance.getLanguagesAmount() - 1;
		}

		setLanguage(languageIndex);
	}

	private void setLanguage(int index)
	{
		LocalisationManager.instance.setLanguage(index);

		languageLabel.text = LocalisationManager.instance.getCurrentLanguage().getLanguage().ToString();
	}
}