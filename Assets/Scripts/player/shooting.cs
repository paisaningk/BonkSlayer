using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.BaseDog;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject crosshairs;
    public AudioClip Gunsound;
    private Vector3 target;
    private Bullet bulletPrefab;
    private Transform bulletStart;
    private PlayerDog player;
    private float bulletSpeed;
    private LevelManager Levelplayer;

    // Use this for initialization
    private void Start ()
    {
        Levelplayer = GameObject.Find("Level").GetComponent<LevelManager>();
        player = Levelplayer.spawnedPlayerDog;
        bulletPrefab = Levelplayer.spawnedPlayerDog.defaultBullet;
        bulletStart = Levelplayer.spawnedPlayerDog.gunPosition;
        bulletSpeed = Levelplayer.spawnedPlayerDog.defaultBullet.speed;
        Cursor.visible = false;
    }
    
    // Update is called once per frame
    private void Update ()
    {
        if (player == null)
        {
            return;
        }
        rotationZ();
    }

    private void rotationZ()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if(Input.GetMouseButtonDown(0)){
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
        }
    }

    private void fireBullet(Vector2 direction, float rotationZ)
    {
        AudioSource.PlayClipAtPoint(Gunsound,Camera.main.transform.position);
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.transform.position = bulletStart.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
