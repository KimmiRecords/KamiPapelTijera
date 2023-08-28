using UnityEngine;
using UnityEngine.EventSystems;

public class HoverDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    //esto se lo adjuntas a una ImageUI
    bool isHover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        EventManager.Trigger(Evento.OnMouseEnterFlap);
        isHover = true;
        //Debug.Log("enter flap");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EventManager.Trigger(Evento.OnMouseExitFlap);
        isHover = false;    
        //Debug.Log("exit flap");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isHover)
        {
            FlapManager.Instance.ToggleFlap();
        }
    }
}
