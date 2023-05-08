using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class TriggerScript : MonoBehaviour
{
    //cuando me entran, pongo true
    //cuando se salen, pongo false
    //casi todo lo q sea trigger q responda al player va a heredar de esto

    //este script se lo pones a un area o zona, por ejemplo.
    //y despues alguien pregunta por ella y su triggerbool

    //el player es la layer 3

    [HideInInspector]
    public bool triggerBool = false;

    [SerializeField]
    protected string tooltipTextToShow;

    [SerializeField]
    PostItColor postItColor;

    protected virtual void Start()
    {
        //print("me suscribo a onplayerpressed E - triggerscript " + gameObject.name);
        EventManager.Subscribe(Evento.OnPlayerPressedE, Interact); //los triggers siempre estan atentos a que el player aprete E
    }

    protected virtual void OnTriggerEnter(Collider other) //cuando el player entra, se dispara el behaviour de entrar
    {
        if (other.gameObject.layer == 3) //layer 3 es el player
        {
            OnEnterBehaviour(other);
        }
    }

    protected virtual void OnTriggerExit(Collider other)//cuando el player sale, se dispara el behaviour de salir
    {
        if (other.gameObject.layer == 3)
        {
            OnExitBehaviour();
        }
    }

    public virtual void OnEnterBehaviour(Collider other)
    {
        //print("entro el player");
        triggerBool = true;
        TooltipManager.instance.ShowTooltip(tooltipTextToShow, postItColor);
    }

    public virtual void OnExitBehaviour()
    {
        //print("se salio el player de " + gameObject.name);
        triggerBool = false;
        TooltipManager.instance.HideTooltip();
    }

    public virtual void Interact(params object[] parameter)
    {
        //print("trigger script interact");
    }

    protected virtual void OnDestroy()
    {
        //TooltipManager.instance.HideTooltip(postItColor);

        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, Interact);
        }
    }
}