using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    [SerializeField] CinemachineVirtualCamera[] allVirtualCameras;

    [Header("Controls for lerping the Y Damping during player jump/fall")]
    [SerializeField] float fallPanAmount = .25f;
    [SerializeField] float fallYPanAmount = .35f;
    public float fallSpeedYDampingChangeThreshold = -15f;

    public bool IsLerpingYDamping { get; private set; }
    public bool LerpedFromPlayerFalling { get; set; }

    Coroutine lerpYpanCoroutine;

    CinemachineVirtualCamera currentCamera;
    CinemachineFramingTransposer framingTransposer;

    float normYPanAmount;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        foreach (var cam in allVirtualCameras)
        {
            currentCamera = cam;

            framingTransposer = currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }

        normYPanAmount = framingTransposer.m_YDamping;
    }

    public void LerpYdamping(bool isPlayerFalling)
    {
        lerpYpanCoroutine = StartCoroutine(LerpYAction(isPlayerFalling));
    }

    IEnumerator LerpYAction(bool isPlayerFalling)
    {
        IsLerpingYDamping = true;

        float startDampAmount = framingTransposer.m_YDamping;
        float endDampAmount = 0;

        if (isPlayerFalling)
        {
            endDampAmount = fallPanAmount;
            LerpedFromPlayerFalling = true;
        }
        else
            endDampAmount = normYPanAmount;


        float elapsedTime = 0f;
        while(elapsedTime < fallYPanAmount)
        {
            elapsedTime += Time.deltaTime;

            float lerpedPanAmount = Mathf.Lerp(startDampAmount, endDampAmount, (elapsedTime  / fallYPanAmount));
            framingTransposer.m_YDamping = lerpedPanAmount;

            yield return null;
        }
        IsLerpingYDamping = false;
    }
}
