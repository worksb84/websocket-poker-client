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

1. ���� Ŭ���� �÷���(https://console.cloud.google.com)���� sha-1 ������ ����� ��ϵǾ��ִ��� Ȯ�� (�ۼ���, ���ε�)
2. ���̾�̽��� �����ؼ� ����Ѵٸ� ������ '���ε� Ű'�� sha-1�� ����ߴ��� Ȯ��(�ۼ��� Ű�� �־ �ȴ�.)
3. Unity���� Android Setup���� Resorce xml, web client id �Է½� ��Ÿ�� ������(Ư�� ��Ű������ ��Ÿ���� ��찡 �ִ�.)
4. �����׽�Ʈ/����� �׽�Ʈ ���� ���� �Խð� �Ǿ��� �ٿ�ε尡 �������� Ȯ��
5. ����Ƽ���� Android Resolver���� force resolve �غ���
6. �����÷��� �ֿܼ��� �׽�Ʈ(���ε� �������) �ʰ� playgame������ �׽��͸� ��� ����ߴ��� Ȯ��
7. ���� Ŭ���� �÷������� OAuth ���� ȭ���� �Խû��°� '���δ��� �ܰ�' ���� Ȯ��