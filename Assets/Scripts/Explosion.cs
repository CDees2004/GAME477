using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class Explosion : MonoBehaviour
{
    public float frameInterval = .15f;
    private float _lastFrame = 0;
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
        _curr =  (float)Time.timeAsDouble;
        _lastFrame = _curr; 
        _startTime = (float)Time.timeAsDouble;
        _lifetime = frameInterval*15;


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
        if (_frameCounter < sprites.Count)
        {
            if (_curr - _lastFrame > frameInterval)
            {
                sprites[_frameCounter].SetActive(false);
                _frameCounter++;
                if (_frameCounter < sprites.Count)
                {
                    sprites[_frameCounter].SetActive(true);
                    _lastFrame = _curr;
                }

            }
        }
    }


}
