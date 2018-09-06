namespace SimpleUIExample
{
	using UnityEngine;

	public class TextFieldTest : MonoBehaviour 
	{

		private int languageIndex = 0;

		public void onNextButtonPressed()
		{
			if(languageIndex >= LocalisationManager.instance.getLanguagesAmount()-1)
			{
				languageIndex = 0;
			}
			else
			{
				languageIndex++;
			}

			LocalisationManager.instance.setLanguage(languageIndex);
		}

		public void onPreviousButtonPressed()
		{
			if(languageIndex <= 0)
			{
				languageIndex = LocalisationManager.instance.getLanguagesAmount()-1;
			}
			else
			{
				languageIndex--;
			}

			LocalisationManager.instance.setLanguage(languageIndex);
		}
	}
}