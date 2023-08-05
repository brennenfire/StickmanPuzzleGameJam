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
    public float ink;
    float usedInk = 0;

    Line currentLine;

    int cantDrawIndex;
    public int lineCounter = 3;
    public int initialLineCounter = 0;

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
            if (lineCounter == 0)
            {
                return;
            }
            BeginDraw();
        }

        if (currentLine != null)
        {
            Draw();
        }

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
        if (ink <= 0)
        {
            EndDraw();
        }

        ink -= Time.deltaTime;
        usedInk += Time.deltaTime;

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
                lineCounter--;
            }
            else if (usePhysics == false)
            {
                currentLine.gameObject.layer = cantDrawIndex;
                currentLine = null;
                lineCounter--;
            }
    }

    public void ClearLines()
    {
        // lineCounter nu e resetat cum trebuie
        lineCounter = initialLineCounter;
        var lines = FindObjectsOfType<Line>();
        /*
        foreach(var line in lines)
            Destroy(line.gameObject);
        */

        if (lines.Length > 0)
        {
            Destroy(lines[0].gameObject);
            ink += usedInk;
            usedInk = 0;
        }
    }
}