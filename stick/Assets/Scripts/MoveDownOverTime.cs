using UnityEngine;

public class MoveDownOverTime : MonoBehaviour
{
    [SerializeField] float duration = 1f;
    [SerializeField] public Vector3 magnitude = Vector3.down;
    [SerializeField] AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    Vector3 startingPosition;
    Vector3 endingPosition;

    float elapsed;

    void Awake() => startingPosition = transform.position;

    void OnEnable()
    {
        elapsed = 0f;
        endingPosition = startingPosition + magnitude;
    }

    void OnDisable()
    {
        transform.position = startingPosition;
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        float pctElapsed = elapsed / duration;
        float pctOnCurve = curve.Evaluate(pctElapsed);
        transform.position = Vector3.Lerp(startingPosition, endingPosition, pctOnCurve);
    }
}