using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPlaceTrackedImages : MonoBehaviour
{
    public GameObject[] ArPrefabs;
    private readonly Dictionary<string, GameObject> _instantiatedPrefabs = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    // Cache AR tracked images manager from ARCoreSession private 
    ARTrackedImageManager _trackedImagesManager;

    void Awake() {
        _trackedImagesManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable() { 
        _trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged; 
    } 

    void OnDisable() { 
        _trackedImagesManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs) 
{
    // Go through all tracked images that have been added 
    // (-> new markers detected) 
    foreach (var trackedImage in eventArgs.added) 
    { 
        // Get the name of the reference image to search for the corresponding prefab 
        var imageName = trackedImage.referenceImage.name; 
        
        foreach (var curPrefab in ArPrefabs) 
        { 
            if (string.Compare(curPrefab.name, imageName, StringComparison.Ordinal) == 0 
                && !_instantiatedPrefabs.ContainsKey(imageName)) 
            { 
                // Found a corresponding prefab for the reference image, and it has not been 
                // instantiated yet > new instance, with the ARTrackedImage as parent 
                // (so it will automatically get updated when the marker changes in real life) 
                var newPrefab = Instantiate(curPrefab, trackedImage.transform); 
                // Store a reference to the created prefab 
                _instantiatedPrefabs[imageName] = newPrefab;
            } 
        } 
    }
}
}