using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class InputManager : ARBaseGestureInteractable

{
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField]private GameObject crosshair;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Touch touch;
    private Pose pose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CrosshairCalculation();
    }

    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        if(gesture.targetObject == null)
        {
            return true;
        }
        return false;
    }

    protected override void OnEndManipulation(TapGesture gesture)
    {
        if (gesture.isCanceled || (gesture.targetObject != null && IsPointerOverUI(gesture)))
        {
            return;
        }

        if (GestureTransformationUtility.Raycast(gesture.startPosition, hits, arSessionOrigin, TrackableType.PlaneWithinPolygon))
        {
            GameObject placedObject = Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation);
            var anchorObject = new GameObject("PlacementAnchor");
            anchorObject.transform.position = pose.position;
            anchorObject.transform.rotation = pose.rotation;
            placedObject.transform.parent = anchorObject.transform;
        }
    }

    bool IsPointerOverUI(TapGesture touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.startPosition.x, touch.startPosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData,results);
        return results.Count > 0;
    }

    void CrosshairCalculation()
    {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));

        if (GestureTransformationUtility.Raycast(origin, hits, arSessionOrigin, TrackableType.PlaneWithinPolygon))
        {
            pose = hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }
}
