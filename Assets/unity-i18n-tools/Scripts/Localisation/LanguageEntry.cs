using UnityEngine;
using System.Collections.Generic;
using TMPro;

namespace Himeki.i18n
{

    [System.Serializable]
    public class LanguageEntry
    {
        [Tooltip("The related language name.")]
        [SerializeField] private SystemLanguage language;

        [Tooltip("The related translation CSV file.")]
        [SerializeField] private TextAsset translationCSVFile;

        [Tooltip("Optional custom Font to replace the default font in the manager.")]
        [SerializeField] private Font customFont;

        [Tooltip("Optional TextMeshPro custom Font to replace the default font in the manager.")]
        [SerializeField] private TMP_FontAsset customTextMeshFont;

        private Dictionary<string, string> translationDict;

        public void initialise()
        {
            if (translationCSVFile != null)
            {
                translationDict = CSVParser.parseLocalisationFile(translationCSVFile.text);
            }
            else
            {
                translationDict = new Dictionary<string, string>();

                Debug.LogErrorFormat("Missing translation file for {0} ", language);
            }

        }

        public bool hasStringForKey(string key)
        {
            return translationDict.ContainsKey(key);
        }

        public string getStringForKey(string key)
        {
            string result;
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

}