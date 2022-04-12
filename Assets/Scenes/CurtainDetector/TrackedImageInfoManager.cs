using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class TrackedImageInfoManager : MonoBehaviour
{
    ARTrackedImageManager m_TrackedImageManager;
    public GameObject CurtainController, CurtainTransform, CurtainTransformPrefab;

    private float scale = 1f;
    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
        CurtainTransform = Instantiate(CurtainTransformPrefab);
    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            // Give the initial image a reasonable default scale
            //trackedImage.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            
            CurtainTransform.transform.position = trackedImage.transform.position;
            CurtainTransform.transform.localPosition = scale * new Vector3(1,1,1);
            CurtainController.GetComponent<CurtainController>().FindCurtainTransform(CurtainTransform.transform);
        }
    }
}