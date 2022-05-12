using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    public static LightingManager lighting;
    
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    [SerializeField] private Material skyBox;
    //Variables
    [SerializeField, Range(0, 24)] private float startHour = 0;
    [SerializeField, Range(0, 24)] private float endtHour = 24;


    private float realTimeDuration;
    private float gameHourDuration;
    private float realTimeHour;   
    private float timeOfDay;
    [SerializeField]
    private float gameHour;
    public float GameHour { get => gameHour; }
    
    /*private void Awake()
    {
        if (lighting != null)
            Destroy(gameObject);
        else
            lighting = this;
    }*/

    private void Start()
    {
        #region Singleton en start xd
        if (lighting != null)
            Destroy(gameObject);
        else
            lighting = this;
        #endregion

        if (endtHour <= startHour)
            endtHour = endtHour + 24;

        realTimeDuration = TimeSysN.timeSys.duracionLoop * 3;
        gameHourDuration = endtHour - startHour;
        realTimeHour = 0;
        gameHour = startHour;

        timeOfDay = (((realTimeHour / realTimeDuration) * gameHourDuration) / (24)) + (startHour / gameHourDuration);

        UpdateLighting(timeOfDay);
        UpdateSkyBox(timeOfDay);
    }
    private void Update()
    {
        if (Preset == null)
            return;

        if (TimeSysN.timeSys.tiempoCorriendo && Application.isPlaying)
        {
            realTimeHour += Time.deltaTime;
            timeOfDay = (((realTimeHour / realTimeDuration) * gameHourDuration)/(24)) + (startHour / gameHourDuration); 

            UpdateLighting(timeOfDay);
            UpdateSkyBox(timeOfDay);
        }
        gameHour = (timeOfDay * 24);
    }


    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    private void UpdateSkyBox(float timePercent) //necesita arreglo
    {

        if (timePercent < 0.19f)
        {
            skyBox.SetFloat("_CubemapTransition", 1);
            //print("Noche");
        }
        else if (timePercent < 0.37f)
        {
            skyBox.SetFloat("_CubemapTransition", 1 - ((timePercent) - (0.225f)) / (0.375f - 0.225f));
            //print(1 - ((timePercent) - (0.225f)) / (0.375f - 0.225f));
        }
        else if (timePercent < 0.62f)
        {
            skyBox.SetFloat("_CubemapTransition", 0);
            //print("Dia");
        }
        else if (timePercent < 0.81f)
        {
            skyBox.SetFloat("_CubemapTransition", ((timePercent) - (0.625f)) / (0.775f - 0.625f));
            //print(((timePercent) - (0.625f)) / (0.775f - 0.625f));
        }
        else
        {
            skyBox.SetFloat("_CubemapTransition", 1);
            //print("Noche");
        }

        skyBox.SetColor("_TintColor", Preset.SkyBoxColor.Evaluate(timePercent));
    }



    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            /*Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }*/
        }
    }

}
