using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public static LineCreator Instance { get; set; }

    public GameObject linePrefab;
    public LayerMask cantDrawOverLayer;
    public LayerMask cantDrawOverGroundLayer;
    Camera cam;

    public float linePointsMinDistance;
    public float lineWidth;
    public Gradient lineColor;

    Line currentLine;

    int cantDrawIndex;

    private void Start()
    {
        Instance = this;
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
        if (CheckCantDraw())
            EndDraw();
        else
            currentLine.AddPoint(mousePos);
    }

    bool CheckCantDraw()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Physics2D.CircleCast(mousePos, lineWidth / 3f, new Vector3(0f, 0f, 1), 1f, cantDrawOverLayer) || Physics2D.CircleCast(mousePos, lineWidth / 3f, new Vector3(0f, 0f, 1), 1f, cantDrawOverGroundLayer))
            return true;
        else
            return false;
    }

    void EndDraw()
    {
        if(currentLine != null)
            if(currentLine.pointsCount < 2)
                Destroy(currentLine.gameObject);
            else
            {
                currentLine.gameObject.layer = cantDrawIndex;
                currentLine.UsePhysics(true);
                currentLine = null;
            }
    }

    public void ClearLines()
    {
        var lines = FindObjectsOfType<Line>();
        foreach(var line in lines)
            Destroy(line.gameObject);
    }
}
