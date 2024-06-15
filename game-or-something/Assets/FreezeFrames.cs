using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeFrames : MonoBehaviour
{



    public bool isFrozen = false;

    public float timeoffreeze;

    private float pending_timeoffreeze;

    void Update()
    {

        if (!isFrozen && pending_timeoffreeze > 0)
        {
            StartCoroutine(freezeFrame(pending_timeoffreeze));
        }
    }
    public void FreezeTime()
    {

        pending_timeoffreeze = timeoffreeze;

    }

    public IEnumerator freezeFrame(float time)
    {
        
        Time.timeScale = 0;
        
        isFrozen = true;

        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1;
        
        isFrozen = false;

        pending_timeoffreeze = 0;
    }


}
