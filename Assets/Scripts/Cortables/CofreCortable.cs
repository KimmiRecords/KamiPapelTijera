using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreCortable : MonoBehaviour/*, ICortable*/
{
    //los cofres son un tipo de cortable que dispara animacion de abrirse cuando le cortas el candado
    //lo usamos para puertas tambien

    //el trucazo: no es un cortable per se. pero bueno, quedó

    [SerializeField]
    int paperReward = 5;
    [SerializeField]
    float initialDelay = 1;
    //[SerializeField]
    //float delayUntilDeath = 1;
    [SerializeField]
    Animator anim; //mi animator
    bool isOpening;

    //bool wasCut = false;

    //public void GetCut(float dmg)
    //{
    //    if (!wasCut)
    //    {
    //        //print("cortaste el cofre. ganaste 15 pesos");
    //        wasCut = true;
    //    }
    //}

    public void OpenChest() //este metodo lo dispara mi candado
    {
        StartCoroutine(StartOpenSequence());
    }

    public IEnumerator StartOpenSequence()
    {
        yield return new WaitForSeconds(initialDelay);
        anim.SetBool("isOpen", true);
        isOpening = true;

        while (isOpening) //el final de la animacion dispara un metodo que lo hace false
        {
            yield return new WaitForEndOfFrame();
        }

        //particles.gameObject.SetActive(true);
        LevelManager.instance.AddResource(ResourceType.papel, paperReward);
        AudioManager.instance.PlayByName("MagicSuccess", 1.5f);
        //yield return new WaitForSeconds(delayUntilDeath);
        //Destroy(gameObject);

    }

    public void EndOpeningAnimation()
    {
        isOpening = false;
    }
}
