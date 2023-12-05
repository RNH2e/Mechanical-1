using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public static GameScript Instance;
    public List<PinScript> pinList;
    public Transform selectedPin;
    public List<ColumnScript> columnList;
    public bool isDrag;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 30, 1 << 6))
        {
            if (!selectedPin)
            {
                selectedPin = hit.transform;
                isDrag = true;
            }
            else if (selectedPin == hit.transform)
            {
                selectedPin = null;
            }
         
        }

        if (selectedPin && Input.GetMouseButton(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 30, 1 << 7))
        {
            selectedPin.transform.position = hit.point;
        }

        if (selectedPin && Input.GetMouseButtonUp(0))
        {
            bool found = false;
            for (int i = 0; i < columnList.Count; i++)
            {
                if (Vector3.Distance(selectedPin.position, columnList[i].transform.position) < 1)
                {
                    selectedPin.position = columnList[i].transform.position;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                selectedPin.transform.position = selectedPin.GetComponent<PinScript>().startPos;
            }
            selectedPin = null;


        }


    }
}
