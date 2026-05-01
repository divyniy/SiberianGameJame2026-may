using UnityEngine;

[CreateAssetMenu(fileName = "DaggerPunchAbility", menuName = "Сustom/Abilites/DaggerPunchAbility")]
public class DaggerPunchAbility : Ability
{
    public float angle;
    public LayerMask playerLayer;

    public override void Activate()
    {
        Transform player = ServiceLocator.Get<Player>().transform;
        Vector3 forward = ServiceLocator.Get<Player>().GetForward();

        Collider[] coliders = Physics.OverlapSphere(player.position + forward * 2, 2.5f, ~playerLayer);
        Debug.DrawLine(player.position, forward*2);

        foreach(Collider i in coliders)
        {
            if(i.GetComponent<IDamagable>() == null) continue;

            float agnleBetween = Vector3.Angle(forward, (i.transform.position-player.transform.position).normalized);

            if(agnleBetween <= angle)
            {
                i.GetComponent<IDamagable>().TakeDamage(5);
                Debug.Log("hitted");
            }
        }
    }
}
