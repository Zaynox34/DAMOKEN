using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColidBox
{
    public Vector3 center;
    public Vector3 boxSize;
    public ColidBox(Vector3 center,Vector3 boxSize)
    {
        this.center = center;
        this.boxSize = boxSize;
    }
}
