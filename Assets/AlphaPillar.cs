using UnityEngine;
using OpenBCI.Network.Streams;

public class AlphaPillar : MonoBehaviour
{

    public GameObject alphaPillar;
    public GameObject betaPillar;
    public GameObject gammaPillar;
    public GameObject deltaPillar;
    [SerializeField] private AverageBandPowerStream Stream;

    private float alphaPillarHeight;
    private float betaPillarHeight;
    private float gammaPillarHeight;
    private float deltaPillarHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        alphaPillarHeight = 0f;
        betaPillarHeight = 0f;
        deltaPillarHeight = 0f;
        gammaPillarHeight = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //    Debug.Log("Alpha: " + Stream.AverageBandPower.Alpha);

        alphaPillarHeight = Stream.AverageBandPower.Alpha;
        alphaPillar.GetComponent<RectTransform>().sizeDelta = new Vector2(20, 50); //= new Vector3( alphaPillarHeight, 1, 1);

        betaPillarHeight = Stream.AverageBandPower.Beta;
        betaPillar.GetComponent<RectTransform>().sizeDelta = new Vector2(betaPillarHeight, 50);

        deltaPillarHeight = Stream.AverageBandPower.Delta;
        deltaPillar.GetComponent<RectTransform>().sizeDelta = new Vector2(deltaPillarHeight, 50);

        gammaPillarHeight = Stream.AverageBandPower.Gamma;
        gammaPillar.GetComponent<RectTransform>().sizeDelta = new Vector2(gammaPillarHeight, 50);

    }
}
