using UnityEngine;

public class CatchPlayer : MonoBehaviour
{
    public bool IsAtPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsAtPlayer = true;
            Debug.Log("Exterminate");
        }
    }
}
