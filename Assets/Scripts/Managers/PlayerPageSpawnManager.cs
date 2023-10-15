using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPageSpawnManager : Singleton<PlayerPageSpawnManager>
{
    //decime a que pagina pasaste, y yo te dire donde deberia spawnear el player.
    //tambien usan este script cuando el pj muere y debe respawnear

    //isNext es true cuando estoy pasando a la SIGUIENTE pagina.
    //isNext seria como lo opuesto a isPrev.

    [SerializeField] Player _player;
    CharacterController _playerCC;
    float pageEntryX = -135;
    float pageExitX = 135;
    Vector3 lastUsedSpawn; //para recordar el ultimo usado para cuando el player muera

    void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerChangePage, PlacePlayer);
        _playerCC = _player.GetComponent<CharacterController>();
        lastUsedSpawn = _player.transform.position; //en principio, tu ultimo spawn es donde arranca el juego
    }
    public void PlacePlayer(params object[] parameter)
    {
        Debug.Log("place player");
        PositionPlayerAtPoint(GetProjectedPositionInNewPage(_player.transform.position, (bool)parameter[1]));
        SavePosition(_player.transform.position);
    }
    public void RespawnPlayer(params object[] parameter)
    {
        //Debug.Log("respawn player");
        PositionPlayerAtPoint(lastUsedSpawn);
    }
    public void PositionPlayerAtPoint(Vector3 point)
    {
        //Debug.Log("PositionPlayerAtPoint");
        _playerCC.enabled = false;
        _player.transform.position = point;
        _playerCC.enabled = true;
        EventManager.Trigger(Evento.OnPlayerPlaced);
    }
    public Vector3 GetProjectedPositionInNewPage(Vector3 playerCurrentPosition, bool isNext)
    {
        float desiredX;
        Vector3 newPosition;

        if (isNext)
        {
            desiredX = pageEntryX;
        }
        else
        {
            desiredX = pageExitX;

        }

        newPosition = new Vector3(desiredX, playerCurrentPosition.y, playerCurrentPosition.z);
        Debug.Log(newPosition);
        return newPosition;
    }
    public void SavePosition(Vector3 pos)
    {
        lastUsedSpawn = pos;
    }
    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerChangePage, PlacePlayer);
        }
    }
}
