using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public enum LocaleId
{
    Spanish = 0,
    English = 1
}
public class LocaleSelector : MonoBehaviour
{
    bool _active = false;
    public bool SetStartingLocale = true;
    public LocaleId StartingLocale = LocaleId.Spanish;


    private void Start()
    {
        if (SetStartingLocale)
        {
            StartCoroutine(SetLocale((int)StartingLocale));
        }
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
