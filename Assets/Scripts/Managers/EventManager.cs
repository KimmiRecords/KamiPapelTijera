using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//este es el mejor script del mundo, tengo un diccionario de eventos (que yo elijo los nombres jeje) y de metodos con parametros genericos (gg easy)
//entonces en cualquier script del juego puedo llamar a EventManager.Trigger, .Subscribe y .Unsubscribe

//trigger hace que todos los que se haya suscrito ejecuten sus metodos elegidos
//subscribe hace que adhiera a mis metodos para ser disparados cuando alguien mande trigger
//unsubscribe lo quita. hay que hacerlo siempre que vaya a destruir el objeto.

public enum Evento //LOS EVENTOS SE AGREGAN AL FINAL. NO EN EL MEDIO, PORQUE ARRUINAN LA NUMERACION
{
    OnPlayerPressedE,
    OnPlayerPressedQ,
    OnPlayerPressedSpace,
    OnPlayerMove, //cuando hor o ver son != 0. los params son 0 hor y 1 ver
    OnPlayerPrimaryClick,

    OnPageFinishTurning,
    
    OnDialogueStart, //param0 es el numero de camara
    OnDialogueEnd, //param0 es camara, param1 es dialogue

    OnPlayerChangeVida, //param 0 es float hp. param1 es max hp
    OnPlayerChangePage,//param 0 currentpage. param 1 si isnext (si voy para adelante o pa atras)
    OnAbuelaDropoff, //param 0 es el transform dropoffpoint
    OnPlayerPlaced, //triggereado por PlacePlayer. cuando muere, o cambia de pag, etc

    OnOrigamiApplied, //param0 es papercost (numero negativo), param1 es Origami origami
    OnPlayerResourceUpdated, //se triggerea cuando uso AddResource, param0 es el tipo, param1 es el amount total actual
    OnOrigamiStart, //le interesa al player para arrancar animaciones
    OnOrigamiEnd, //le interesa al player para arrancar animaciones
    OnOrigamiFoldChange, //param0 el fold actual, param1 los fold totales
    OnPlayerGetTijera,
    OnPlayerDie,
    OnPlayerPressedR,
    OnOrigamiGivePaperPlaneHat, //param0 es camara
    OnEncounterEnd, //cuando mato al ultimo enemigo, por ej
    OnEncounterStart,
    OnMouseEnterFlap,
    OnMouseExitFlap,
    OnPlayerPressedEsc,
    OnPlayerPressedM
}

public class EventManager
{
    public delegate void EventReceiver(params object[] parameters);

    static Dictionary<Evento, EventReceiver> _events = new Dictionary<Evento, EventReceiver>();

    public static void Subscribe(Evento evento, EventReceiver metodo)
    {
        if (!_events.ContainsKey(evento))
        {
            _events.Add(evento, metodo);
        }
        else
        {
            _events[evento] += metodo;
        }
    }

    public static void Unsubscribe(Evento evento, EventReceiver metodo)
    {
        if (_events.ContainsKey(evento))
        {
            _events[evento] -= metodo;
        }
    }

    public static void Trigger(Evento evento, params object[] parameters)
    {
        if (_events.ContainsKey(evento))
        {
            _events[evento](parameters);
        }
    }
}
