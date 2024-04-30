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
        [Given(@"I have created new users with id as ""([^""]*)"" name as ""([^""]*)"" role as ""([^""]*)"" and email as ""([^""]*)""")]
        public void GivenIHaveCreatedNewUsersWithIdAsNameAsRoleAsAndEmailAs(int id, string name, string role, string email)
        {
            Assert.IsTrue(UsersPageObject.CreateUsers(id, name, role, email));
        }


        [Then(@"Validate user exist with id as ""([^""]*)"" name as ""([^""]*)"" role as ""([^""]*)"" and email as ""([^""]*)""")]
        public void ThenValidateUserExistWithIdAsNameAsRoleAsAndEmailAs(int id, string name, string role, string email)
        {
            Assert.IsTrue(UsersPageObject.GetUsers(id, name, role, email));
        }

       
        [Then(@"Update user mail from ""([^""]*)"" to (.*) for user id as ""([^""]*)""")]
        public void ThenUpdateUserMailFromToUpdatednewmailGmail_ComForUserIdAs(string email,string newEmailAddress, int id)
        {
            Assert.IsTrue(UsersPageObject.UpdateUser(id, newEmailAddress));
        }

        [Then(@"Validate Mail is updated to (.*) for user with id as ""([^""]*)""")]
        public void ThenValidateMailIsUpdatedForUserWithIdAs(string newEmailAddress, int id)
        {
           Assert.IsTrue(UsersPageObject.GetUsers(id).Contains(newEmailAddress));
        }

        [Then(@"Delete the user with id as ""([^""]*)""")]
        public void ThenDeleteTheUserWithIdAs(int id)
        {
            Assert.IsTrue(UsersPageObject.DeleteUser(id));
        }

       
        [Then(@"Validate user is deleted with id as ""([^""]*)"" name as ""([^""]*)"" role as ""([^""]*)"" and email as ""([^""]*)""")]
        public void ThenValidateUserIsDeletedWithIdAsNameAsRoleAsAndEmailAs(int id, string name, string role, string email)
        {
            Assert.IsTrue(UsersPageObject.GetUsers(id, name, role, email));
        }


    }
}
