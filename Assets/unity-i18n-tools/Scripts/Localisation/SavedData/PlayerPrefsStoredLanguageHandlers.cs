
using System;
using UnityEngine;

namespace Himeki.i18n
{
    public static class PlayerPrefsStoredLanguageHandlers
    {

        private const string PLAYER_PREFS_LANG_ID = "currentLang";

        public static string getLanguageFromPlayerPrefs()
        {
            if (PlayerPrefs.HasKey(PLAYER_PREFS_LANG_ID))
            {
                return PlayerPrefs.GetString(PLAYER_PREFS_LANG_ID);
            }

            return String.Empty;
        }

        public static void saveLanguageOnPlayerPrefs(string langIsoCode)
        {
            PlayerPrefs.SetString(PLAYER_PREFS_LANG_ID, langIsoCode);
        }
    }
}