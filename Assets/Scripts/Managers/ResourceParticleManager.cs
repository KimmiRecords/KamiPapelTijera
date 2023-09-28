using System.Collections;
using UnityEngine;

public class ResourceParticleManager : Singleton<ResourceParticleManager>
{
    [SerializeField] float duration = 1f;
    [SerializeField] float offset;
    public ParticleSystem glitterParticles;
    public InventorySlot sticker;

    public Canvas canvas;

    private void Start()
    {
        EventManager.Subscribe(Evento.OnObjectWasCut, PrepareSystem);
        EventManager.Subscribe(Evento.OnResourceUpdated, StartSystem);
    }

    #region prepare system
    public void PrepareSystem(params object[] parameter)
    {
        Debug.Log("prepare system");
        Vector3 position = (Vector3)parameter[0];
        SetParticlePosition(position);
        SetStickerPosition(position);
    }

    public void SetParticlePosition(Vector3 pos)
    {
        //Debug.Log("set particle position");
        glitterParticles.transform.position = pos;
        glitterParticles.gameObject.SetActive(false);
    }

    public void SetStickerPosition(Vector3 position)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(position);
        float canvasScaleFactor = canvas.scaleFactor;
        Vector3 canvasPosition = new Vector3(screenPosition.x / canvasScaleFactor, screenPosition.y / canvasScaleFactor, 0f);

        sticker.gameObject.transform.position = canvasPosition + (Vector3.up + Vector3.right * offset);
    }
    #endregion

    #region start system

    public void StartSystem(params object[] parameter)
    {
        Debug.Log("start system");
        ResourceType rt = (ResourceType)parameter[0];

        if ((bool)parameter[2] &&
            (rt == ResourceType.papel || rt == ResourceType.flores ||
            rt == ResourceType.hongos))
        {
            ActivateSystem(rt);
        }
    }

    public void ActivateSystem(ResourceType rt)
    {
        Debug.Log("activate system");
        ShowParticles();
        ShowSticker(rt);
        StartCoroutine(HideParticles());
        StartCoroutine(HideSticker());
    }

    public void ShowParticles()
    {
        glitterParticles.gameObject.SetActive(true);
    }

    public void ShowSticker(ResourceType rt)
    {
        Debug.Log("muestro sticker");
        sticker.gameObject.SetActive(true);
        sticker.SetItem(InventoryManager.Instance.itemsByResourceType[rt]);

        //lerp de alpha o algo asi
    }
    #endregion

    #region turn off system

    public IEnumerator HideParticles()
    {
        yield return new WaitForSeconds(duration);
        glitterParticles.gameObject.SetActive(false);
    }

    public IEnumerator HideSticker()
    {
        yield return new WaitForSeconds(duration);
        Debug.Log("hide sticker");
        sticker.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnObjectWasCut, PrepareSystem);
            EventManager.Unsubscribe(Evento.OnResourceUpdated, StartSystem);
        }
    }
    #endregion
}
