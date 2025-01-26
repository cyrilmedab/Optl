using UnityEngine;
using OpenBCI.Network.Streams;
using TMPro;
using OpenBCI.Network;
using OpenBCI.UI.TimeSeries.Graphs;

public class BCIMetrics : MonoBehaviour
{

    public GameObject ppgPillar;
    public GameObject ppgValue;

    public GameObject alphaPillar;
    public GameObject alphaValue;
    public GameObject betaPillar;
    public GameObject betaValue;
    public GameObject gammaPillar;
    public GameObject gammaValue;
    public GameObject deltaPillar;
    public GameObject deltaValue;



    [SerializeField] private AverageBandPowerStream Stream;
    [SerializeField] private PPGMetricsStream ppgStream;

    private float ppgPillarHeight;
    private float alphaPillarHeight;
    private float betaPillarHeight;
    private float gammaPillarHeight;
    private float deltaPillarHeight;

    private float[] ppgArray;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ppgPillarHeight = 0f;
        alphaPillarHeight = 0f;
        betaPillarHeight = 0f;
        deltaPillarHeight = 0f;
        gammaPillarHeight = 0f;
        

    }

    // Update is called once per frame
    void Update()
    {
        //    Debug.Log("Alpha: " + Stream.AverageBandPower.Alpha);
        ppgArray = ppgStream.GetHeartRateData();
        //Debug.Log("PPG: " + ppgArray);

        if (ppgStream.GetHeartRateData().Length > 0)
        {
            //Debug.Log("PPG: " + ppgArray[ppgArray.Length -1]);
            ppgPillarHeight = ppgArray[ppgArray.Length - 1];
            ppgPillar.GetComponent<RectTransform>().sizeDelta = new Vector2((float)(ppgPillarHeight /(1.2f)), 50); //= new Vector3( alphaPillarHeight, 1, 1);
            ppgValue.GetComponent<TextMeshProUGUI>().text = ppgPillarHeight.ToString();
        }

        alphaPillarHeight = Stream.AverageBandPower.Alpha;
        alphaPillar.GetComponent<RectTransform>().sizeDelta = new Vector2(100*alphaPillarHeight, 50); //= new Vector3( alphaPillarHeight, 1, 1);
        alphaValue.GetComponent<TextMeshProUGUI>().text =  alphaPillarHeight.ToString();

        betaPillarHeight = Stream.AverageBandPower.Beta;
        betaPillar.GetComponent<RectTransform>().sizeDelta = new Vector2(100 * betaPillarHeight, 50);
        betaValue.GetComponent<TextMeshProUGUI>().text =  betaPillarHeight.ToString();


        deltaPillarHeight = Stream.AverageBandPower.Delta;
        deltaPillar.GetComponent<RectTransform>().sizeDelta = new Vector2(100 * deltaPillarHeight, 50);
        deltaValue.GetComponent<TextMeshProUGUI>().text =  deltaPillarHeight.ToString();


        gammaPillarHeight = Stream.AverageBandPower.Gamma;
        gammaPillar.GetComponent<RectTransform>().sizeDelta = new Vector2(100 * gammaPillarHeight, 50);
        gammaValue.GetComponent<TextMeshProUGUI>().text =  gammaPillarHeight.ToString();


    }
}
