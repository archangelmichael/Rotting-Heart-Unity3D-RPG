using UnityEngine;
using System.Collections;

public abstract class AI : MonoBehaviour, IMovable
{
    public abstract void Move();
}
