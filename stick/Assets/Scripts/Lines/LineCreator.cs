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
    public int lineCounter = 3;
    int initialLineCounter;

    public bool usePhysics = false;
    
    private void Start()
    {
        initialLineCounter = lineCounter;
        Instance = this;
        cantDrawIndex = LayerMask.NameToLayer("CantDrawOver");
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (lineCounter > 0)
            {
                BeginDraw();
                lineCounter--;
            }
        }

        if (currentLine != null)
            Draw();

        if (Input.GetMouseButtonUp(0))
        {
            EndDraw();
        }
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
        if (!CheckCantDraw())
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
        if (currentLine != null)
            if (currentLine.pointsCount < 2)
                Destroy(currentLine.gameObject);
            else if (usePhysics == true)
            {
                currentLine.gameObject.layer = cantDrawIndex;
                currentLine.UsePhysics(true);
                currentLine = null;
            }
            else if (usePhysics == false)
            {
                currentLine.gameObject.layer = cantDrawIndex;
                currentLine = null;
            }
    }

    public void ClearLines()
    {
        lineCounter = initialLineCounter;
        var lines = FindObjectsOfType<Line>();
        foreach(var line in lines)
            Destroy(line.gameObject);
    }
}
