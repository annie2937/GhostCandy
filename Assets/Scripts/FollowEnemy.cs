using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public Transform target; // 따라갈 대상 (플레이어)
    public float moveSpeed = 2f; // 적의 이동 속도
    public float followDistance = 5f; // 따라가는 최대 거리

    private void Update()
    {
        // 타겟이 설정되어 있지 않으면 종료
        if (target == null) return;

        // 적과 타겟 사이의 거리 계산
        float distance = Vector3.Distance(transform.position, target.position);

        // 타겟이 따라갈 수 있는 거리 내에 있을 때만 이동
        if (distance < followDistance)
        {
            // 타겟의 위치로 향하도록 적 이동
            Vector3 direction = (target.position - transform.position).normalized; // 방향 계산
            transform.position += direction * moveSpeed * Time.deltaTime; // 이동
        }
    }
}
