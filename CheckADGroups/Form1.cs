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
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Eventing.Reader;

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
            AdGroupResultsBox_Formatting();
            string getUserText = userTextbox.Text;
            Cursor.Current = Cursors.WaitCursor;
            int getItemLocation = dropdownBox.SelectedIndex;

            bool isSearchSelectionValid = CheckSearchTypeSelection(getItemLocation);
            bool isFieldNullorEmpty = CheckNullorEmptyString(getUserText);
            bool isCharacterLengthValid = CheckUserCharacterLength(getUserText);

            bool isValid = performValidation(isSearchSelectionValid, isFieldNullorEmpty, isCharacterLengthValid, getUserText);

            if (isValid)
            {
                switch (getItemLocation)
                {
                    case 0:
                        getUsersADGroups(getUserText);
                        performValidation(isSearchSelectionValid, isFieldNullorEmpty, isCharacterLengthValid, getUserText);              
                        break;
                    case 1:
                        getUsersInGroup(getUserText);
                        performValidation(isSearchSelectionValid, isFieldNullorEmpty, isCharacterLengthValid, getUserText);       
                        break;
                    default:
                        break;
                }
            }

            Cursor.Current = Cursors.Default;
        }

        public bool performValidation(bool checkValidDropdown, bool checkNullorEmpty, bool checkValidSearch, string userText)
        {
            bool validationStatus = false;
            try
            {
                try
                {
                    if (checkValidDropdown == false)
                    {
                        throw new ArgumentNullException();
                    }
                }
                catch (ArgumentNullException ane)
                {
                    AdGroupResultsBox.Text = $"Invalid selection. Please select an option from the drop down field.\nError:{ane}";
                }

                try
                {
                    if (!checkNullorEmpty)
                    {
                        throw new ArgumentNullException();
                    }
                }
                catch (ArgumentNullException ane)
                {
                    if (!string.IsNullOrEmpty(AdGroupResultsBox.Text))
                    {
                        AdGroupResultsBox.AppendText($"\n\nPlease enter a userID. You entered {userText}. The field can NOT be blank.\nError:{ane}");

                    }
                    else
                    {
                        AdGroupResultsBox.Text = $"Please enter a userID. You entered {userText}. The field can NOT be blank.\nError:{ane}";
                    }
                }

                try
                {
                    if (!checkValidSearch)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    if (!string.IsNullOrEmpty(AdGroupResultsBox.Text))
                    {
                        AdGroupResultsBox.AppendText($"\n\n{userText} is an invalid CHR user or AD Group. Name is too short.\nError:{ex}");
                    }
                    else
                    {
                        AdGroupResultsBox.Text = $"{userText} is an invalid CHR user or AD Group. Name is too short.\nError:{ex}";
                    }
                }
                validationStatus = false;
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(AdGroupResultsBox.Text))
                {
                    AdGroupResultsBox.AppendText($"\n\nAdGroupResultsBox.Text = Form Fields Failed Validation.\n{ex}");
                }
                else
                {
                    AdGroupResultsBox.Text = $"Form Fields Failed Validation.\n{ex}";
                }

            }

            validationStatus = true;
            return validationStatus;

        }

        public void getUsersADGroups(string getUser)
        {
            // _checkADGroupsForm.
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
                                .Select(x => x.SamAccountName) // select the 7-letter
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

        public void getUsersInGroup(string getGroupName)
        {
            if (!string.IsNullOrEmpty(getGroupName))
            {
                try
                {
                    //get users
                    string[] getUsers = null;

                    using (var ctx = new PrincipalContext(ContextType.Domain))
                    using (var getGroups = GroupPrincipal.FindByIdentity(ctx, getGroupName))
                    {
                        if (ctx != null)
                        {
                            getUsers = getGroups.Members // this returns a collection of objects
                                .Select(x => x.SamAccountName) // select the 7letter
                                .ToArray(); // convert to string array
                        }
                        if (!string.IsNullOrEmpty(getUsers.ToString()))
                        {
                            Array.Sort(getUsers);
                            AdGroupResultsBox.Clear();
                            AdGroupResultsBox.Text = string.Join("\n", getUsers);
                        }
                    }
                }
                catch (NullReferenceException ex)
                {
                    AdGroupResultsBox.Text = $"{getGroupName} AD Group not found.\n\nError: {ex} not found";
                }
            }
        }
        public void AdGroupResultsBox_Formatting()
        {
            AdGroupResultsBox.Clear();
            AdGroupResultsBox.BackColor = Color.White;
        }

        public bool CheckSearchTypeSelection(int getItemLocation)
        {
            bool isTrueOrFalse = true;
            bool isSearchTypeSelected = false;


            if (getItemLocation >= 0)
            {
                isSearchTypeSelected = isTrueOrFalse;
            }
            return isSearchTypeSelected;
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
            return isCharacterLengthValid;
        }

        public bool CheckNullorEmptyString(string getUsername)
        {
            bool isUsernameLengthValid = string.IsNullOrEmpty(getUsername);
            bool isCharacterLengthValid = false;

            if (!isUsernameLengthValid)
            {
                bool isTrueOrFalse = true;
                isCharacterLengthValid = isTrueOrFalse;
            }
            return isCharacterLengthValid;
        }


        public void dropdownBox_Resize(object sender, EventArgs e)
        {
            int defaultDropdownBoxWidth = 142;
            int getdropdownBoxWidth = defaultDropdownBoxWidth;
            int listItemSize = dropdownBox.Text.Length + 10;
            int updateDropdownSize = getdropdownBoxWidth + listItemSize;

            if (getdropdownBoxWidth != updateDropdownSize)
            {
                dropdownBox.Width = defaultDropdownBoxWidth;
                dropdownBox.Width = updateDropdownSize;
            }

        }
    }
}

