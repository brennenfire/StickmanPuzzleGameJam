using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public GameObject linePrefab;

    Line activeLine;
    Line[] lines;

    public static LineCreator Instance { get; private set; }

    void Awake()
    {
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
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.DrawLine(mousePos);
        }
    }

    [ContextMenu("clear lines")]
    public void ClearLines()
    {
        lines = FindObjectsOfType<Line>();
        foreach(var line in lines)
        {
            Destroy(line.gameObject);
        }
    }
}
