❗ 소라게 이사 가는 날 프로젝트에서 제가 작성했고, 불필요한 부분은 제거한 스크립트를 올리는 리포지토리입니다. ❗

🎮 Android download link : https://play.google.com/store/apps/details?id=com.FourSlashFive.TheHermitCrab&hl=ko

🎞 게임 소개 영상 : [https://www.youtube.com/watch?v=CHMZl2t7sP4](https://www.youtube.com/watch?v=iLvoDJsG5Ys)

------------------------------------------------------------------------

Release date : 2018.9

Platform : Mobile (Google play)

다운로드 수 : 4000 이상

------------------------------------------------------------------------


🛠 저는 이 게임에서 대표적으로 이런 걸 구현했습니다!

- 적의 등장과 이동 (Coroutine)
- 게임 진행 정도와 가속 게이지
- 맵 스크롤
- 플레이어 컨트롤
- 애니메이션, 파티클

------------------------------------------------------------------------

🛠 적의 등장과 이동 (Coroutine)

![5](https://user-images.githubusercontent.com/62327209/232225134-d11ea52b-3841-4312-a3ed-68fde52c552e.png)
![6](https://user-images.githubusercontent.com/62327209/232225135-114fa091-7a78-4fc0-8abc-9aec355c2fe6.png)


- 적들은 화면 오른쪽에서 생성된 후 화살표 방향으로 이동합니다.
- Code - [https://github.com/dydvn/TheHermitCrab/blob/main/EnemySpawn_and_Move.cs](https://github.com/dydvn/TheHermitCrab/blob/main/EnemySpawn_and_Move.cs)


------------------------------------------------------------------------

🛠 게임 진행 정도와 가속 게이지

![7](https://user-images.githubusercontent.com/62327209/232225181-fe7e242d-92d2-4aaa-b6cc-aeb555ed44de.png)


- 상단의 게이지는 한 개의 스테이지 진행률이고, 100%가 되면 다음 스테이지로 이동합니다.
- 플레이어 왼쪽의 게이지는 플레이어의 속도 게이지입니다. 빈칸일 때는 1단, 하늘색 2단, 파란색 3단으로 각각 속도가 다릅니다.
- Code - [https://github.com/dydvn/TheHermitCrab/blob/main/Progress.cs](https://github.com/dydvn/TheHermitCrab/blob/main/Progress.cs)

------------------------------------------------------------------------

🛠 맵 스크롤

![8](https://user-images.githubusercontent.com/62327209/232225264-a7f4991c-53d9-4fba-ad65-a16b12f4f77f.png)


- 4개의 배경 레이어가 각자의 속도로 오른쪽에서 왼쪽으로 계속 스크롤 됩니다.
- Code - [https://github.com/dydvn/TheHermitCrab/blob/main/BackgroundRepeat.cs](https://github.com/dydvn/TheHermitCrab/blob/main/BackgroundRepeat.cs)


------------------------------------------------------------------------

🛠 플레이어 컨트롤

![9](https://user-images.githubusercontent.com/62327209/232225296-82bcd719-7183-432c-9c14-c47271917c21.png)
![10](https://user-images.githubusercontent.com/62327209/232225299-c977733c-04df-4582-9061-faa9e2ea0676.png)


- 공격과 숨기 기능을 구현했습니다.
- Code - [https://github.com/dydvn/TheHermitCrab/blob/main/PlayerAction.cs](https://github.com/dydvn/TheHermitCrab/blob/main/PlayerAction.cs)
