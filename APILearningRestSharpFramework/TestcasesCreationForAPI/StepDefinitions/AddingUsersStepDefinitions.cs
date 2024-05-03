using APICreationBL.Utils;

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
            var responce=PostUtils.CreatePost(id, name, role, email);
            Assert.AreEqual( id, responce.id);
        }

        
        [Then(@"Validate user exist with id as '([^']*)' name as '([^']*)' role as '([^']*)' and email as '([^']*)'")]
        public void ThenValidateUserExistWithIdAsNameAsRoleAsAndEmailAs(int id, string name, string role, string email)
        {
            var responce = PostUtils.CreateGet(id);
            Assert.AreEqual(id, responce.id);
        }


        [Then(@"Update user mail to (.*) for user id as '([^']*)' name as '([^']*)' role as '([^']*)' and email as '([^']*)'")]
        public void ThenUpdateUserMailToUpdatednewmailGmail_ComForUserIdAsNameAsRoleAsAndEmailAs(string newEmail,int id, string name, string role, string email)
        {
            var responce = PostUtils.CreatePUT(id,name,role,email,newEmail);
            Assert.AreEqual( newEmail, responce.email);
           
        }


        [Then(@"Validate Mail is updated to (.*) for user with id as '([^']*)'")]
        public void ThenValidateMailIsUpdatedToUpdatednewmailGmail_ComForUserWithIdAs(string newEmailAddress, int id)
        {
            var responce = PostUtils.CreateGet(id);
            Assert.AreEqual(newEmailAddress, responce.email);
        }
       

        [Then(@"Delete the user with id as '([^']*)'")]
        public void ThenDeleteTheUserWithIdAs(int id)
        {
            var responce = PostUtils.CreateDelete(id);
            Assert.IsTrue(responce);
        }

      
        [Then(@"Validate user is deleted with id as '([^']*)' name as '([^']*)' role as '([^']*)' and email as '([^']*)'")]
        public void ThenValidateUserIsDeletedWithIdAsNameAsRoleAsAndEmailAs(int id, string name, string role, string email)
        {
            var responce = PostUtils.CreateGet(id).ToString();
            Assert.IsTrue(responce.Length == 0);
        }


    }
}
