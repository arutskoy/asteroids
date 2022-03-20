using UnityEngine;

[RequireComponent(typeof(Spaceship))]
public sealed class InputHandler : MonoBehaviour
{
    private Spaceship _spaceship;

    private void Awake()
    {
        _spaceship = GetComponent<Spaceship>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _spaceship.RotateRight();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _spaceship.RotateLeft();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _spaceship.Accelerate();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _spaceship.Gun.Fire();
        }
    }
}