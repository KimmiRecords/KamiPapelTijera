using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPageSpawnManager : MonoBehaviour
{
    //decime a que pagina pasaste, y yo te dire donde deberia spawnear el player.

    public static PlayerPageSpawnManager instance;

    [SerializeField]
    Vector3[] _pageSpawnPositions;

    [SerializeField]
    Player _player;
    CharacterController _playerCC;

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerChangePage, PlacePlayer);
        _playerCC = _player.GetComponent<CharacterController>();
    }

    public void PlacePlayer(params object[] parameter)
    {
        if (parameter[0] is int)
        {
            int currentPage = (int)parameter[0];
            print("pongo al player en el spawn de la pagina " + currentPage);
            _playerCC.enabled = false;
            _player.transform.position = _pageSpawnPositions[currentPage - 1];
            _playerCC.enabled = true;

            //_player.transform.parent.position = _pageSpawnPositions[currentPage - 1];
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
