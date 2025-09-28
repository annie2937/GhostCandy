using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public Transform target; // ���� ��� (�÷��̾�)
    public float moveSpeed = 2f; // ���� �̵� �ӵ�
    public float followDistance = 5f; // ���󰡴� �ִ� �Ÿ�

    private void Update()
    {
        // Ÿ���� �����Ǿ� ���� ������ ����
        if (target == null) return;

        // ���� Ÿ�� ������ �Ÿ� ���
        float distance = Vector3.Distance(transform.position, target.position);

        // Ÿ���� ���� �� �ִ� �Ÿ� ���� ���� ���� �̵�
        if (distance < followDistance)
        {
            // Ÿ���� ��ġ�� ���ϵ��� �� �̵�
            Vector3 direction = (target.position - transform.position).normalized; // ���� ���
            transform.position += direction * moveSpeed * Time.deltaTime; // �̵�
        }
    }
}
