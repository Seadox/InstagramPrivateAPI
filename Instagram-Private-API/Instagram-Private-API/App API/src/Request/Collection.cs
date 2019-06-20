namespace Instagram_Private_API.src.Request
{
    class Collection
    {
        public static string getList()
        {
            Client.SendRequest("collections/list/");
            return Globals.LastResponse;
        }
    }
}
