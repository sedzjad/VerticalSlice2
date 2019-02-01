using UnityEngine;

public class CatchPlayer : MonoBehaviour
{
    [HideInInspector]
    public bool IsAtPlayer = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsAtPlayer = true;
            Vector3 pos = new Vector3(GetComponent<MoveTowardsPos>().Startpos.x, transform.position.y, GetComponent<MoveTowardsPos>().Startpos.z);
            transform.LookAt(pos);
            
        }
    }
}
