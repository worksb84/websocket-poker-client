public static class Define
{
    public const string RESTAPI_SERVER_ADDRESS = "http://43.202.64.246:8001/v1";
    public const string GAME_SERVER_ADDRESS = "http://localhost:8087";
    public const string GENERATE_TABLE = GAME_SERVER_ADDRESS + "/table";
    public const string TABLE_JOIN = GAME_SERVER_ADDRESS + "/table/join";

    public enum Game
    {
        SEVEN,
        BULLISH_BEARISH,
        SKELETON,
        MIDUS_TOUCH
    }

    public enum GameRoomType
    {
        A100 = 100,
        A200 = 200,
        A300 = 300,
        FREE = 0,
        MAKE = 999
    }

    public enum Region
    {
        KOR,
        US,
    }
}
