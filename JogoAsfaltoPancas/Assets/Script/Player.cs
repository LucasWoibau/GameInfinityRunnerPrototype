using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _direction;

    public float forwardSpeed;

    private int _desiredLane = 1; //0:left 1:middle 2:right
    public float laneDistance = 4; //the distance between two lanes

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        this.transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        _direction.z = forwardSpeed;

        if (SwipeManager.swipeLeft)
        {       
            _desiredLane--;
            
            if (_desiredLane == -1)
            {
                _desiredLane = 0;
            }
        }

        if (SwipeManager.swipeRight)
        {
            _desiredLane++;
            
            if(_desiredLane == 3)
            {
                _desiredLane = 2;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(_desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if(_desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        //transform.position = Vector3.Lerp(transform.position, targetPosition, 70 * Time.deltaTime);
        if(transform.position == targetPosition)
        {
            return;
        }
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 12 * Time.deltaTime;
        if(moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            _controller.Move(moveDir);
        }
        else
        {
            _controller.Move(diff);
        }       
    }

    private void FixedUpdate()
    {
        _controller.Move(_direction * Time.fixedDeltaTime);
    }

}