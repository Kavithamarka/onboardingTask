Feature: EditLanguage
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario:Edit the language entry
	Given I clicked on language tab under Profile page
	And I Clicked on edit button of already entered language
	When I change the level of language
	And clicked on update button
	Then the table is updated with change

