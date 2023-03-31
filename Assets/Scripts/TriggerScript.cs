using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class TriggerScript : MonoBehaviour
{
    //cuando me entran, pongo true
    //cuando se salen, pongo false
    //casi todo lo q sea trigger q responda al player va a heredar de esto

    //este script se lo pones a un area o zona, por ejemplo. y despues alguien pregunta por ella y su triggerbool
    //por ahora pide un gameobject con quien ser triggereado, y ese es normalmente el player. en el futuro voy a hacer que pregunte por cierto o ciertos layers

    [SerializeField]
    protected GameObject requiredGameObject;

    [HideInInspector]
    public bool triggerBool = false;


    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == requiredGameObject)
        {
            triggerBool = true;
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject == requiredGameObject)
        {
            triggerBool = false;
        }
    }
}