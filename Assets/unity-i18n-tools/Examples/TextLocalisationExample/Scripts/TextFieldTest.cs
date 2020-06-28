
using UnityEngine;
using Himeki.i18n;
using TMPro;

public class TextFieldTest : MonoBehaviour
{

	[SerializeField] private TextMeshProUGUI languageLabel;
	private int languageIndex = 0;

	void OnEnable()
	{
		var currentLanguage = LocalisationManager.instance.getCurrentLanguage().getLanguage();
		languageIndex = LocalisationManager.instance.getLanguageIndex(currentLanguage);

		languageLabel.text = currentLanguage.ToString();
	}

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