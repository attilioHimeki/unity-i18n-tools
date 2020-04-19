using UnityEditor;
using UnityEditor.Callbacks;

#if UNITY_IOS
using UnityEditor.iOS.Xcode;
using System.IO;
#endif

namespace Himeki.i18n
{
    public static class LocalisationBuildPostProcess
    {
        /// <summary>
        /// Populates CFBundleLocalizations with languages that you intend to support on iTunes Connect
        /// </summary>
        [PostProcessBuild]
        static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
        {
            if (target == BuildTarget.iOS)
            {
#if UNITY_IOS
                string[] languagesSetupGuiIDs = AssetDatabase.FindAssets("t:LanguagesSetup");
                if (languagesSetupGuiIDs.Length < 1)
                {
                    UnityEngine.Debug.LogWarning("No Language Setup asset found, skipping populating CFBundleLocalizations");
                }
                else if (languagesSetupGuiIDs.Length > 1)
                {
                    UnityEngine.Debug.LogWarning("More than one Language Setup asset found in the project. Make sure only one is present in your Assets folder. Skipping populating CFBundleLocalizations");
                }
                else
                {
                    var path = AssetDatabase.GUIDToAssetPath(languagesSetupGuiIDs[0]);
                    LanguagesSetup languagesSetup = (LanguagesSetup)AssetDatabase.LoadAssetAtPath(path, typeof(LanguagesSetup));
                    var supportedLanguages = languagesSetup.getSupportedLanguages();

                    UnityEngine.Debug.LogFormat("Populating CFBundleLocalizations with Language Setup asset found at: {0}", path);

                    // Adding supported languages to CFBundleLocalizations in the XCode project
                    if (supportedLanguages.Length > 0)
                    {
                        var pListPath = Path.Combine(pathToBuiltProject, "Info.plist");
                        var pList = new PlistDocument();
                        pList.ReadFromFile(pListPath);
                        var root = pList.root;

                        PlistElementArray languages = root.CreateArray("CFBundleLocalizations");
                        foreach (var l in supportedLanguages)
                        {
                            var isoCode = LanguageUtils.getISOCodeFromLanguage(l);
                            languages.AddString(isoCode);
                        }
                        
                        pList.WriteToFile(pListPath);
                    }
                    else
                    {
                        UnityEngine.Debug.LogWarning("No languages found in current Languages Setup asset, skipping populating CFBundleLocalizations");
                    }
                }
#endif
            }
        }

    }

}