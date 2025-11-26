using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected BulletPattern pattern;
    protected Vector3 direction;
    protected float speed;
    protected float lifeTime;
    protected float timer;

    protected Transform tempTrans;

    public void Setup(BulletPattern pPattern, Vector3 pDirection, float pLifeTime)
    {
        pattern = pPattern;
        pPattern.Direction = pDirection;
        speed = pattern.Speed;
        lifeTime = pLifeTime;
    }

    private void Update()
    {
        tempTrans = pattern.ComputeNextPos(transform);
        transform.position = tempTrans.position;
        transform.rotation = tempTrans.rotation;
        transform.localScale = tempTrans.localScale;

        timer += Time.deltaTime;
        if (timer >= lifeTime) Death();
    }

    protected void Death()
    {
        pattern.OnDeath();
        Destroy(gameObject);
    }
}
