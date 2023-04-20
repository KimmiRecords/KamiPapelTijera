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

    [SerializeField]
    protected string tooltipTextToShow;

    private void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerPressedE, Interact); //los triggers siempre estan atentos a que el player aprete E
    }

    protected virtual void OnTriggerEnter(Collider other) //cuando el player entra, se dispara el behaviour de entrar
    {
        if (other.gameObject == requiredGameObject)
        {
            OnEnterBehaviour();
        }
    }

    protected virtual void OnTriggerExit(Collider other)//cuando el player sale, se dispara el behaviour de salir
    {
        if (other.gameObject == requiredGameObject)
        {
            OnExitBehaviour();
        }
    }

    public virtual void OnEnterBehaviour()
    {
        triggerBool = true;
        //print("entro el player");
        TooltipManager.instance.ShowTooltip(tooltipTextToShow);
    }

    public virtual void OnExitBehaviour()
    {
        triggerBool = false;
        print("se salio el player de " + gameObject.name);
        TooltipManager.instance.HideTooltip();
    }

    public virtual void Interact(params object[] parameter)
    {
        //print("trigger script interact");
    }

    protected void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, Interact);
        }
    }
}