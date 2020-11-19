using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;

namespace CheckADGroups
{
    public partial class CheckADGroupsForm : Form
    {
        public CheckADGroupsForm()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            AdGroupResultsBox_Formatting(sender, e);

            string getUser = userTextbox.Text;
            Cursor.Current = Cursors.WaitCursor;


            bool isCharacterLengthValid = CheckUserCharacterLength(getUser);

            if (isCharacterLengthValid == true)
            {
                if (!string.IsNullOrEmpty(getUser))
                {
                    try
                    {
                        //get ad groups
                        string[] getADGroups = null;

                        using (var ctx = new PrincipalContext(ContextType.Domain))
                        using (var adUser = UserPrincipal.FindByIdentity(ctx, getUser))
                        {
                            if (adUser != null)
                            {
                                getADGroups = adUser.GetGroups() // this returns a collection of objects
                                    .Select(x => x.SamAccountName) // select the login name
                                    .ToArray(); // convert to string array
                            }
                            if (!string.IsNullOrEmpty(getADGroups.ToString()))
                            {
                                Array.Sort(getADGroups);
                                AdGroupResultsBox.Clear();
                                AdGroupResultsBox.Text = string.Join("\n", getADGroups);
                            }
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        AdGroupResultsBox.Text = $"User {getUser} not found.\n\nError: {ex} not found";
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        public void AdGroupResultsBox_Formatting(object sender, EventArgs e)
        {
            AdGroupResultsBox.Clear();
            AdGroupResultsBox.BackColor = Color.White;
        }

        public bool CheckUserCharacterLength(string getUsername)
        {
            int getUsernameLength = getUsername.Length;
            bool isTrueOrFalse = false;
            bool isCharacterLengthValid = false;

            if (getUsernameLength > 4 && isTrueOrFalse == false)
            {
                isTrueOrFalse = true;
                isCharacterLengthValid = isTrueOrFalse;
            }

            if (!isCharacterLengthValid)
            {
                AdGroupResultsBox.Text = $"{getUsername} is an invalid CHR user. Username is too short.";
            }

            return isCharacterLengthValid;
        }
    }
}

