using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float RecoilStrengh = 1.0f;
    public GameObject Bullet;
    public float BulletSpeed = 0.0f;
    public float Damage = 0.0f;

    private PlayerInput playerInput;
    private InputAction Joystick;

    private Vector2 velocity;
    private Vector2 JoystickInput;
    private bool b_JoystickIsHeld = false;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        Joystick = playerInput.actions["Joystick"];
        
        velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //this chunk of code gets the data from the joystick, records its position and checks if it was released
        //record input
        if(Joystick.phase == InputActionPhase.Started)
        {
            b_JoystickIsHeld = true;
            JoystickInput = Joystick.ReadValue<Vector2>();
        }
        //if released use input
        else if(b_JoystickIsHeld && Joystick.phase == InputActionPhase.Waiting)
        {
            b_JoystickIsHeld = false;
            ShootCannon(JoystickInput);
        }

        //move player
        Vector3 newpos = transform.position;
        newpos.x += velocity.x * Time.deltaTime;
        newpos.y += velocity.y * Time.deltaTime;
        transform.position = newpos;
    }

    //takes input and shoots projectile in direction
    void ShootCannon(Vector2 dir)
    {
        //spawn and fire bullet
        GameObject newBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<PlayerBullet>().SetDirection(velocity - (dir * BulletSpeed));
        newBullet.GetComponent<PlayerBullet>().SetDamage(Damage);
        //apply recoil
        velocity += dir * RecoilStrengh;
        print("bullet " + (velocity - (dir * BulletSpeed)));
        print("velocity" + velocity);
    }
}
