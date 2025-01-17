using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 8f; // 탄알 이동 속력
    private Rigidbody bulletRigidbody; // 이동에 사용할 컴포넌트

    void Start() {
        // 게임 오브젝트에서 컴포넌트를 찾아 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        // 속도 = 앞쪽방향 * 이동속력
        bulletRigidbody.velocity = transform.forward * speed;

        // 3초 뒤 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    // 트리거 충돌 시 자동으로 실행되는 메서드
    void OnTriggerEnter(Collider other) {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if(other.tag == "Player") {
            // 상대방 게임 오브젝트에서 컴포넌트 가져오기
            PlayerController PlayerController = other.GetComponent<PlayerController>();
            // 상대방으로부터 컴포넌트를 가져오는데 성공한 경우
            if(PlayerController != null) {
                // 상대방 컴포넌트의 Die() 메서드 실행
                PlayerController.Die();
            }
        }
    }
}
