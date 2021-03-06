﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    //Packet class
    public class Packet
    {
        private Status _status;
        private string _username;
        private string _password;
        private string _message;
        private List<string> _messageHistory;
        private Dictionary<string,bool> _contactList;
        private string _destinationID;
        private string _destinationUsername;
        private string _originID;
        private string _ID;
        private int _chatRoomID;
        private Dictionary<int, KeyValuePair<List<string>, List<string>>>_chatData;

        /// <summary>
        /// Constructor for the Packet class
        /// </summary>
        /// <param name="status">status of packet being processed</param>
        public Packet(Status status)
        {
            _status = status;
            _messageHistory = new List<string>();
        }

        //Gets/Sets the user status
        public Status GetStatus
        {
            get
            {
                return _status;
            }set
            {
                _status = value;
            }
        }

        /// <summary>
        /// This is property for the username
        /// </summary>
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        /// <summary>
        /// This is the property for the password
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        /// <summary>
        /// This is the property for the Message
        /// </summary>
        public string Message
        {
            get
            {
                return _message;
            }set
            {
                _message = value;
            }
        }

        /// <summary>
        /// This is property for the MessageList
        /// </summary>
        public List<string> MessageHistory
        {
            get
            {
                return _messageHistory;

            }set
            {
                _messageHistory = value;
            }
        }

        /// <summary>
        /// This is a property for the contact list
        /// </summary>
        public Dictionary<string,bool> ContactList
        {
            get
            {
                return _contactList;
            }set
            {
                _contactList = value;
            }
        }

        public string OriginID
        {
            get{
                return _originID;
            }set{
                _originID = value;
            }
        }

        public string DestinationID
        {
            get{
                return _destinationID;
            }set{
                _destinationID = value;
            }
        }


        public string DestinationUsername
        {
            get
            {
                return _destinationUsername;
            }
            set
            {
                _destinationUsername = value;
            }
        }

        public string GetID
        {
            get{
                return _ID;

            }set{
                _ID = value;
            }
        }

        public int GetChatID
        {

            get
            {
                return _chatRoomID;

            }set
            {
                _chatRoomID = value;
            }

        }

        public Dictionary<int, KeyValuePair<List<string>, List<string>>> ChatData
        {

            get
            {
                return _chatData;
            }set
            {
                _chatData = value;
            }
        }





       








    }
}
