using UnityEngine;

public abstract class Enemy : Entity
{
    public float Speed
    {
        get { return _maxSpeed; }
        set { _maxSpeed = value; }
    }
}