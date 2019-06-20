using Newtonsoft.Json.Linq;

namespace Instagram_Private_API.src.Request
{
    class Account
    {
        public static string RemoveProfilePicture()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest("accounts/remove_profile_picture/", data.ToString());
            return Globals.LastResponse;
        }

        public static string SetPrivate()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest("accounts/set_private/", data.ToString());
            return Globals.LastResponse;
        }

        public static string SetPublic()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            Client.SendRequest("accounts/set_public/", data.ToString());
            return Globals.LastResponse;
        }

        public static string ChangePassword(string oldPassword, string newPassword)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.old_password = oldPassword;
            data.new_password1 = newPassword;
            data.new_password2 = newPassword;

            Client.SendRequest("accounts/change_password/", data.ToString());
            return Globals.LastResponse;
        }

        public static string getCurrentUser()
        {
            dynamic data = new JObject();
            data.edit = true;
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.csrftoken;

            Client.SendRequest("accounts/current_user/", data.ToString());
            return Globals.LastResponse;
        }

        public static string checkUsername(string username)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data.username = username;
            data._csrftoken = Globals.csrftoken;
            data._uid = Globals.username_id;

            Client.SendRequest("users/check_username/", data.ToString());
            return Globals.LastResponse;
        }

        public static string enablePresence()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.disabled = "0";
            data._csrftoken = Globals.csrftoken;

            Client.SendRequest("accounts/set_presence_disabled/", data.ToString());
            return Globals.LastResponse;
        }

        public static string disablePresence()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.disabled = "1";
            data._csrftoken = Globals.csrftoken;

            Client.SendRequest("accounts/set_presence_disabled/", data.ToString());
            return Globals.LastResponse;
        }
    }
}
