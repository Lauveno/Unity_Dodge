using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody playerRigidbody; // 이동에 사용할 리지드바지 컴포넌트
    public float speed = 8f; // 이동 속력

    void Start() {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 속도 할당
        playerRigidbody.velocity = newVelocity;
    }

    public void Die() {
        // 게임 오브젝트 비활성화
        gameObject.SetActive(false);

        // 씬에 존재하는 GameManager 타입의 오브젝트 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        // 가져온 오브젝트의 메서드 실행
        gameManager.EndGame();
    }
}
