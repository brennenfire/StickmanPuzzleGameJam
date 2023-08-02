using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public GameObject linePrefab;
    [SerializeField] float drawTimer = 3f;
    float drawTimerLocal;

    Line activeLine;
    Line[] lines;

    public static LineCreator Instance { get; private set; }

    void Awake()
    {
        drawTimerLocal = drawTimer;
        Instance = this;    
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject lineGO = Instantiate(linePrefab);
            activeLine = lineGO.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
            activeLine = null;

        if (activeLine != null)
        {
            drawTimer -= Time.deltaTime;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.DrawLine(mousePos);
            if (drawTimer <= 0)
            {
                activeLine = null;
                return;
            }
        }
    }

    [ContextMenu("clear lines")]
    public void ClearLines()
    {
        drawTimer = drawTimerLocal;
        lines = FindObjectsOfType<Line>();
        foreach(var line in lines)
        {
            Destroy(line.gameObject);
        }
    }
}
