using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour
{

      public GameObject m_light;

    void Start()
    {
        m_light.active = false;
    }

    void OnTriggerEnter(Collider col)
    {
    //    Debug.Log("hello Aaron");
     if (col.gameObject.tag == "Player")
      {
       m_light.active = true;
      }
    }

    void OnTriggerExit(Collider col)
    {
        //    Debug.Log("hello Aaron");
        if (col.gameObject.tag == "Player")
        {
            m_light.active = false;
        }
    }


    void Update()
    {
     //   Debug.Log("update");
    } 

}
