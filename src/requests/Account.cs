using InstagramPrivateAPI.src.responses;
using InstagramPrivateAPI.src.responses.accounts;
using InstagramPrivateAPI.src.responses.users;
using Newtonsoft.Json.Linq;

namespace InstagramPrivateAPI.src.requests
{
    internal class Account
    {
        public void ChangeProfilePicture()
        {
            //TODO
        }

        public UserResponse RemoveProfilePicture()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<UserResponse>("accounts/remove_profile_picture/", data.ToString());
        }

        public UserResponse SetPrivate()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<UserResponse>("accounts/set_private/", data.ToString());
        }

        public UserResponse SetPublic()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;

            return Request.Send<UserResponse>("accounts/set_public/", data.ToString());
        }

        public Response ChangePassword(string oldPassword, string newPassword)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data._csrftoken = Globals.token;
            data.old_password = oldPassword;
            data.new_password1 = newPassword;
            data.new_password2 = newPassword;

            return Request.Send<Response>("accounts/change_password/", data.ToString());
        }

        //public  string getCurrentUser()
        //{
        //    dynamic data = new JObject();
        //    data.edit = true;
        //    data._uuid = Globals.uuid;
        //    data._uid = Globals.username_id;
        //    data._csrftoken = Globals.csrftoken;

        //    Request.Send<String>("accounts/current_user/", data.ToString());
        //    return Globals.LastResponse;
        //}

        public CheckUsernameResponse checkUsername(string username)
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data.username = username;
            data._csrftoken = Globals.csrftoken;
            data._uid = Globals.username_id;

            return Request.Send<CheckUsernameResponse>("users/check_username/", data.ToString());
        }

        public Response enablePresence()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.disabled = "0";
            data._csrftoken = Globals.csrftoken;

            return Request.Send<Response>("accounts/set_presence_disabled/", data.ToString());
        }

        public Response disablePresence()
        {
            dynamic data = new JObject();
            data._uuid = Globals.uuid;
            data._uid = Globals.username_id;
            data.disabled = "1";
            data._csrftoken = Globals.csrftoken;

            return Request.Send<Response>("accounts/set_presence_disabled/", data.ToString());
        }
    }
}
