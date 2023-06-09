using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ResourceType
{
    hongos,
    flores,
    hojas, //las hojas por ahora las cuenta el player. lo tengo que cambiar
    vida,
    Count 
}


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public bool agency;
    public bool inDialogue;

    Dictionary<ResourceType, int> recursosRecolectados = new Dictionary<ResourceType, int>();

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
            print( ((ResourceType)i).ToString() + " // " + recursosRecolectados[(ResourceType)i].ToString());
        }

    }

    public void GoToScene(string sceneName)
    {   
        SceneManager.LoadScene(sceneName);
    }

    public void AddPickup(ResourceType pickupType, int valueToAdd)
    {
        recursosRecolectados[pickupType] += valueToAdd;
        print(pickupType.ToString() + " // " + recursosRecolectados[pickupType]);

    }
}
