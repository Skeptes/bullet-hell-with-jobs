using UnityEngine;

public class BulletJob : MonoBehaviour
{
    protected BulletPattern pattern;
    public Vector3 Direction;
    public float Speed;
    public float LifeTime;
    public float Timer;

    protected Transform tempTrans;

    public void Setup(BulletPattern pPattern, Vector3 pDirection, float pLifeTime)
    {
        pattern = pPattern;
        pPattern.Direction = pDirection;
        Direction = pDirection;
        Speed = pattern.Speed;
        LifeTime = pLifeTime;
        Destroy(gameObject, pLifeTime);
    }

    void OnDestroy()
    {
        BossPaterns.bulletList.Remove(this);
    }
}
