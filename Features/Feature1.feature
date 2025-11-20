Feature: LoginPage



@LoginPage
Scenario: Login on EA website
	Given Navigate into website
	And Click on Login link 
	And Add username and password on related fields
		| UaserName | Password |
		| admin     | password |
	Then Succesfully login
