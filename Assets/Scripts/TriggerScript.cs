using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TriggerScript : MonoBehaviour
{
    //cuando me entran, pongo true
    //cuando se salen, pongo false
    //este script se lo pones a un area o zona, por ejemplo. y despues alguien pregunta por ella y su triggerbool
    //por ahora pide un gameobject con quien ser triggereado, y ese es normalmente el player. en el futuro voy a hacer que pregunte por cierto o ciertos layers

    [SerializeField] 
    private GameObject requiredGameObject;
    public bool triggerBool = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == requiredGameObject)
        {
            triggerBool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == requiredGameObject)
        {
            triggerBool = false;
        }
    }
}