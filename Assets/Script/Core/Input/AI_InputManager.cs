using UnityEngine;

public class AI_InputManager : MonoBehaviour
{
    CharacterMovement characterMovement;

    private float decisionInterval = 0.5f;
    private float timer;
    private int movingVal = 0;

    void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
        timer = decisionInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            RandomizeInputs();
            timer = decisionInterval;
        }

        RandomMovingInput();
    }

    private void RandomMovingInput()
    {
        characterMovement.inputDir = movingVal;
    }
    private void RandomizeInputs()
    {
        movingVal = Random.Range(-1, 2);

        characterMovement.jump = Random.value < 0.5f;
        characterMovement.leftMouse = Random.value < 0.5f;
        characterMovement.rightMouse = Random.value < 0.5f;
    }
}
