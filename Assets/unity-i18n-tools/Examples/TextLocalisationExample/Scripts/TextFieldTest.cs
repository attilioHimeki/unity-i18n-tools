
using UnityEngine;
using Himeki.i18n;

public class TextFieldTest : MonoBehaviour
{

	private int languageIndex = 0;

	public void onNextButtonPressed()
	{
		languageIndex++;
		if (languageIndex > LocalisationManager.instance.getLanguagesAmount() - 1)
		{
			languageIndex = 0;
		}

		LocalisationManager.instance.setLanguage(languageIndex);
	}

	public void onPreviousButtonPressed()
	{
		languageIndex--;
		if (languageIndex < 0)
		{
			languageIndex = LocalisationManager.instance.getLanguagesAmount() - 1;
		}

		LocalisationManager.instance.setLanguage(languageIndex);
	}
}