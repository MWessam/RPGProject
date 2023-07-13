using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LookComponent : MonoBehaviour, ILookComponent
{
    public abstract Transform ParentTransform { get; }

    public void Look(Transform target)
    {
        throw new System.NotImplementedException();
    }
}

