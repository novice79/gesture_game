using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float minDistance = 4;
    public float maxDistance = 8;
    public float camHeight = 7;
    private Transform _trans;
    // Start is called before the first frame update
    void Start()
    {
        _trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        _trans.rotation = target.rotation;
        _trans.position = new Vector3(target.position.x, target.position.y + camHeight, target.position.z - minDistance);
        _trans.LookAt(target);      
    }
}
