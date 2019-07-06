/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;
using Vuforia;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS
    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        Button play = GameObject.Find("PlayButton").GetComponent<Button>();
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            if(mTrackableBehaviour.TrackableName == "UpperWall")
            {
                play.interactable = !play.interactable;
                ShowMap.mapName = "Maps/Upper_Wall_Map";
                SendToGoogleMap.coordinates = "19.332657,72.814242";
                Debug.Log("Trackable inside if " + mTrackableBehaviour.TrackableName + " found");
            }
            else if (mTrackableBehaviour.TrackableName == "Vasai_Fort_Wall-Raw_File")
            {
                ShowMap.mapName = "Maps/Vasai_Fort_Wall_Map";
                SendToGoogleMap.coordinates = "19.329881,72.813954";
                Debug.Log("Trackable inside if " + mTrackableBehaviour.TrackableName + " found");
            }
            else if (mTrackableBehaviour.TrackableName == "Pillars")
            {
                ShowMap.mapName = "Maps/Darbar_Map";
                SendToGoogleMap.coordinates = "19.330574,72.815414";
                Debug.Log("Trackable inside if " + mTrackableBehaviour.TrackableName + " found");
            }
            else if (mTrackableBehaviour.TrackableName == "BrokenWall")
            {
                ShowMap.mapName = "Maps/Broken_Wall_Map";
                SendToGoogleMap.coordinates = "19.330514,72.815729";
                Debug.Log("Trackable inside if " + mTrackableBehaviour.TrackableName + " found");
            }

            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            if (mTrackableBehaviour.TrackableName == "UpperWall")
            {
                play.interactable = !play.interactable;
                GameObject.Find("Panel").GetComponent<PlayVideo>().videoPlayer.Stop();
                GameObject.Find("Panel").GetComponent<PlayVideo>().playing = false;
                Debug.Log("Trackable inside if " + mTrackableBehaviour.TrackableName + " lost");
            }
            else if (mTrackableBehaviour.TrackableName == "Vasai_Fort_Wall-Raw_File")
            {
                Debug.Log("Trackable inside if " + mTrackableBehaviour.TrackableName + " lost");
            }
            else if (mTrackableBehaviour.TrackableName == "Pillars")
            {
                Debug.Log("Trackable inside if " + mTrackableBehaviour.TrackableName + " lost");
            }
            else if (mTrackableBehaviour.TrackableName == "BrokenWall")
            {
                Debug.Log("Trackable inside if " + mTrackableBehaviour.TrackableName + " lost");
            }
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);
        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);
        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }

    #endregion // PROTECTED_METHODS
}
