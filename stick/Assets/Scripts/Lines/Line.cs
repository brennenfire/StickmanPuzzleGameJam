using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCollider2D;
	public Rigidbody2D rb;

	List<Vector2> points = new List<Vector2>();

	[HideInInspector] public int pointsCount = 0;
	float pointsMinDistance = .1f;

	public void AddPoint(Vector2 newPoint)
	{
		if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) > pointsMinDistance)
			return;

		points.Add(newPoint);
		pointsCount++;

		lineRenderer.positionCount = pointsCount;
		lineRenderer.SetPosition (pointsCount -1, newPoint);

		if(pointsCount > 1)
			edgeCollider2D.points = points.ToArray();
	}

	Vector2 GetLastPoint()
	{
		return lineRenderer.GetPosition(pointsCount - 1);
	}

	public void UsePhysics(bool usePhysics)
	{
		rb.isKinematic = !usePhysics;
	}

	public void SetPointsMinDistance (float distance)
	{
		pointsMinDistance = distance;
	}
}
