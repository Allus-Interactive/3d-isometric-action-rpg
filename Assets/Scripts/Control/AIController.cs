using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        private void Update()
        {
            if (GetPlayerIsInRange())
            {
                print(gameObject.name + ": attack the player");
            }
        }
        private bool GetPlayerIsInRange()
        {
            GameObject player = GameObject.FindWithTag("Player");

            return Vector3.Distance(transform.position, player.transform.position) < chaseDistance;
        }
    }
}
