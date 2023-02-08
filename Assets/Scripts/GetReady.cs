using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetReady : MonoBehaviour
{

    public GhostControl ghost;

    void OnGetReadyFadeEnd()
    {
        ghost.GetReadyAnimFinished();
    }

}
