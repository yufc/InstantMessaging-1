﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
        public enum Status {
            loginValidate,              //0
            connectionSuccess,          //1
            loginTrue,                  //2
            loginFalse,                 //3
            onlineValidate,             //4
            onlineTrue,                 //5
            onlineFalse,                //6
            messageSend,                //7
            messageReceive,             //8
            messageHistory,             //9
            messageHistorySend,         //10
            contactListRequest,         //11
            contactListSend,            //12
            contactListUpdatedClient,   //13
            contactListExcuteCode,      //14
            requestChatRoom,            //15
            chatroomSuccess,            //16
            logout,                     //17
            undefined                   //18
    };
    
}
