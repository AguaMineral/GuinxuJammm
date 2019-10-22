using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public Transform backg1;
    public Transform backg2;
    public Transform backg3;
    public Transform cam;

    private bool Cual = true;

    private float currentHeight = 10;
    private float currentWidth = 18;

    private void Update()
    {
        if (currentHeight < cam.position.y)
        {
            if(Cual)
            {
                backg1.localPosition = new Vector3(0, backg1.localPosition.y + 20, 1);
            }
            else
                backg2.localPosition = new Vector3(0, backg2.localPosition.y + 20, 1);

            currentHeight += 15;
            Cual = !Cual;
        }
        if(currentHeight > cam.position.y + 10)
        {
            if (Cual)
            {
                backg2.localPosition = new Vector3(0, backg2.localPosition.y - 20, 1);
            }
            else
                backg1.localPosition = new Vector3(0, backg1.localPosition.y - 20, 1);

            currentHeight -= 15;
            Cual = !Cual;
        }

        /*if (currentWidth < cam.position.x)
        {
            if (Cual)
            {
                backg1.localPosition = new Vector3(backg1.localPosition.x + 36, 0 , 1);
            }
            else
                backg3.localPosition = new Vector3(backg3.localPosition.x + 36, 0 , 1);

            currentWidth += 18;
            Cual = !Cual;
        }
        if (currentWidth > cam.position.x + 18)
        {
            if (Cual)
            {
                backg3.localPosition = new Vector3(backg3.localPosition.x - 36, 0, 1);
            }
            else
                backg1.localPosition = new Vector3(backg1.localPosition.x - 36, 0, 1);
            currentWidth -= 18;
            Cual = !Cual;
        }*/

    }





}