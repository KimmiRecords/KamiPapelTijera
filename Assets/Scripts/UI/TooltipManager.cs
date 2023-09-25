using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum PostItColor
{
    Azul,
    Naranja,
    Rosa,
    Amarillo,
    Verde
}

public class TooltipManager : Singleton<TooltipManager>
{
    //este script escribe el texto en los postits y los prende y apaga

    [SerializeField] int killTime = 10;
    [SerializeField] int azulKillTime, naranjaKillTime, rosaKillTime, amarilloKillTime, verdeKillTime;
    [SerializeField] PostIt[] postIts;

    float killAllPostitsTimer;

    public void ShowTooltip(string text, PostItColor postIt) 
    {
        //print("show tooltip");
        postIts[(int)postIt].gameObject.SetActive(true); //prendo el postit. esto se reemplazara por una animacion
        postIts[(int)postIt].tmPro.text = text; //le cambio el texto

        killAllPostitsTimer = 0; //reseteo el timer y arranco la corru
        StartCoroutine(KillAllPostItsCoroutine());
    }

    public void HideTooltip()  
    {
        //print("hide tooltip");
        for (int i = 0; i < postIts.Length; i++) //apago todas de una
        {
            postIts[i].gameObject.SetActive(false);
            postIts[i].tmPro.text = "";
        }
    }

    public IEnumerator KillAllPostItsCoroutine()
    {
        //print("[TooltipManager] arranca la corrutina killallpostits");

        while (killAllPostitsTimer < killTime) //cuando el timer llegue a 10, saldre del while 
        {
            //print("aumento el timer");
            killAllPostitsTimer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        HideTooltip(); //apago todas
    }
}
