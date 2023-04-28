using UnityEngine;

public abstract class Enemy : Entity
{
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
}