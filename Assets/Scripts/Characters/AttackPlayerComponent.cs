using UnityEngine;
using Assets.Scripts.Characters;

public class AttackPlayerComponent : AttackComponent
{
    [SerializeField]
    private Transform player;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public override void UpdateComponent()
    {
        target = player.transform.position;
    }
}
