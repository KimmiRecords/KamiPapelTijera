using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepresaManager : MonoBehaviour
{
    //este script se entera cuando son cortadas las represas
    //disparo el gameobject activator cuando todas las represas fueron cortadas

    [SerializeField] RepresaCortable[] represasCortables;
    [SerializeField] List<GameObject> _toActivate, _toDeactivate;
    [SerializeField] GameObject particulasSplash;
    int represasCortadas = 0;

    void Start()
    {
        EventManager.Subscribe(Evento.OnRepresaWasCut, OnRepresaWasCut);
    }

    void OnRepresaWasCut(params object[] parameter)
    {
        represasCortadas++;
        if (represasCortadas >= represasCortables.Length)
        {
            AudioManager.instance.PlayByName("BigWaterSplash", 0.6f);
            AudioManager.instance.PlayByName("MagicSuccess", 0.9f);
            particulasSplash.SetActive(true);
            LevelManager.Instance.GameObjectActivator(_toActivate, _toDeactivate);
        }
    }

    void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnRepresaWasCut, OnRepresaWasCut);
        }
    }
}
