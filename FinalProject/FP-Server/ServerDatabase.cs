﻿using FP_Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FP_Server
{
    public class ServerDatabase
    {

        List<Observer> _registry = new List<Observer>();

        private Dictionary<string, User_m> _userDatabase;

        private List<ChatRoom> _chatRoom;

        private Dictionary<string, bool> _onLine;

        private Dictionary<int, KeyValuePair<List<string>, List<string>>> d;

        private Dictionary<string, string> _userPairing;





        private int count = 0;

       // private 




        public ServerDatabase()
        {
            
            _userDatabase = new Dictionary<string, User_m>();
            _onLine = new Dictionary<string, bool>();
            AddPerson();
            //ReadFromFile();
            //WriteToFile();
            _chatRoom = new List<ChatRoom>();
            _userPairing = new Dictionary<string, string>();
            d = new Dictionary<int, KeyValuePair<List<string>, List<string>>>();
            
        }

        

        private void AddPerson()
        {
            Dictionary<string, bool> a = new Dictionary<string, bool>();
            Dictionary<string, bool> m = new Dictionary<string, bool>();

            a.Add("mhixon", true);
            a.Add("Jason", false);
            a.Add("Steven", false);
            m.Add("sriegodedios", true);
            m.Add("Jason", false);
            m.Add("Steven", false);
            _userDatabase.Add("sriegodedios", new User_m("sriegodedios", "shaner26", a));
            _userDatabase.Add("mhixon", new User_m("mhixon", "matt555", m));

            _onLine.Add("Shane", true);
            _onLine.Add("Jason", true);
            _onLine.Add("Steven", false);


        }

        public Dictionary<string,bool> GetContacts(string id)
        {

           return _userDatabase[id].GetContacts;

        }

        

        private void WriteToFile()
        {
            string jsonString = JsonConvert.SerializeObject(_userDatabase);

            using (StreamWriter sw = new StreamWriter("users.json"))
            {
                sw.Write(jsonString);
            }
            
           // Dictionary<string, User_m> m = JsonConvert.DeserializeObject<Dictionary<string, User_m>>(jsonString);

        }

       /// <summary>
       /// This method reads from the jsonfile and adds it to the database.
       /// </summary>
        private void ReadFromFile()
        {
            using (StreamReader file = new StreamReader("users.json"))
            {
                string jsonString = file.ReadToEnd();
                _userDatabase = JsonConvert.DeserializeObject<Dictionary<string, User_m>>(jsonString);
              
            }
        }

        /// <summary>
        /// This method adds the user to the database if the user makes a new account
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void AddUser(string username, string password, string Id)
        {
            User_m user = new User_m(username, password, new Dictionary<string,bool>());
            user.GetID = Id;
            _userPairing.Add(username, Id);
            _userDatabase.Add(username, user);

        }




        /// <summary>
        /// Checks if the user exsist
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool CheckUser(string username)
        {
            return _userDatabase.ContainsKey(username);
        }



        /// <summary>
        /// Checks if the password is correct
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool PasswordValidation(string username, string password)
        {
            string dbPassword = _userDatabase[username].Password;

            if(password == dbPassword)
            {
                return true;
            }

            return false;
        }

        public Dictionary<string, User_m> AllUsers
       {

            get
            {
                return _userDatabase;
            }

        }

        

        public string LookUpUserBaseOnID(string s)
        {

            foreach(KeyValuePair<string, User_m> KVP in _userDatabase)
            {

                if(s == KVP.Value.GetID)
                {
                    return KVP.Key;
                }


            }
            return null;



        }

        public void MakeUserOnline(string s)
        {
            _onLine.Add(s, true);
        }

        public void MakeUserOffline(string s)
        {
            _onLine[s] = false;

        }

        /// <summary>
        /// Checks to see if the user is online
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsUserOnline(string s)
        {
            return _onLine[s];
        }

        /// <summary>
        /// Create a new chatroom
        /// </summary>
        /// <param name="user"></param>
        /// <param name="destinationuser"></param>
        public void MakeChatRoom(string user, string destinationuser)
        {


            ChatRoom c = new ChatRoom(count);

            //Adds the users
            c.AddUser(user);
            c.AddUser(destinationuser);

            _chatRoom.Add(c);
            count++;

        }

        /// <summary>
        /// Adds a message to the chatroom
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        public void AddMessageToChatRoom(int id, string message)
        {
            _chatRoom[id].AddMessage(message);

        }


        /// <summary>
        /// Gets the message history of the chatroom
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<string> GetMessageHistory(int id)
        {
            return _chatRoom[id].MessageHistory;
        }

        public int GetChatroomID
        {
            get
            {
                return count;
            }
           
        }

        public List<string> GetUsersChat(int i)
        {
            return _chatRoom[i].GetUsers;
        }

        public Dictionary<int, KeyValuePair<List<string>, List<string>>> GetChatRoomData(int i)
        {
            //Dictionary<int, KeyValuePair<List<string>, List<string>>> d = new Dictionary<int, KeyValuePair<List<string>, List<string>>>();

            KeyValuePair<List<string>, List<string>> kvp = new KeyValuePair<List<string>, List<string>>(GetUsersChat(i), GetMessageHistory(i));

            d.Add(i, kvp);

            return d;



        }

        public int GetChatRoomUserCount(int id)
        {
            return _chatRoom[id].NumberOfUsers;
        }


        public string GetID(string username)
        {
            return _userPairing[username];
        }

      
    }

}
