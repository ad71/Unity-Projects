using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public LineRenderer lr;
    public EdgeCollider2D ec;
    List<Vector2> points;

    public void UpdateLine(Vector2 mousePos) {
        if(points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }
        // Check if the mouse has moved enough for us to insert a new point, and if it has, insert new point at mouse position.

        if (Vector2.Distance(points.Last(), mousePos) > .1f)
        {
            SetPoint(mousePos);
        }
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);
        lr.positionCount = points.Count;
        lr.SetPosition(points.Count - 1, point);
        if(points.Count > 1)
            ec.points = points.ToArray();
    }
}