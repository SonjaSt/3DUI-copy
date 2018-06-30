using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;

    [SerializeField] private TextMesh equationText;
    [SerializeField] private AudioSource successSound;
    [SerializeField] private AudioSource failerSound;
    [SerializeField] private ParticleSystem successEffect;

    private int number1;
    private int number2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        ChoseEquation();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void ChoseEquation()
    {
        do
        {
            number1 = Random.Range(0, 10);
            number2 = Random.Range(0, 10);
        } while ((number1 + number2 > 10) || (number1 + number2 <= 0));

        equationText.text = number1 + " + " + number2 + " = ";
    }

    public void OnCubeDropped(int numberOnCube, int numberOnBox)
    {
        if (numberOnCube == number1 + number2)
        {
            successSound.Play();
            successEffect.Play();
            ChoseEquation();
        }
        else
        {
            failerSound.Play();
        }
    }
}
