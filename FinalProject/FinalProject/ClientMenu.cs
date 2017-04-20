﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class ClientMenu : Form
    {
        private ClientController _c;

        public ClientMenu(ClientController c)
        {
            _c = c;
            InitializeComponent();
            uxRemoveContact.Enabled = false;
            uxStartChat.Enabled = false;

        }

        private void uxLogout_Click(object sender, EventArgs e)
        {
            // Call server to update status to offline
            // Close form
        }

        private void uxRemoveContact_Click(object sender, EventArgs e)
        {
            // Update contact list in server
            // Update Model
            // Update ListBox
        }

        private void uxAddContact_Click(object sender, EventArgs e)
        {
            // Check to see if user exists in server
            // If so add to contact list in server
            // Update ListBox
        }

        private void uxStartChat_Click(object sender, EventArgs e)
        {
            // Check to see if online
            // Lauch chat form
        }
    }
}