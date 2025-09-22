using System.ComponentModel;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player_transform;
    private Vector3 camera_position;
    private Vector3 player_position;
    private Vector3 camera_offset;

    [SerializeField] private float eps = 0.1f;
    [SerializeField] private float speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera_offset = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        camera_position = GetComponent<Transform>().position;
        player_position = player_transform.position;
        float distance = Vector3.Distance(camera_position - camera_offset, player_position);

        if (distance > eps)
        {
            GetComponent<Transform>().position = Vector3.Lerp(camera_position, player_position + camera_offset, (float)(Math.Pow(speed, distance)) * Time.deltaTime);
        }
    }
}
