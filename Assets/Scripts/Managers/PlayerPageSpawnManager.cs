using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PageSpawnPositions
{
    public Vector3 entrySpawn;
    public Vector3 exitSpawn;
}

public class PlayerPageSpawnManager : Singleton<PlayerPageSpawnManager>
{
    //decime a que pagina pasaste, y yo te dire donde deberia spawnear el player.
    [SerializeField] PageSpawnPositions[] _pageSpawnCollection;
    [SerializeField] Player _player;
    CharacterController _playerCC;

    void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerChangePage, PlacePlayer);
        _playerCC = _player.GetComponent<CharacterController>();
    }

    public void PlacePlayer(params object[] parameter)
    {
        //Debug.Log("place player");

        if (parameter[0] is int)
        {
            if (parameter[1] is bool)
            {
                int currentPage = (int)parameter[0];
                //print("pongo al player en el spawn de la pagina " + currentPage);
                _playerCC.enabled = false;

                if ((bool)parameter[1]) //si isNext
                {
                    //Debug.Log("lo pongo en el entry");
                    _player.transform.position = _pageSpawnCollection[currentPage - 1].entrySpawn;
                }
                else
                {
                    //Debug.Log("lo pongo en el exit");
                    _player.transform.position = _pageSpawnCollection[currentPage - 1].exitSpawn;
                }

                _playerCC.enabled = true;
                EventManager.Trigger(Evento.OnPlayerPlaced);
            }
        }
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerChangePage, PlacePlayer);
        }
    }
}
