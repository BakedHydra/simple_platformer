using System.ComponentModel;
using UnityEngine;
using System;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player_transform;
    private Vector3 camera_position;
    private Vector3 player_position;
    private Vector3 camera_offset;
    private Vector3 center_position;

    private float angle;

    [SerializeField] private float eps;
    [SerializeField] private float speed;
    [SerializeField] private int radius;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            radius = 40;

            int x = 0;
            int y = 0;
            int z = 25;


            center_position = new Vector3(x, y, z);
            speed = 0.5f;
        }
        else 
        {
            camera_offset = transform.position;
            eps = 0.1f;
            speed = 2f;
        } 
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            angle += speed * Time.deltaTime;
            camera_position.x = center_position.x + radius * Mathf.Cos(angle);
            camera_position.y = center_position.y + 15 + 10 * Mathf.Cos(angle);
            camera_position.z = center_position.z + radius * Mathf.Sin(angle);
            transform.position = camera_position;
            transform.LookAt(center_position);
        }
        else
        {
            camera_position = transform.position;
            player_position = player_transform.position;
            float distance = Vector3.Distance(camera_position - camera_offset, player_position);

            if (distance > eps)
            {
                transform.position = Vector3.Lerp(camera_position, player_position + camera_offset, (Mathf.Pow(speed, distance)) * Time.deltaTime);
            }
        }
    }
}
