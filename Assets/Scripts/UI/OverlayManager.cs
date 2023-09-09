using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayManager : MonoBehaviour
{
    [SerializeField] Overlay _defeatOverlay, _victoryOverlay, _mainQuestOverlay;

    bool _isLocked;

    [SerializeField] DialogueSO victoryTriggeringDialogue, mainQuestTriggeringDialogue;

    void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerDie, ShowDefeatOverlay);
        EventManager.Subscribe(Evento.OnDialogueEnd, ShowOverlay);
        EventManager.Subscribe(Evento.OnPlayerPressedE, Unlock);
    }

    public void ShowDefeatOverlay(params object[] parameter)
    {
        _defeatOverlay.gameObject.SetActive(true);
        Lock();
    }

    public void ShowOverlay(params object[] parameter)
    {
        //por ahora muestra el victory o el mainquest

        if ((DialogueSO)parameter[1] == victoryTriggeringDialogue)
        {
            _victoryOverlay.gameObject.SetActive(true);
            Lock();
        }

        if ((DialogueSO)parameter[1] == mainQuestTriggeringDialogue)
        {
            _mainQuestOverlay.gameObject.SetActive(true);
            Lock();
        }
    }


    public void Lock(params object[] parameter)
    {
        LevelManager.Instance.inDialogue = true;
        _isLocked = true;
    }

    public void Unlock(params object[] parameter)
    {
        if (_isLocked)
        {
            LevelManager.Instance.inDialogue = false;
            _isLocked = false;
            AudioManager.instance.PlayByName("PickupSFX", 2.5f);
        }

        _defeatOverlay.gameObject.SetActive(false);
        _victoryOverlay.gameObject.SetActive(false);
        _mainQuestOverlay.gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerDie, ShowDefeatOverlay);
            EventManager.Unsubscribe(Evento.OnDialogueEnd, ShowOverlay);
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, Unlock);
        }
    }
}
