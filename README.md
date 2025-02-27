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