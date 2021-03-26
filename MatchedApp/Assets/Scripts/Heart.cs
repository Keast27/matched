using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    Vector3 touchPosWorld;

    public GameObject greenScreen;

    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Ended;

    [SerializeField] private bool showGreenScreen = false;
    private void Start()
    {
        greenScreen.SetActive(showGreenScreen);
    }
    void Update()
    {
        //We check if we have more than one touch happening.
        //We also check if the first touches phase is Ended (that the finger was lifted)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
        {
            //We transform the touch position into word space from screen space and store it.
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            //We now raycast with this information. If we have hit something we can process it.
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            if (hitInformation.collider != null)
            {
                //We should have hit something with a 2D Physics collider!
                GameObject touchedObject = hitInformation.transform.gameObject;
                //touchedObject should be the object someone touched.
                Debug.Log("Touched " + touchedObject.transform.name);

                showGreenScreen = !showGreenScreen;

                greenScreen.SetActive(showGreenScreen);
            }
        }
    }
}
