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
    bool _freeRot = false;
    void Awake()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
        WebGLInput.captureAllKeyboardInput = false;
        #endif
    }
    // Start is called before the first frame update
    void Start()
    {
        _trans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FreeRotateCam(int flag)
    {
        _freeRot = 0 !=  flag;
    }
    public void RotateCam(string data)
    {
        var pos = JsonUtility.FromJson<Vector3>(data);
        float sensitivity = pos.z;
        _trans.Rotate(pos.y*sensitivity, pos.x*sensitivity, 0);
    }
    void LateUpdate()
    {
        if(!_freeRot)
        {
            _trans.rotation = target.rotation;
            _trans.position = new Vector3(target.position.x, target.position.y + camHeight, target.position.z - minDistance);
            _trans.LookAt(target); 
        }         
    }
}
