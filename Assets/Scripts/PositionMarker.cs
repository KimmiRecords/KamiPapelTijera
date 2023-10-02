using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMarker : MonoBehaviour
{
    // este script se lo adjuntas al positionmarker
    //se mueve en Z para imitar la posicion en Z del player
    //por ahora, el PageScrollerManager se encarga de dispararle los metodos

    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] float powerFactor = 32;

    float distanceToPlayer;
    float desiredAlpha;

    private void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerChangePage, OnChangePage);
    }

    public void ShowMarker()
    {
        _spriteRenderer.enabled = true;
    }

    public void HideMarker()
    {
        _spriteRenderer.enabled = false;
    }

    public void SetMarkerPosition(Vector3 playerPos)
    {
        //muevo al marker
        transform.position = new Vector3(transform.position.x, transform.position.y, playerPos.z);

        //uso la distance to player para calcular el alpha
        distanceToPlayer = Vector3.Distance(transform.position, playerPos);
        desiredAlpha = powerFactor / (distanceToPlayer * distanceToPlayer);
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, desiredAlpha);
    }

    public void OnChangePage(params object[] parameters)
    {
        HideMarker();
    }
}
