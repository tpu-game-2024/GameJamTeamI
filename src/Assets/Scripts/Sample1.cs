using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample1 : MonoBehaviour
{
    public Transform player;      // �v���C���[�̈ʒu���擾
    public float speed = 2.0f;    // �G�̈ړ����x
    public float turnInterval = 1.0f; // �����]�����s���Ԋu�i�b�j

    private Vector3 targetDirection; // �v���C���[�ւ̕���

    void Start()
    {
        // �����]����1�b���Ƃɍs���R���[�`�����J�n
        StartCoroutine(TurnTowardsPlayer());
    }

    void Update()
    {
        // ���݂̕����Ɍ������ēG��O�i������
        transform.Translate(targetDirection * speed * Time.deltaTime, Space.World);
    }

    IEnumerator TurnTowardsPlayer()
    {
        while (true)
        {
            // �v���C���[�̈ʒu�ƓG�̈ʒu���擾���AY���𖳎��iXZ���ʂ̂݁j
            Vector3 direction = (player.position - transform.position).normalized;

            // Y���̕����𖳎����āAXZ���݂̂ł̕������擾
            direction.y = 0;  // Y����0�ɂ��邱�Ƃ�XZ���ʂł̂ݒǔ�

            // �������X�V
            targetDirection = direction;

            // �G�̌������v���C���[�̕��Ɍ�����iXZ���̂݁j
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }

            // ���̕����]���܂�1�b�҂�
            yield return new WaitForSeconds(turnInterval);
        }
    }
}