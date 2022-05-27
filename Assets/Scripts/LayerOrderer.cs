using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LayerOrderer : MonoBehaviour
{
    public int zzzz;
    // Start is called before the first frame update
    void Start()
    {
        zzzz = -1*(int)(transform.position.z * 100);
        GetComponent<SortingGroup>().sortingOrder = zzzz;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
