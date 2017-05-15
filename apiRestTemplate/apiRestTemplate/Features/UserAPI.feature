Feature: UserAPI
	In order to test a REST API
	As an automation tester
	I want to have some tools available

@user @get
Scenario: Get existing users
	Given I have access to the server
	When I request the list of users
	Then The OK status should be returned

Scenario: Create new user
	Given I have access to the server
	When I create a new user
	Then The CREATED status should be returned
	
