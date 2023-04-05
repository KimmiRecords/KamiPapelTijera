using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    //los updaters de cosas de la ui agarran la info usando eventos
    TextMeshProUGUI myText;

    [SerializeField]
    string textoInicial = "Número de página: ";

    void Start()
    {
        myText = GetComponent<TextMeshProUGUI>();
        EventManager.Subscribe(Evento.OnPlayerChangePage, UpdateText); //ves? me suscribo al evento onplayerchangepage, asi cuando den el aviso, yo disparo el metodo UpdateText
    }

    void UpdateText(params object[] parameter)
    {
        if (parameter[0] is int)
        {
            myText.text = textoInicial + (int)parameter[0]; //tuki, escribe "numero de pagina = x"
        }
    }
}
