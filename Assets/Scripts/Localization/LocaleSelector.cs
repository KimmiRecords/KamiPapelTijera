using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    bool _active = false;

   
    private void Start()
    {
        StartCoroutine(SetLocale(0));
    }
    public void BUTTON_ChangeLocale(int localeId)
    {
        if (_active)
            return;
        StartCoroutine(SetLocale(localeId));
    }

    IEnumerator SetLocale(int localeId)
    {
        _active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeId];
        _active = false;
    }
}
