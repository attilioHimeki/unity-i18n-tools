# unity-i18n-tools
Tools and Components to localise Unity games and apps.

This library is currently under development, and there may be breaking changes until it's marked as released.

## Quick setup
- Drag the LocalisationManager prefab onto your scene. This is a singleton object, so make sure to have it available when the game starts.
- Setup your LocalisationManager instance adding your languages supported, missing key fallback, default fonts and other options.
- Each language must have a related CSV file assigned. Please check the example files to check the right format.
- In your Canvas UI, attach a TextFieldLocalisator component to your text fields, or a TextMeshProFieldLocalisator component for TextMeshProUGUI, and assign the related string key from the translations file. This will make sure they are updated and refreshed automatically with no extra handling required.
- If needed, strings can also be accessed directly using methods such as getStringForKey.

## Advanced features
- By default, the plugin uses PlayerPrefs to load and save the user language. This behaviour can be overridden using overrideStoredLanguageHandlers and passing your own custom handlers, in case you'd rather use another system such as Cloud saves or a file. In this case, the best way to proceed is to set initialiseOnAwake as false, call overrideStoredLanguageHandlers and then initialise the manager manually.

## Usage and license
While I'm mostly using this for internal development, you're more than welcome to use this in your Unity project, following the conditions and limitations specified in the LICENSE. Also, while not necessary, please make sure to credit me and help spread this library.
