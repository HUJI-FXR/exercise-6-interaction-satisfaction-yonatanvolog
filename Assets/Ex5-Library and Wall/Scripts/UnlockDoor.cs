using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    public int keysToUnlockDoor = 2; // Number of keys required to unlock the door
    private int currentKeyCount = 0; // Tracks the current number of keys inserted

    public int liftDoorBy = 10;
    public float unlockSpeed = 2f; // Speed of the door unlocking animation
    private Vector3 targetPosition; // Target position when the door is unlocked
    private bool isUnlocking = false; // Flag to check if the door is currently unlocking

    private void Start()
    {
        // Set the target position to the current position + 10 units on the Y-axis
        targetPosition = transform.position + new Vector3(0, liftDoorBy, 0);
    }

    public void KeyInsertedIntoLock()
    {
        currentKeyCount++;
        Debug.Log($"Key inserted. Current key count: {currentKeyCount}");

        if (currentKeyCount >= keysToUnlockDoor)
        {
            UnlockTheDoor();
        }
    }

    public void KeyTakenOutOfLock()
    {
        if (currentKeyCount > 0)
        {
            currentKeyCount--;
            Debug.Log($"Key removed. Current key count: {currentKeyCount}");
        }
    }

    private void UnlockTheDoor()
    {
        Debug.Log("Unlocking the door!");
        isUnlocking = true;
    }

    private void Update()
    {
        if (isUnlocking)
        {
            // Smoothly move the door to the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, unlockSpeed * Time.deltaTime);

            // Stop unlocking if the door is close enough to the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isUnlocking = false;
                Debug.Log("Door is fully unlocked.");
            }
        }
    }
}
