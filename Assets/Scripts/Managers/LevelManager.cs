using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ResourceType
{
    hongos,
    flores,
    papel, //las hojas por ahora las cuenta el player. lo tengo que cambiar
    Count 
}


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public bool agency;
    public bool inDialogue;

    //el dictionario capo con cada tipo de recurso y valor
    public Dictionary<ResourceType, int> recursosRecolectados = new Dictionary<ResourceType, int>();

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        for (int i = 0; i < (int)ResourceType.Count; i++) //creo el dict con uno de cada pickuptype y 0
        {
            recursosRecolectados.Add((ResourceType)i, 0);
            //print( ((ResourceType)i).ToString() + " // " + recursosRecolectados[(ResourceType)i].ToString());
        }

    }

    public void GoToScene(string sceneName)
    {   
        SceneManager.LoadScene(sceneName);
    }

    public void AddResource(ResourceType pickupType, int valueToAdd)
    {
        //agrega la cantidad valuetoadd al total. si quiero restar, valuetoadd deberia ser negativo
        recursosRecolectados[pickupType] += valueToAdd;
        EventManager.Trigger(Evento.OnPlayerResourceUpdated, pickupType, recursosRecolectados[pickupType]);
        print(pickupType.ToString() + " // " + recursosRecolectados[pickupType]);
    }
}
