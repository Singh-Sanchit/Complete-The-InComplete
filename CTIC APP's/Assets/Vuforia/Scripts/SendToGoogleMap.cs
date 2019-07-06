using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToGoogleMap : MonoBehaviour
{
    public static string coordinates;

    public void send()
    {
        if(coordinates == null || coordinates == "")
        {
            Application.OpenURL("http://maps.google.com/maps?q=19.330915,72.815331");
        }
        else
        {
            Application.OpenURL("http://maps.google.com/maps?q=" + coordinates);
        }
    }
}
