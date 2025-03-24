using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class Explosion : MonoBehaviour
{
    public float frameInterval = .15f;
    private float _lastFrame = .15f;
    private float _lifetime;
    private int  _frameCounter = 0;
    private float _startTime;
    public List<GameObject> sprites = new List<GameObject>();
    public AudioClip explosion;
    private AudioSource audioSrc;

    private float _curr;
    // Start is called before the first frame update
    void Start()
    {
        //_lastFrame += (float)Time.timeAsDouble;
        _startTime = (float)Time.timeAsDouble;
        _lifetime = frameInterval*3;
        gameObject.GetComponent<VisualEffect>().Play();
        audioSrc.clip = explosion;
        audioSrc.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeAsDouble - _startTime > _lifetime)
        {
            Destroy(gameObject);
        }
        _curr =  (float)Time.timeAsDouble;
        NextFrame();
    }

    void NextFrame()
    {   
        if (_curr - _lastFrame > frameInterval)
        {
            sprites[_frameCounter].SetActive(false);
            _frameCounter++;
            sprites[_frameCounter].SetActive(true);
            _lastFrame = _curr;

        }
    }


}
