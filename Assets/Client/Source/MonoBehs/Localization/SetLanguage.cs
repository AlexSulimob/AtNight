using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleLocalization;
using Yarn.Unity;
using Zenject;
public class SetLanguage : MonoBehaviour
{
    [Inject] DialogueService service;
    public void Language(string language)
    {
        LocalizationManager.Language = language;
        PlayerPrefs.SetString("language", language);
    }

    public void LanguageYarn(string langCode)
    {
        service.lineProvider.textLanguageCode = langCode;
        PlayerPrefs.SetString("languageYarn", langCode);
    }
}
