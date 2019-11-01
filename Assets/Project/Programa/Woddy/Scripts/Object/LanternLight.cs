using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternLight : MonoBehaviour
{
    public TimeZone timezone;
    public GameObject lantan_light;

    // Update is called once per frame
    void Update()
    {
        if (timezone.TimeZoneGet() == "Daytime")
            lantan_light.SetActive(false);
        else if (timezone.TimeZoneGet() == "Night")
            lantan_light.SetActive(true);
    }
}
