using System.Linq;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public class BulletsManager : MonoBehaviour
{
    public NativeArray<float3> BulletsPositions;
    public NativeArray<float3> Directions;
    public NativeArray<float> Speeds;
    public NativeArray<float> Timers;
    //protected BossPaterns spawner;

    void Start()
    {
        //spawner = FindFirstObjectByType<BossPaterns>();
    }

    void Update()
    {
        BulletsPositions = new NativeArray<float3>(BossPaterns.bulletList.Count, Allocator.TempJob);
        Directions = new NativeArray<float3>(BossPaterns.bulletList.Count, Allocator.TempJob);
        Speeds = new NativeArray<float>(BossPaterns.bulletList.Count, Allocator.TempJob);

        for (int i = 0; i < BulletsPositions.Length; i++)
        {
            BulletsPositions[i] = BossPaterns.bulletList[i].transform.position;
            Directions[i] = BossPaterns.bulletList[i].Direction;
            Speeds[i] = BossPaterns.bulletList[i].Speed;
            //if (i == 0) print(Directions[i]);
        }

        BulletPatternJob moveJob = new BulletPatternJob
        {
            BulletPos = BulletsPositions,
            Directions = Directions,
            Speed = Speeds,
            DeltaTime = Time.deltaTime
        };

        JobHandle moveHandle = moveJob.Schedule(BulletsPositions.Length, 500);

        moveHandle.Complete();

        for (int i = 0; i < BulletsPositions.Length; i++)
        {
            BossPaterns.bulletList[i].transform.position = BulletsPositions[i];


            //if (i == 0) print(BulletsPositions[i]);
        }
    }

}
