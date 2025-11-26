using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BossPaterns : MonoBehaviour
{
    [SerializeField] protected Bullet bulletObject;

    [Header("circle paterns")]
    [SerializeField] protected int p1NBulletPerCircles = 100;
    [SerializeField] protected float p1TimeBetweencircles = .5f;
    [SerializeField] protected float p1RotationSpeed = 55;
    [SerializeField] protected int p1NCircles = 20;
    [SerializeField] protected int p1BulletLifeTime = 30;
    protected float p1Angle;

    private void Start()
    {
        StartCoroutine(Pattern1());
    }

    private IEnumerator Pattern1()
    {
        for (int i = 0; i < p1NCircles; i++)
        {
            SpawnPatern1(p1Angle);
            p1Angle += p1RotationSpeed;
            yield return new WaitForSeconds(p1TimeBetweencircles);
        }
        p1Angle = 0;

    }

    protected void SpawnPatern1(float pAngle)
    {
        float ratio;
        for (int i = 0; i < p1NBulletPerCircles; i++)
        {
            ratio = (float)i / (float)p1NBulletPerCircles;
            Bullet bullet = Instantiate(bulletObject);
            BulletPattern pattern = bullet.AddComponent<BulletPattern>();
            bullet.transform.position = transform.position;
            bullet.Setup(pattern, Quaternion.AngleAxis(360 * ratio + pAngle, Vector3.up) * Vector3.forward, p1BulletLifeTime);
        }
    }
}
