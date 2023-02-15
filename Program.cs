using InstagramPrivateAPI.src;

Client client = new Client();
String username = "";
string password = "";
client.Login(username, password);

Console.WriteLine(client.timeline.GetTimelineFeed());