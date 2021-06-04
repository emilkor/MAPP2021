using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameobjectNotActive : MonoBehaviour
{
    public void Inactivate()
    {
        gameObject.SetActive(false);
    }
}
