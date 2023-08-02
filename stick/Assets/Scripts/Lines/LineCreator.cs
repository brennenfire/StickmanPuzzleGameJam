using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public GameObject linePrefab;
    public LayerMask cantDrawOverLayer;
    Camera cam;

    public float linePointsMinDistance;
    public float lineWidth;
    public Gradient lineColor;

    Line currentLine;

    int cantDrawIndex;

    private void Start()
    {
        cantDrawIndex = LayerMask.NameToLayer("CantDrawOver");
        cam = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            BeginDraw();

        if (currentLine != null)
            Draw();

        if(Input.GetMouseButtonUp(0))
            EndDraw();
    }

    void BeginDraw()
    {
        currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

        currentLine.SetLineColor(lineColor);
        currentLine.SetLineWidth(lineWidth);
        currentLine.SetPointMinDistance(linePointsMinDistance);
        currentLine.UsePhysics(false);
    }

    void Draw()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.CircleCast(mousePos, lineWidth / 3f, new Vector3(0f, 0f, 1), 1f, cantDrawOverLayer);

        if (hit)
            EndDraw();
        else
            currentLine.AddPoint(mousePos);
    }

    void EndDraw()
    {
        if(currentLine != null)
            if(currentLine.pointsCount < 2)
                Destroy(currentLine.gameObject);
            else
            {
              //  currentLine.gameObject.layer = cantDrawIndex;
                currentLine.UsePhysics(true);
                currentLine = null;
            }
    }
}
