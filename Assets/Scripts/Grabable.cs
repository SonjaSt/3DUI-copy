
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grabable : MonoBehaviour, IRayCastable
{
    Scene activeScene;

    public int number;
    public Color highlightedColor;
    public Color selectedColor;
    public Transform Anchor;
    public float distance = -0.15f;
    public float grabSmoothness = 15.0f;
    public float rotationForce = 250.0f;

    private Renderer myRenderer;
    private AudioSource myAudioSource;
    private Rigidbody myRigidBody;

    private Material outlineMaterial;

    private bool isSelected = false;

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
        outlineMaterial = myRenderer.materials[1];
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //myRenderer.material.color = idleColor;
        activeScene = SceneManager.GetActiveScene();
    }
    
    private void Update()
    {
        if (isSelected == true)
        {
            transform.position = Vector3.Lerp(transform.position, Anchor.position + Anchor.forward * distance, Time.deltaTime * grabSmoothness);
        }
    }



    public void OnSelected()
    {
        if (isSelected == false)
        {
            //myRenderer.material.color = highlightedColor;
            outlineMaterial.SetFloat("_Outline", 0.03f);
            outlineMaterial.SetColor("_OutlineColor", highlightedColor);
        }
        if (activeScene.name.Equals("Level1"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isSelected == false)
                {
                    //myRenderer.material.color = selectedColor;
                    outlineMaterial.SetColor("_OutlineColor", selectedColor);
                    myRigidBody.AddTorque(Vector3.up * rotationForce * 0.0001f, ForceMode.Force);
                    isSelected = true;
                    myRigidBody.useGravity = false;
                }
                else
                {
                    //myRenderer.material.color = highlightedColor;
                    outlineMaterial.SetColor("_OutlineColor", highlightedColor);
                    isSelected = false;
                    myRigidBody.useGravity = true;
                }
            }
        }
        else if (activeScene.name.Equals("Level1_alternate"))
        {
            if (AlternateTrackableEventHandler.isVisible)
            {
                AlternateTrackableEventHandler.isVisible = false;
                if (isSelected == false)
                {
                    //myRenderer.material.color = selectedColor;
                    outlineMaterial.SetColor("_OutlineColor", selectedColor);
                    myRigidBody.AddTorque(Vector3.up * rotationForce * 0.0001f, ForceMode.Force);
                    isSelected = true;
                    myRigidBody.useGravity = false;
                }
                else
                {
                    //myRenderer.material.color = highlightedColor;
                    outlineMaterial.SetColor("_OutlineColor", highlightedColor);
                    isSelected = false;
                    myRigidBody.useGravity = true;
                }
            }
        }
    }

    public void OnReleased()
    {
        if (isSelected == false)
        {
            //myRenderer.material.color = idleColor;
            outlineMaterial.SetFloat("_Outline", 0.0f);
        }
    }
}
