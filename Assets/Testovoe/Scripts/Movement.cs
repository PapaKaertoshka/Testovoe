using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    //[SerializeField] private float _speed;
    [SerializeField] public bool changeAxes = true;
    private float desiredPosX;
    private bool _isMoving = true;
    private float _deltaMouseX = 0f;
    private float _prevMouseX = 0f;
    private void Strat()
    {
       /* move = true;*/
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            desiredPosX = transform.position.x;
            _prevMouseX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0) && _isMoving)
        {
            Vector3 smoothedPos;
            _deltaMouseX = _prevMouseX - Input.mousePosition.x;
            if ((desiredPosX > -1.8f || _deltaMouseX < 0) && (desiredPosX < 1.8f || _deltaMouseX > 0))
            {
                desiredPosX -= _deltaMouseX * Time.deltaTime;
            }
            if (changeAxes)
            {
               smoothedPos = Vector3.Lerp(transform.position, new Vector3(desiredPosX, transform.position.y, transform.position.z), /*_speed * */Time.deltaTime);
                transform.position = smoothedPos;
            } else if (!changeAxes)
            {
               smoothedPos = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, desiredPosX), /*_speed * */Time.deltaTime);
               transform.position = smoothedPos;
            }
            _prevMouseX = Input.mousePosition.x;
        }
    }
/*    private void FixedUpdate()
    {
        if (_isMoving)
        {
            transform.Translate(0, 0, _speed * Time.fixedDeltaTime);
        }

    }
    public bool move
    {
        get { return _isMoving; }
        set { _isMoving = value; }
    }*/
}
