using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using System.Collections;

public class FixAedansVREditorPlayModeBug : MonoBehaviour
{
    
    public void Awake(){
        if( XRGeneralSettings.Instance.Manager.activeLoader != null )
        {
            XRGeneralSettings.Instance.Manager.StopSubsystems();
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        }
        XRGeneralSettings.Instance.Manager.InitializeLoaderSync();
        XRGeneralSettings.Instance.Manager.StartSubsystems();
    }
    
    
    // public void Awake() {
    //     StartCoroutine(InitializeXR());
    // }
    //
    // private IEnumerator InitializeXR() {
    //     // Fix: Stop subsystems and deinitialize the loader if it's already active
    //     if (XRGeneralSettings.Instance.Manager.activeLoader != null) {
    //         XRGeneralSettings.Instance.Manager.StopSubsystems();
    //         XRGeneralSettings.Instance.Manager.DeinitializeLoader();
    //     }
    //
    //     // Initialize the loader
    //     XRGeneralSettings.Instance.Manager.InitializeLoaderSync();
    //
    //     // Wait until the loader is initialized
    //     while (XRGeneralSettings.Instance.Manager.activeLoader == null) {
    //         yield return null;
    //     }
    //
    //     // Start the subsystems
    //     XRGeneralSettings.Instance.Manager.StartSubsystems();
    // }
}