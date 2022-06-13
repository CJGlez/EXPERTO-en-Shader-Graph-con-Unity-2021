using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerPosition : MonoBehaviour
{
    void Update()
    {
        Shader.SetGlobalVector("_Player_Position", transform.position);
    }
}
