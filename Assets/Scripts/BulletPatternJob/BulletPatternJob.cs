
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

[BurstCompile]
public struct BulletPatternJob : IJobParallelFor
{
    public NativeArray<float3> BulletPos;
    public NativeArray<float3> Directions;
    public NativeArray<float> Speed;
    public float DeltaTime;

    public void Execute(int index)
    {
        BulletPos[index] += Directions[index] * Speed[index] * DeltaTime;
    }
}
