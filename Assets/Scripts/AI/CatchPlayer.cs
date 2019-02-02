using UnityEngine;

public class CatchPlayer : MonoBehaviour
{
    [HideInInspector]
    public bool IsAtPlayer = false;
    public GameObject Player;


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.GetComponentsInChildren<CapsuleCollider>();
            IsAtPlayer = true;
            Vector3 pos = new Vector3(GetComponent<MoveTowardsPos>().Startpos.x, transform.position.y, GetComponent<MoveTowardsPos>().Startpos.z);
            transform.LookAt(pos);
            if(IsAtPlayer == true)
            {
                Player.GetComponent<WinOrLose>().GameOver = true;
            }
            
        }
    }
}
