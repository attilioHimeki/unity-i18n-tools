using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageUtils 
{
	private const string ISO_EN = "EN";
	private const string ISO_AF = "AF";
	private const string ISO_AR = "AR";
	private const string ISO_EU = "EU";
	private const string ISO_BY = "BY";
	private const string ISO_BG = "BG";
	private const string ISO_CA = "CA";
	private const string ISO_ZH = "ZH";
	private const string ISO_ZH_SI = "ZH-Hans";
	private const string ISO_ZH_TR = "ZH-Hant";
	private const string ISO_CS = "CS";
	private const string ISO_DA = "DA";
	private const string ISO_NL = "NL";
	private const string ISO_ET = "ET";
	private const string ISO_FO = "FO";
	private const string ISO_FI = "FI";
	private const string ISO_FR = "FR";
	private const string ISO_DE = "DE";
	private const string ISO_EL = "EL";
	private const string ISO_IW = "IW";
	private const string ISO_HU = "HU";
	private const string ISO_IS = "IS";
	private const string ISO_IN = "IN";
	private const string ISO_IT = "IT";
	private const string ISO_JA = "JA";
	private const string ISO_KO = "KO";
	private const string ISO_LV = "LV";
	private const string ISO_LT = "LT";
	private const string ISO_NO = "NO";
	private const string ISO_PL = "PL";
	private const string ISO_PT = "PT";
	private const string ISO_RO = "RO";
	private const string ISO_RU = "RU";
	private const string ISO_SH = "SH";
	private const string ISO_SK = "SK";
	private const string ISO_SL = "SL";
	private const string ISO_ES = "ES";
	private const string ISO_SV = "SV";
	private const string ISO_TH = "TH";
	private const string ISO_TR = "TR";
	private const string ISO_UK = "UK";
	private const string ISO_VI = "VI";

	public static string getISOCodeFromLanguage(SystemLanguage lang)
	{
		switch (lang) 
		{
			case SystemLanguage.Afrikaans: return ISO_AF;
			case SystemLanguage.Arabic: return ISO_AR;
			case SystemLanguage.Basque: return ISO_EU;
			case SystemLanguage.Belarusian: return ISO_BY;
			case SystemLanguage.Bulgarian: return ISO_BG;
			case SystemLanguage.Catalan: return ISO_CA;
			case SystemLanguage.Chinese: return ISO_ZH;
			case SystemLanguage.ChineseSimplified: return ISO_ZH_SI;
			case SystemLanguage.ChineseTraditional: return ISO_ZH_TR;
			case SystemLanguage.Czech: return ISO_CS;
			case SystemLanguage.Danish: return ISO_DA;
			case SystemLanguage.Dutch: return ISO_NL;
			case SystemLanguage.English: return ISO_EN;
			case SystemLanguage.Estonian: return ISO_ET;
			case SystemLanguage.Faroese: return ISO_FO;
			case SystemLanguage.Finnish: return ISO_FI;
			case SystemLanguage.French: return ISO_FR;
			case SystemLanguage.German: return ISO_DE;
			case SystemLanguage.Greek: return ISO_EL;
			case SystemLanguage.Hebrew: return ISO_IW;
			case SystemLanguage.Hungarian: return ISO_HU;
			case SystemLanguage.Icelandic: return ISO_IS;
			case SystemLanguage.Indonesian: return ISO_IN;
			case SystemLanguage.Italian: return ISO_IT;
			case SystemLanguage.Japanese: return ISO_JA;
			case SystemLanguage.Korean: return ISO_KO;
			case SystemLanguage.Latvian: return ISO_LV;
			case SystemLanguage.Lithuanian: return ISO_LT;
			case SystemLanguage.Norwegian: return ISO_NO;
			case SystemLanguage.Polish: return ISO_PL;
			case SystemLanguage.Portuguese: return ISO_PT;
			case SystemLanguage.Romanian: return ISO_RO;
			case SystemLanguage.Russian: return ISO_RU;
			case SystemLanguage.SerboCroatian: return ISO_SH;
			case SystemLanguage.Slovak: return ISO_SK;
			case SystemLanguage.Slovenian: return ISO_SL;
			case SystemLanguage.Spanish: return ISO_ES;
			case SystemLanguage.Swedish: return ISO_SV;
			case SystemLanguage.Thai: return ISO_TH;
			case SystemLanguage.Turkish: return ISO_TR;
			case SystemLanguage.Ukrainian: return ISO_UK;
			case SystemLanguage.Vietnamese: return ISO_VI;
			case SystemLanguage.Unknown:
			default: return ISO_EN;
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
			case ISO_AF: return SystemLanguage.Afrikaans;
			case ISO_AR: return SystemLanguage.Arabic;
			case ISO_EU: return SystemLanguage.Basque;
			case ISO_BY: return SystemLanguage.Belarusian;
			case ISO_BG: return SystemLanguage.Bulgarian;
			case ISO_CA: return SystemLanguage.Catalan;
			case ISO_ZH: return SystemLanguage.Chinese;
			case ISO_ZH_SI: return SystemLanguage.ChineseSimplified;
			case ISO_ZH_TR: return SystemLanguage.ChineseTraditional;
			case ISO_CS: return SystemLanguage.Czech;
			case ISO_DA: return SystemLanguage.Danish;
			case ISO_NL: return SystemLanguage.Dutch;
			case ISO_EN: return SystemLanguage.English;
			case ISO_ET: return SystemLanguage.Estonian;
			case ISO_FO: return SystemLanguage.Faroese;
			case ISO_FI: return SystemLanguage.Finnish;
			case ISO_FR: return SystemLanguage.French;
			case ISO_DE: return SystemLanguage.German;
			case ISO_EL: return SystemLanguage.Greek;
			case ISO_IW: return SystemLanguage.Hebrew;
			case ISO_HU: return SystemLanguage.Hungarian;
			case ISO_IS: return SystemLanguage.Icelandic;
			case ISO_IN: return SystemLanguage.Indonesian;
			case ISO_IT: return SystemLanguage.Italian;
			case ISO_JA: return SystemLanguage.Japanese;
			case ISO_KO: return SystemLanguage.Korean;
			case ISO_LV: return SystemLanguage.Latvian;
			case ISO_LT: return SystemLanguage.Lithuanian;
			case ISO_NO: return SystemLanguage.Norwegian;
			case ISO_PL: return SystemLanguage.Polish;
			case ISO_PT: return SystemLanguage.Portuguese;
			case ISO_RO: return SystemLanguage.Romanian;
			case ISO_RU: return SystemLanguage.Russian;
			case ISO_SH: return SystemLanguage.SerboCroatian;
			case ISO_SK: return SystemLanguage.Slovak;
			case ISO_SL: return SystemLanguage.Slovenian;
			case ISO_ES: return SystemLanguage.Spanish;
			case ISO_SV: return SystemLanguage.Swedish;
			case ISO_TH: return SystemLanguage.Thai;
			case ISO_TR: return SystemLanguage.Turkish;
			case ISO_UK: return SystemLanguage.Ukrainian;
			case ISO_VI: return SystemLanguage.Vietnamese;
			default: return SystemLanguage.English;
		}
	}
}
