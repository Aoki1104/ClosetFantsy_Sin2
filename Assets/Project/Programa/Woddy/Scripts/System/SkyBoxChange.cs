using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxChange : MonoBehaviour
{
    [SerializeField] private Material[] skybox;
    private TimeZone time_zone;

    private string time_zone_state;         //現在の時間帯
    private string before_time_zone;

    // Start is called before the first frame update
    void Start()
    {
        time_zone = this.GetComponent<TimeZone>();
    }

    // Update is called once per frame
    void Update()
    {
        time_zone_state = time_zone.TimeZoneGet();

        if(time_zone_state != before_time_zone)
        {
            if (time_zone_state == "Daytime")
                RenderSettings.skybox = skybox[0];

            if (time_zone_state == "Night")
                RenderSettings.skybox = skybox[1];

            before_time_zone = time_zone_state;
        }


    }
}
