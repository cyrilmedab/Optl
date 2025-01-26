using UnityEngine;
using OpenBCI.Network.Streams;

public class AlphaPillar : MonoBehaviour
{

    public GameObject pillar;
    [SerializeField] private AverageBandPowerStream Stream;

    private float pillarHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pillarHeight = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Alpha: " + Stream.AverageBandPower.Alpha);

        pillarHeight = Stream.AverageBandPower.Alpha;
        pillar.transform.localScale = new Vector3(1, pillarHeight, 1);

    }
}
