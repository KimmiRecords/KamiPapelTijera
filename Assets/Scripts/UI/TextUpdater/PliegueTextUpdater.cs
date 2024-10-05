using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

public class PliegueTextUpdater : TextUpdater
{
    protected override void UpdateText(params object[] parameter)
    {
        string secondPart = "";

        if (parameter[0] is int foldActual && parameter[1] is int foldsTotales)
        {
            secondPart = foldActual.ToString() + "/" + foldsTotales.ToString();
        }

        StartCoroutine(SetLocalizedText(textoInicial, myText, secondPart));
    }

    private IEnumerator SetLocalizedText(string fallbackText, TMPro.TextMeshProUGUI textElement, string secondPart)
    {
        // Primero asignamos el texto por defecto
        //textElement.text = fallbackText;

        if (!string.IsNullOrEmpty(fallbackText))
        {
            // Obtenemos la tabla de localización
            var tableOperation = LocalizationSettings.StringDatabase.GetTableAsync("UITexts");
            yield return tableOperation;

            StringTable stringTable = tableOperation.Result;
            if (stringTable != null)
            {
                // Verificamos si la clave existe en la tabla
                var entry = stringTable.GetEntry(fallbackText);
                if (entry != null && !string.IsNullOrEmpty(entry.GetLocalizedString()))
                {
                    textElement.text = entry.GetLocalizedString() + secondPart;
                }
                else
                {
                    textElement.text = fallbackText;
                }
            }
        }
        else
        {
            textElement.text = fallbackText;
        }

    }
}