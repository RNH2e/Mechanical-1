using UnityEngine;

public class PinScript : MonoBehaviour
{
    public float[] distances;
    public int[] ringCount;
    public GameObject[] ropeCount;
    public Transform pivot;


    public Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;

        int childCount = transform.childCount;
        ringCount = new int[childCount];
        distances = new float[childCount];

        for (int i = 0; i < childCount; i++)
        {
            ringCount[i] = i;
            if (i < childCount)
            {
                distances[i] = (i + 1) * 2f;
            }
        }

    }

    private void Update()
    {
        ropeCount[0].transform.position = pivot.transform.position;
        if (GameScript.Instance.isDrag)
        {
            float offset = Vector3.Distance(startPos, transform.position);

            for (int i = 0; i < distances.Length; i++)
            {
                if (offset < distances[i])
                {
                  
                    for (int j = 0; j <= i; j++)
                    {
                        transform.GetChild(ringCount[j]).gameObject.SetActive(false);
                    }
                    for (int j = i; j < ringCount.Length; j++)
                    {
                        transform.GetChild(ringCount[j]).gameObject.SetActive(true);
                    }
                    for (int j = 0; j <i; j++)
                    {
                        ropeCount[j].gameObject.SetActive(true);
                    }
                    for (int j = i; j < ropeCount.Length; j++)
                    {
                        ropeCount[j].gameObject.SetActive(false);
                    }
                    break;
                }
            }
        }
    }
}