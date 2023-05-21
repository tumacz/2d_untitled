using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHandler : MonoBehaviour, ITakeDamage
{
    public void TakeDamage(float damage)
    {
        Debug.Log("you hit the wall");
    }
}
