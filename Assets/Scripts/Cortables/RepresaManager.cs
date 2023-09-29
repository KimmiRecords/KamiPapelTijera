using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepresaManager : MonoBehaviour
{
    //este script se entera cuando son cortadas las represas
    //disparo el gameobject activator cuando todas las represas fueron cortadas

    [SerializeField] List<GameObject> troncos, represasCortables;
    [SerializeField] GameObject particulasSplash;
    int represasCortadas = 0;

    [SerializeField] GameObject rioVertical, rioAbajo;
    [SerializeField] float delayEntreRios = 1f;

    void Start()
    {
        EventManager.Subscribe(Evento.OnRepresaWasCut, OnRepresaWasCut);
    }

    void OnRepresaWasCut(params object[] parameter)
    {
        represasCortadas++;
        if (represasCortadas >= represasCortables.Count)
        {
            AudioManager.instance.PlayByName("BigWaterSplash", 0.6f);
            AudioManager.instance.PlayByName("MagicSuccess", 0.9f);
            particulasSplash.SetActive(true);
            StartCoroutine(ActivarRiosCoroutine());
        }
    }

    IEnumerator ActivarRiosCoroutine()
    {
        //desaparece la represa y quedan solo los troncos
        LevelManager.Instance.GameObjectActivator(troncos, represasCortables);

        //aparecen los rios en orden
        rioVertical.SetActive(true);
        yield return new WaitForSeconds(delayEntreRios);
        rioAbajo.SetActive(true);
    }

    void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnRepresaWasCut, OnRepresaWasCut);
        }
    }
}