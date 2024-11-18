using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Niantic.Lightship.AR.ObjectDetection;

public class LogResults : MonoBehaviour
{
    [SerializeField]
    private ARObjectDetectionManager _objectDetectionManager;
    // Start is called before the first frame update
    void Start()
    {
        _objectDetectionManager.enabled = true;
        _objectDetectionManager.MetadataInitialized += OnMetadataInitialized;
    }

    private void OnMetadataInitialized(ARObjectDetectionModelEventArgs args)
    {
        _objectDetectionManager.ObjectDetectionsUpdated += ObjectDetectionsUpdated;
    }

    private void ObjectDetectionsUpdated(ARObjectDetectionsUpdatedEventArgs args)
    {
        string resultString = "";
        var result = args.Results;

        if (result == null)
        {
            return;
        }

        resultString = "";

        for (int i = 0; i < result.Count; i++)
        {
            var detection = result[i];
            var categorizations = detection.GetConfidentCategorizations();
            if (categorizations.Count <= 0)
            {
                break;
            }
            categorizations.Sort((a, b) => b.Confidence.CompareTo(a.Confidence));

            for (int j = 0; j < categorizations.Count; j++)
            {
                var categoryToDisplay = categorizations[j];

                resultString += "Detected " + $"{categoryToDisplay.CategoryName}: " + "with " +
                                $"{categoryToDisplay.Confidence} Confidence \n";
                
            }
        } 
        Debug.Log(resultString);
    }

    private void OnDestroy()
    {
        _objectDetectionManager.MetadataInitialized -= OnMetadataInitialized;
        _objectDetectionManager.ObjectDetectionsUpdated -= ObjectDetectionsUpdated;
    }
}
