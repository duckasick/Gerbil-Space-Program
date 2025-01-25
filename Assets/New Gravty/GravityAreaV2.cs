using UnityEngine;

public abstract class GravityAreaV2 : MonoBehaviour
{
    
    [SerializeField] private int _priority = 0;

    public float gravityForce = 10;

    public int Priority => _priority;

    public abstract Vector3 GetGravityDirection(GravityBodyV2 _gravityBody);


    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out GravityBodyV2 gb))
        {
            gb.AddGravityArea(this);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out GravityBodyV2 gb))
        {
            gb.RemoveGravityArea(this);
        }
    }
}
