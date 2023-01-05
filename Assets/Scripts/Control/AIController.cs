using RPG.Combat;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        Fighter fighter;
        Mover mover;
        GameObject player;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            mover = GetComponent<Mover>();
            player = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            if (GetPlayerIsInRange(player) && fighter.CanAttack(player))
            {
                print(gameObject.name + ": attack the player");
                // mover.MoveTo(player.transform.position);
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
