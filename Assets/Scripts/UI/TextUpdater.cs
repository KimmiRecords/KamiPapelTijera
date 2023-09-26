using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class TextUpdater : MonoBehaviour
{
    //los updaters de cosas de la ui agarran la info usando eventos
    protected TextMeshProUGUI myText;

    [SerializeField] protected Evento eventoQueMeInteresa;

    [SerializeField] protected string textoInicial;

    protected virtual void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
        EventManager.Subscribe(eventoQueMeInteresa, UpdateText);
    }

    protected virtual void UpdateText(params object[] parameter)
    {
        //print("updateo el text");
    }

    protected void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(eventoQueMeInteresa, UpdateText);
        }
    }
}
