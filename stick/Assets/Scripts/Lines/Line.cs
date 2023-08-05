using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCollider;
	public Rigidbody2D rb;
	public float usedInk;

	[HideInInspector] public List<Vector2> points = new List<Vector2>();
	[HideInInspector] public int pointsCount = 0;

	public static Line Instance; 

	float pointsMinDistance = .1f;
	float circleColliderRadius;

    void Start()
    {
		Instance = this;    
    }

    public Vector2 GetLastPoint()
	{
		return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
	}

	public void UsePhysics(bool usePhysics)
	{
		rb.isKinematic = !usePhysics;
	}

	public void SetLineColor(Gradient LineColor)
	{
		lineRenderer.colorGradient = LineColor;
	}

	public void SetLineWidth(float width)
	{
		lineRenderer.startWidth = width;
		lineRenderer.endWidth = width;

		circleColliderRadius = width / 2f;
		edgeCollider.edgeRadius = width / 2f;
	}

	public void AddPoint(Vector2 newPoint)
	{
		if (points.Count >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
			return;

		points.Add(newPoint);
		pointsCount++;

		CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
		circleCollider.offset = newPoint;
		circleCollider.radius = circleColliderRadius;

		lineRenderer.positionCount = pointsCount;
		lineRenderer.SetPosition(pointsCount - 1, newPoint);

		if(pointsCount > 1)
			edgeCollider.points = points.ToArray(); 
	}

	public void SetPointMinDistance(float distance)
	{
		pointsMinDistance = distance;
	}
}
