using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;
public class Player : MonoBehaviour
{
    private float speed = 5.0f;
    private float rotSpeed = 3.0f;
    private Quaternion _targetRot;
    private Animator _animator;
    private Coroutine _runCo = null;
    private Vector3 _startPos;
    Camera _mainCamera;
    enum Anim
    {
        Stand = 0,
        Run,
        // 流星打击
        DHMeteorStrike,
        // 旋风斩/剑刃风暴
        Whirlwind,
        // 冥想
        Meditate,
        // 风暴打击
        Stormstrike,
        // 猛虎掌
        PalmStrike,
        // 旭日东升踢
        RisingSunKick,
        // 火焰之息
        BreathOfFire,
        // 鼓掌
        EmoteApplaud,
        // 翔龙在天
        FlyingKick,
        // 怒雷破
        ThousandFists
    }
    public void startStormstrike()
    {
        _animator.SetInteger("anim", (int)Anim.Stormstrike);
    }
    public void startPalmStrike()
    {
        _animator.SetInteger("anim", (int)Anim.PalmStrike);
    }
    public void startRisingSunKick()
    {
        _animator.SetInteger("anim", (int)Anim.RisingSunKick);
    }
    public void startBreathOfFire()
    {
        _animator.SetInteger("anim", (int)Anim.BreathOfFire);
    }
    public void startEmoteApplaud()
    {
        _animator.SetInteger("anim", (int)Anim.EmoteApplaud);
    }
    public void startFlyingKick()
    {
        _animator.SetInteger("anim", (int)Anim.FlyingKick);
    }
    public void startThousandFists()
    {
        _animator.SetInteger("anim", (int)Anim.ThousandFists);
    }
    // Start is called before the first frame update
    IEnumerator run(float len)
    {
        System.DateTime startTime = DateTime.Now;
        _animator.SetInteger("anim", (int)Anim.Run);
        double dur = 0f;
        Debug.Log( $"Run {len} seconds" );
        while(dur < len)
        {
            dur = (DateTime.Now - startTime).TotalSeconds;
            transform.Translate(0, 0, speed * Time.deltaTime);
            yield return null;
        }  
        _animator.SetInteger("anim", (int)Anim.Stand);
    }
    IEnumerator whirlwind()
    {
        System.DateTime startTime = DateTime.Now;
        _animator.SetInteger("anim", (int)Anim.Whirlwind);
        double dur = 0f;
        // wave 3 seconds
        while(dur < 3)
        {
            dur = (DateTime.Now - startTime).TotalSeconds;
            yield return null;
        }  
        if(_runCo != null)
        {
            StopCoroutine(_runCo);
        }
        _animator.SetInteger("anim", (int)Anim.Stand);
    }
    // invoke in update
    void TouchTest () 
    {
        Touch myTouch = Input.GetTouch(0);

        Touch[] myTouches = Input.touches;
        for(int i = 0; i < Input.touchCount; i++)
        {
            //Do something with the touches
        }
    }
    public void EnableCamera(int flag)
    {
        // can not directly use Camera.main, because it will be null some times
        if( 0 == flag )
        {
            _mainCamera.enabled = false;
            // Camera.main.gameObject.SetActive(false);
        }
        else
        {
            _mainCamera.enabled = true;
            // Camera.main.gameObject.SetActive(true);
        }
    }
    public void stand()
    {
        _animator.SetInteger("anim", (int)Anim.Stand);
    }
    public void startRun(float len = 4)
    {
        _runCo = StartCoroutine( run(len) );
    }
    public void startWhirlwind()
    {
        StartCoroutine("whirlwind");
    }
    public void startDHMeteorStrike()
    {
        _animator.SetInteger("anim", (int)Anim.DHMeteorStrike);
    }
    public void startMeditate()
    {
        _animator.SetInteger("anim", (int)Anim.Meditate);
    }
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        // this.transform.Find("Strong Aquaragia break").GetComponent<ParticleSystem>();
        _animator = GetComponentsInChildren<Animator>()[0];
        _targetRot = transform.rotation;
        // Debug.Log( $"Anim.Run={(int)Anim.Run}" );
    }
    public void Go(String data)
    {
        char[] spearator = { ',' };
        var cos = data.Split(spearator);
        Vector3 b = new Vector3(float.Parse(cos[0]), float.Parse(cos[1]), 0 );
        Vector3 e = new Vector3(float.Parse(cos[2]), float.Parse(cos[3]), 0 );
        Debug.Log($"in Go, b={b};e={e}");
        TurnAndRunTo(b, e);
    }
    void TurnAndRunTo(Vector3 begin, Vector3 end)
    {
        // begin/end suppose to be mouse coodinates in 2D screen
        Ray ray0 = Camera.main.ScreenPointToRay(begin);
        Ray ray1 = Camera.main.ScreenPointToRay(end);
        RaycastHit mouseHit0, mouseHit1;
        if (Physics.Raycast(ray0, out mouseHit0) && Physics.Raycast(ray1, out mouseHit1)) {
            GameObject hitObject = mouseHit1.transform.gameObject;
            // if (hitObject.layer == LayerMask.NameToLayer("Ground")) {                   
                float len = Vector3.Distance(end, begin);
                Debug.Log($"mouse scatch len={len}");
                len /= 100;
                Vector3 to = mouseHit1.point;
                Vector3 from = mouseHit0.point;
                Vector3 adjustedTo = new Vector3(to.x, transform.position.y, to.z);
                Vector3 adjustedFrom = new Vector3(from.x, transform.position.y, from.z);
                _targetRot = Quaternion.LookRotation(adjustedTo - adjustedFrom);
                if(_runCo != null)
                {
                    StopCoroutine(_runCo);
                }                    
                startRun(len);
            // }
        }
    }
    
    // Update is called once per frame
    void Update()
    {	
		if (Input.GetMouseButtonUp(0)) {
			TurnAndRunTo(_startPos, Input.mousePosition );
		}
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRot, rotSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0)) {
            // Debug.Log("GetMouseButtonDown");
            _startPos = Input.mousePosition;
            Debug.Log($"set _startPos = Input.mousePosition in update, {_startPos}");
        }
        
        KeyTest();    
    }
    void KeyTest()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            startRun();
        }
        else if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            startWhirlwind();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            startDHMeteorStrike();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            startMeditate();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            startStormstrike();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            startPalmStrike();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            startRisingSunKick();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            startBreathOfFire();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            startEmoteApplaud();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            startFlyingKick();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha9))
        {
            startThousandFists();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha0))
        {

        }

    }
    void LateUpdate()
    {
        // if(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        // {
        //     stand();
        // }
    }
    void OnGUI()
    {
       
    }
}
