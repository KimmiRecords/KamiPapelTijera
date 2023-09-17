using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ResourceType
{
    hongos,
    flores,
    papel,
    Count 
}

//por ahi los resourcetype deberian estar en el resourcemanager
//que deberia estar conectado con el inventorymanager

public class LevelManager : Singleton<LevelManager>
{
    public bool agency;
    public bool inDialogue;

    //el dictionario capo con cada tipo de recurso y valor
    public Dictionary<ResourceType, int> recursosRecolectados = new Dictionary<ResourceType, int>();

    public int initialPaper;
    public int initialHongos;
    public int initialFloresAzules;
    public Player player;

    protected override void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        for (int i = 0; i < (int)ResourceType.Count; i++) //creo el dict con uno de cada pickuptype y 0
        {
            recursosRecolectados.Add((ResourceType)i, 0);
            //print( ((ResourceType)i).ToString() + " // " + recursosRecolectados[(ResourceType)i].ToString());
        }

        recursosRecolectados[ResourceType.papel] = initialPaper;
        recursosRecolectados[ResourceType.hongos] = initialHongos;
        recursosRecolectados[ResourceType.flores] = initialFloresAzules;
    }

    public void GiveSprintBoots()
    {
        //Debug.Log("el player se gano las botas sprint x haber completado la quest");
        player.hasSprintBoots = true;
    }
    public void GiveWaterBoots()
    {
        //Debug.Log("el player se gano las botas water x haber completado la quest");
        player.hasWaterBoots = true;
    }
    public void GiveTijeraMejorada()
    {
        //Debug.Log("el player se gano la tijera mejorada x haber completado la quest");
        player.GetTijeraMejorada();
    }
    public void GoToScene(string sceneName)
    {   
        SceneManager.LoadScene(sceneName);
    }
    public void Update()
    {
        //CHEAT CODES
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddResource(ResourceType.hongos, 100);
            AddResource(ResourceType.papel, 100);
            AddResource(ResourceType.flores, 100);
            GiveWaterBoots();
            GiveSprintBoots();
            GiveTijeraMejorada();
        }
    }
    public void AddResource(ResourceType pickupType, int valueToAdd)
    {
        //agrega la cantidad valuetoadd al total. si quiero restar, valuetoadd deberia ser negativo
        recursosRecolectados[pickupType] += valueToAdd;
        EventManager.Trigger(Evento.OnResourceUpdated, pickupType, recursosRecolectados[pickupType]);
        //print(pickupType.ToString() + " // " + recursosRecolectados[pickupType]);
    }
    public void AddHealth(int curacion)
    {
        player.GetCured(curacion);
    }

    
}
