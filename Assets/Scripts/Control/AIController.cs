using RPG.Combat;
using RPG.Core;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        Health health;
        GameObject player;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            if (health.IsDead()) return;

            if (GetPlayerIsInRange(player) && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }
            else
            {
                fighter.Cancel();
            }
        }
        private bool GetPlayerIsInRange(GameObject player)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            return distanceToPlayer < chaseDistance;
        }
    }
}
