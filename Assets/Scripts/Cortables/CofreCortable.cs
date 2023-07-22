using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreCortable : MonoBehaviour/*, ICortable*/
{
    //los cofres son un tipo de cortable que dispara animacion de abrirse cuando le cortas el candado
    //lo usamos para puertas tambien

    //el trucazo: no es un cortable per se. pero bueno, quedó

    [SerializeField] int paperReward = 5;
    [SerializeField] float initialDelay = 1;
    [SerializeField] Animator anim; //mi animator
    [SerializeField] GameObject particulitasDePapel;
    bool isOpening;

    public void OpenChest() //este metodo lo dispara mi candado
    {
        StartCoroutine(StartOpenSequence());
    }

    public IEnumerator StartOpenSequence()
    {
        yield return new WaitForSeconds(initialDelay);
        anim.SetBool("isOpen", true);
        isOpening = true;
        AudioManager.instance.PlayByName("MagicSuccess", 1.4f);
        //lanzar particulas
        particulitasDePapel.gameObject.SetActive(true);

        while (isOpening) //el final de la animacion dispara un metodo que lo hace false
        {
            yield return new WaitForEndOfFrame();
        }

        //particles.gameObject.SetActive(true);
        LevelManager.instance.AddResource(ResourceType.papel, paperReward);
        //yield return new WaitForSeconds(delayUntilDeath);
        //Destroy(gameObject);

    }

    public void EndOpeningAnimation()
    {
        isOpening = false;
    }
}
