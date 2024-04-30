Feature: Adding users


It will create new users and perform operations on users api 

@UserCreation @GetUserInfo
Scenario Outline: Creating new users and get new user
	Given I have created new users with id as "id" name as "name" role as "role" and email as "email"
	Then Validate user exist with id as "id" name as "name" role as "role" and email as "email"
	Then Update user mail from "email" to updatednewmail@gmail.com for user id as "id"
	And Validate Mail is updated to updatednewmail@gmail.com for user with id as "id"
	And Delete the user with id as "id"
	And Validate user is deleted with id as "id" name as "name" role as "role" and email as "email"
	Examples: 
	| id  | name     | role          | email           |	
	| 11  | "Joy"   | "Developer"   | abc11@gmail.com" |
	
	
