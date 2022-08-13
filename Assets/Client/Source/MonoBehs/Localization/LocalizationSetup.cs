using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.SimpleLocalization;
using Zenject;
using Yarn.Unity;

public class LocalizationSetup : MonoBehaviour
{
    [Inject] DialogueService service;
    // [Inject] DialogService service;
    private void Awake() {
        LocalizationManager.Read();
        if(PlayerPrefs.HasKey("language"))
        {
            LocalizationManager.Language = PlayerPrefs.GetString("language");
            service.lineProvider.textLanguageCode = PlayerPrefs.GetString("languageYarn");
            // service.lineProvider.textLanguageCode = "ru-RU"; 
        }
        else
        {
            PlayerPrefs.SetString("language", "English");
            PlayerPrefs.SetString("languageYarn", "ru-RU");
            LocalizationManager.Language = PlayerPrefs.GetString("language");
            service.lineProvider.textLanguageCode = PlayerPrefs.GetString("languageYarn");
        }
    }
}
