using APITestCaseCreationProject.PageObjects;
using NUnit.Framework;
using System;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace APITestCaseCreationProject.StepDefinitions
{
    [Binding]
    public class AddingUsersStepDefinitions
    {       
        [Given(@"I have created new users with id as '([^']*)' name as '([^']*)' role as '([^']*)' and email as '([^']*)'")]
        public void GivenIHaveCreatedNewUsersWithIdAsNameAsRoleAsAndEmailAs(int id, string name, string role, string email)
        {
            Assert.IsTrue(UsersPageObject.CreateUsers(id, name, role, email));
        }

        
        [Then(@"Validate user exist with id as '([^']*)' name as '([^']*)' role as '([^']*)' and email as '([^']*)'")]
        public void ThenValidateUserExistWithIdAsNameAsRoleAsAndEmailAs(int id, string name, string role, string email)
        {
            Assert.IsTrue(UsersPageObject.GetUsers(id, name, role, email));
        }


        [Then(@"Update user mail to (.*) for user id as '([^']*)' name as '([^']*)' role as '([^']*)' and email as '([^']*)'")]
        public void ThenUpdateUserMailToUpdatednewmailGmail_ComForUserIdAsNameAsRoleAsAndEmailAs(string newEmail,int id, string name, string role, string email)
        {
            Assert.IsTrue(UsersPageObject.UpdateUser(id,name, role,email, newEmail));
        }


        [Then(@"Validate Mail is updated to (.*) for user with id as '([^']*)'")]
        public void ThenValidateMailIsUpdatedToUpdatednewmailGmail_ComForUserWithIdAs(string newEmailAddress, int id)
        {
            Assert.IsTrue(UsersPageObject.GetUsers(id, newEmailAddress));
        }
       

        [Then(@"Delete the user with id as '([^']*)'")]
        public void ThenDeleteTheUserWithIdAs(int id)
        {
            Assert.IsTrue(UsersPageObject.DeleteUser(id));
        }

      
        [Then(@"Validate user is deleted with id as '([^']*)' name as '([^']*)' role as '([^']*)' and email as '([^']*)'")]
        public void ThenValidateUserIsDeletedWithIdAsNameAsRoleAsAndEmailAs(int id, string name, string role, string email)
        {
            Assert.IsTrue(UsersPageObject.GetUsers(id, name, role, email));
        }


    }
}
