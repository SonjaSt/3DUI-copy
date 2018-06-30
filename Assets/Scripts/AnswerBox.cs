using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerBox : MonoBehaviour {

    private int numberOnBox;

    private TextMesh myTextMesh;
    

    private void Awake()
    {
        myTextMesh = GetComponentInChildren<TextMesh>();
    }

    private void Start()
    {
        numberOnBox = Random.Range(0, 11);
        myTextMesh.text = numberOnBox + "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Numbers")
        {
            Grabable numberCube = other.GetComponent<Grabable>();
            GameManager.Instance.OnCubeDropped(numberCube.number, numberOnBox);
        }
    }


}
