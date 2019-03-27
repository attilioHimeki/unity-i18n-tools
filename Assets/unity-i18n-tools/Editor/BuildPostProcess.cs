using UnityEditor;
using UnityEditor.Callbacks;

#if UNITY_IOS
using UnityEditor.iOS.Xcode;
using System.IO;
#endif

public static class BuildPostProcess
{
    /// <summary>
    /// Add languages that you intend to support on iTunes Connect.
    /// </summary>
	private static readonly string[] supportedLanguages = 
    {
        LanguageIsoCode.EN
        // Replace with your supported languages here
    };


    [PostProcessBuildAttribute]
    static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        if (target == BuildTarget.iOS)
        {
#if UNITY_IOS
            var pListPath = Path.Combine(pathToBuiltProject, "Info.plist");
            var pList = new PlistDocument();
            pList.ReadFromFile(pListPath);

			var root = pList.root;

            // Adding supported languages to XCode project
            if(supportedLanguages.Length > 0)
            {
                PlistElementArray languages = root.CreateArray("CFBundleLocalizations");
                foreach(var l in supportedLanguages) 
                {
                    languages.AddString(l);
                }
            }

            pList.WriteToFile(pListPath);
#endif
        }
    }

}
