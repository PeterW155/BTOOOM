using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class CallFrontEnd : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void CallSite(string info);

    public void SomeMethod ()
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CallSite("Unity says Hello");
        Debug.Log("The weird code ran");
#endif
    }
}
