using UnityEngine;

public class LineCreator : MonoBehaviour
{
    
    public static LineCreator Instance { get; set; }

    [SerializeField] float linePointsMinDistance;
    public GameObject linePrefab;

    Line currentLine;
    Camera cam;

    private void Start()
    {
        Instance = this;
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            BeginDraw();

        if (currentLine != null)
            Draw();

        if (Input.GetMouseButtonUp(0))
            EndDraw();
    }

    void BeginDraw()
    {
        currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

        currentLine.UsePhysics(false);
        currentLine.SetPointsMinDistance(linePointsMinDistance);
    }

    void Draw()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        currentLine.AddPoint(mousePos);
    }

    void EndDraw()
    {
        if (currentLine != null)
            if (currentLine.pointsCount < 2)
                Destroy(currentLine.gameObject);
            else
            {
                currentLine.UsePhysics(true);
                currentLine = null;
            }
    }
}
