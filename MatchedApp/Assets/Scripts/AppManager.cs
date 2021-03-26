using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> dates;
    public GameObject Logger;
    private SwipeDirection direction;
    [SerializeField] float speed;
    void Start()
    {
        sortDates();
    }

    void sortDates()
    {
        if(dates.Count == 1)
        {
            dates[0].GetComponent<SpriteRenderer>().sortingOrder = 2;
            dates[0].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        }
        if (dates.Count >= 2)
        {
            dates[0].GetComponent<SpriteRenderer>().sortingOrder = 2;
            dates[0].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
          

            dates[1].GetComponent<SpriteRenderer>().sortingOrder = 0;
            dates[1].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = -1;
            if (dates.Count >= 2)
            {
                for (int i = 2; i < dates.Count; i++)
                {
                    dates[i].GetComponent<SpriteRenderer>().sortingOrder = -5;
                    dates[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = -5;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction = Logger.GetComponent<SwipeLogger>().swipeDir;
        changePortrait();
        sortDates();
    }

    void changePortrait()
    {
        bool swiped = dates[0].GetComponent<Date>().swiped;
        bool offScreen = dates[0].GetComponent<Date>().offScreen;
        if (!offScreen && direction == SwipeDirection.Left)
        {
            dates[0].transform.Translate(Vector3.left * Time.deltaTime * speed);
            swiped = true;
            // resizeList();
           // Logger.GetComponent<SwipeLogger>().swipeDir = SwipeDirection.None;
            Debug.Log("Reject");
        }
        if(!offScreen && direction == SwipeDirection.Right)
        {
            dates[0].transform.Translate(-Vector3.left * Time.deltaTime * speed);
            swiped = true;
            //resizeList();
          
            Debug.Log("Interested");
        } else if (offScreen)
        {
            Logger.GetComponent<SwipeLogger>().swipeDir = SwipeDirection.None;
            dates[0].SetActive(false);
            if (dates.Count != 1) resizeList();
            //  dates[0].transform.Translate(Vector3.zero);
        }
    }

    void resizeList()
    {
        if (dates.Count > 0 && dates != null)
        {
            List<GameObject> tempList = new List<GameObject>();

            for (int i = 1; i < dates.Count; i++)
            {
                tempList.Add(dates[i]);
            }
            dates = tempList;
        }
    }
}
