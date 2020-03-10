using UnityEngine;

namespace Himeki.i18n
{
    public static class LanguageUtils
    {
        public static string getISOCodeFromLanguage(SystemLanguage lang)
        {
            switch (lang)
            {
                case SystemLanguage.Afrikaans: return LanguageIsoCode.AF;
                case SystemLanguage.Arabic: return LanguageIsoCode.AR;
                case SystemLanguage.Basque: return LanguageIsoCode.EU;
                case SystemLanguage.Belarusian: return LanguageIsoCode.BY;
                case SystemLanguage.Bulgarian: return LanguageIsoCode.BG;
                case SystemLanguage.Catalan: return LanguageIsoCode.CA;
                case SystemLanguage.Chinese: return LanguageIsoCode.ZH;
                case SystemLanguage.ChineseSimplified: return LanguageIsoCode.ZH_SI;
                case SystemLanguage.ChineseTraditional: return LanguageIsoCode.ZH_TR;
                case SystemLanguage.Czech: return LanguageIsoCode.CS;
                case SystemLanguage.Danish: return LanguageIsoCode.DA;
                case SystemLanguage.Dutch: return LanguageIsoCode.NL;
                case SystemLanguage.English: return LanguageIsoCode.EN;
                case SystemLanguage.Estonian: return LanguageIsoCode.ET;
                case SystemLanguage.Faroese: return LanguageIsoCode.FO;
                case SystemLanguage.Finnish: return LanguageIsoCode.FI;
                case SystemLanguage.French: return LanguageIsoCode.FR;
                case SystemLanguage.German: return LanguageIsoCode.DE;
                case SystemLanguage.Greek: return LanguageIsoCode.EL;
                case SystemLanguage.Hebrew: return LanguageIsoCode.IW;
                case SystemLanguage.Hungarian: return LanguageIsoCode.HU;
                case SystemLanguage.Icelandic: return LanguageIsoCode.IS;
                case SystemLanguage.Indonesian: return LanguageIsoCode.IN;
                case SystemLanguage.Italian: return LanguageIsoCode.IT;
                case SystemLanguage.Japanese: return LanguageIsoCode.JA;
                case SystemLanguage.Korean: return LanguageIsoCode.KO;
                case SystemLanguage.Latvian: return LanguageIsoCode.LV;
                case SystemLanguage.Lithuanian: return LanguageIsoCode.LT;
                case SystemLanguage.Norwegian: return LanguageIsoCode.NO;
                case SystemLanguage.Polish: return LanguageIsoCode.PL;
                case SystemLanguage.Portuguese: return LanguageIsoCode.PT;
                case SystemLanguage.Romanian: return LanguageIsoCode.RO;
                case SystemLanguage.Russian: return LanguageIsoCode.RU;
                case SystemLanguage.SerboCroatian: return LanguageIsoCode.SH;
                case SystemLanguage.Slovak: return LanguageIsoCode.SK;
                case SystemLanguage.Slovenian: return LanguageIsoCode.SL;
                case SystemLanguage.Spanish: return LanguageIsoCode.ES;
                case SystemLanguage.Swedish: return LanguageIsoCode.SV;
                case SystemLanguage.Thai: return LanguageIsoCode.TH;
                case SystemLanguage.Turkish: return LanguageIsoCode.TR;
                case SystemLanguage.Ukrainian: return LanguageIsoCode.UK;
                case SystemLanguage.Vietnamese: return LanguageIsoCode.VI;
                case SystemLanguage.Unknown:
                default: return LanguageIsoCode.EN;
            }
        }

        public static string getISOCodeFromSystemLanguage()
        {
            SystemLanguage lang = Application.systemLanguage;
            return getISOCodeFromLanguage(lang);
        }

        public static SystemLanguage getLanguageFromISOCode(string isoLang)
        {
            switch (isoLang)
            {
                case LanguageIsoCode.AF: return SystemLanguage.Afrikaans;
                case LanguageIsoCode.AR: return SystemLanguage.Arabic;
                case LanguageIsoCode.EU: return SystemLanguage.Basque;
                case LanguageIsoCode.BY: return SystemLanguage.Belarusian;
                case LanguageIsoCode.BG: return SystemLanguage.Bulgarian;
                case LanguageIsoCode.CA: return SystemLanguage.Catalan;
                case LanguageIsoCode.ZH: return SystemLanguage.Chinese;
                case LanguageIsoCode.ZH_SI: return SystemLanguage.ChineseSimplified;
                case LanguageIsoCode.ZH_TR: case LanguageIsoCode.ZH_TW: return SystemLanguage.ChineseTraditional;
                case LanguageIsoCode.CS: return SystemLanguage.Czech;
                case LanguageIsoCode.DA: return SystemLanguage.Danish;
                case LanguageIsoCode.NL: return SystemLanguage.Dutch;
                case LanguageIsoCode.EN: return SystemLanguage.English;
                case LanguageIsoCode.ET: return SystemLanguage.Estonian;
                case LanguageIsoCode.FO: return SystemLanguage.Faroese;
                case LanguageIsoCode.FI: return SystemLanguage.Finnish;
                case LanguageIsoCode.FR: return SystemLanguage.French;
                case LanguageIsoCode.DE: return SystemLanguage.German;
                case LanguageIsoCode.EL: return SystemLanguage.Greek;
                case LanguageIsoCode.IW: return SystemLanguage.Hebrew;
                case LanguageIsoCode.HU: return SystemLanguage.Hungarian;
                case LanguageIsoCode.IS: return SystemLanguage.Icelandic;
                case LanguageIsoCode.IN: return SystemLanguage.Indonesian;
                case LanguageIsoCode.IT: return SystemLanguage.Italian;
                case LanguageIsoCode.JA: return SystemLanguage.Japanese;
                case LanguageIsoCode.KO: return SystemLanguage.Korean;
                case LanguageIsoCode.LV: return SystemLanguage.Latvian;
                case LanguageIsoCode.LT: return SystemLanguage.Lithuanian;
                case LanguageIsoCode.NO: return SystemLanguage.Norwegian;
                case LanguageIsoCode.PL: return SystemLanguage.Polish;
                case LanguageIsoCode.PT: case LanguageIsoCode.PT_BR: return SystemLanguage.Portuguese;
                case LanguageIsoCode.RO: return SystemLanguage.Romanian;
                case LanguageIsoCode.RU: return SystemLanguage.Russian;
                case LanguageIsoCode.SH: return SystemLanguage.SerboCroatian;
                case LanguageIsoCode.SK: return SystemLanguage.Slovak;
                case LanguageIsoCode.SL: return SystemLanguage.Slovenian;
                case LanguageIsoCode.ES: case LanguageIsoCode.ES_MX: case LanguageIsoCode.ES_419: return SystemLanguage.Spanish;
                case LanguageIsoCode.SV: return SystemLanguage.Swedish;
                case LanguageIsoCode.TH: return SystemLanguage.Thai;
                case LanguageIsoCode.TR: return SystemLanguage.Turkish;
                case LanguageIsoCode.UK: return SystemLanguage.Ukrainian;
                case LanguageIsoCode.VI: return SystemLanguage.Vietnamese;
                default: return SystemLanguage.English;
            }
        }
    }

}