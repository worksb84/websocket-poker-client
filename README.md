```sh
protoc -I ./Protos --csharp_out ./Assets/Scripts/Pbm ./Protos/*.proto
```

mergeInto(LibraryManager.library, {
    SendDataToUnity: function(data) {
        Unity.SendMessage('GameManager', 'OnClose');
    }
});

window.onbeforeunload = function() {
    SendDataToUnity();
};

32-126,44032-55203,12593-12643,8200-9900

1. 구글 클라우드 플랫폼(https://console.cloud.google.com)에서 sha-1 지문이 제대로 등록되어있는지 확인 (앱서명, 업로드)
2. 파이어베이스와 연동해서 사용한다면 설정에 '업로드 키'의 sha-1값 등록했는지 확인(앱서명 키도 있어도 된다.)
3. Unity에서 Android Setup에서 Resorce xml, web client id 입력시 오타가 없는지(특히 패키지명에서 오타나는 경우가 있다.)
4. 내부테스트/비공개 테스트 앱이 스토어에 게시가 되었고 다운로드가 가능한지 확인
5. 유니티에서 Android Resolver에서 force resolve 해보기
6. 구글플레이 콘솔에서 테스트(내부든 비공개든) 쪽과 playgame서비스의 테스터를 모두 등록했는지 확인
7. 구글 클라우드 플랫폼에서 OAuth 동의 화면의 게시상태가 '프로덕션 단계' 인지 확인