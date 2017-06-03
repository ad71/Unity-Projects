using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    public Color lineColor;
    private List<Transform> nodes = new List<Transform>();
    // OnDrawGizmosSelected() draws the gizmo only when the GameObject is selected
    void OnDrawGizmosSelected()
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

        for(int i = 0; i < nodes.Count; ++i)
        {
            Vector3 current = nodes[i].position;
            Vector3 previous = Vector3.zero;
            if (i > 0) previous = nodes[i - 1].position;
            else if (i == 0 && nodes.Count > 1) previous = nodes[nodes.Count - 1].position;
            Gizmos.DrawLine(previous, current);
            Gizmos.DrawWireSphere(current, 0.3f);
        }
    }
}
