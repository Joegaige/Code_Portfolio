using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationOneController : Presentation
{

    public GameObject cube;
    
    private float startTime;
    private float kf1;
    private float kf2;
    private float kf3;
    private bool kf1Done = false;

    // Start is called before the first frame update
    // Happens when we find the image to trak on
    void Start()
    {
        //setting up the start animations
        totalTime = 50f;
        startTime = Time.time;
        cube.SetActive(false);

        //What time to start animations
        //once the time starts wait 3 seconds to start the animation
        kf1 = startTime + 3;
        //4 seconds after kf1 starts key frame 2 will start
        kf2 = kf1 + 4;
        //5 seconds after kf2 starts key frame 3 will start
        kf3 = kf2 + 5;
    }

    // Update is called once per frame
    //This is where we will track animations and time
    void Update()
    {
        //if the key frame 1 is not done and time is greater than the start time of key frame1
        if(kf1Done == false && Time.time >= kf1)
        {
            //if the cube is not active i.e. start of the scene, all should be inactive
            if (!cube.activeSelf)
            {

                cube.SetActive(true);
                //setting the cube really small so we can make a grow animation
                //this can be done in code or in the animator
                cube.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
            }
            else
            {
                //once its active we now need to add to the scale to get the groe effect
                startCube();
            }
            
        }

        //checking that kf1 is done and kf2 start time is past
        if(Time.time >= kf2 && kf1Done == true)
        {
            startAnimation();
        }
    }

    //this is where we will grow the cube
    void startCube()
    {
        //setting the max size to prevent cube growing too big
        Vector3 maxScale = new Vector3(9f, 9f, 9f);

        //checking if the cube is the correct size, if its under the max size then we will grow it by 0.5f per call
        if (cube.transform.localScale.x < maxScale.x)
        {
            cube.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            // once its the max size we will stop the animation
            kf1Done = true;
            kf2 = Time.time + 5;
        }
        
    }

    void startAnimation()
    {
        //calling the animator to spin the cube
        //see the animator component
        cube.GetComponent<Animator>().SetBool("spinIt", true);
    }
}
