using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Node : MonoBehaviour
{
    [SerializeField]
    List<Node> _neighbors = new List<Node>();

    public bool isBlocked;
    public int cost = 1;


    private void Start()
    {
        //GameManager.instance.AddNode(this);
    }
    

    public List<Node> GetNeighbors()
    {
        //if (_neighbors.Count == 0)
        //{
        //    _neighbors = _grid.GetNeighborsByPosition(_posInGrid.x, _posInGrid.y);
        //}
        return _neighbors;
    }

}
