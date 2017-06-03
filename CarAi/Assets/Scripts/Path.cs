using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    public Color lineColor;
    private List<Transform> nodes = new List<Transform>();
    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor;
        Transform[] pathTransforms = GetComponentsInChildren<Transform>();
        // This array also contains its own transform as a component
        // To filter this out, we will loop throgh this array
        nodes = new List<Transform>();
        for(int i = 0; i < pathTransforms.Length; ++i)
        {
            if (pathTransforms[i] != this.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }
}
