Feature: SpecFlowFeature3
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: multiple entries for language 
	Given I have entered url, logged in and clicked on Profile tab
	And I have clicked on addNew button and enter <language> 
	When I clicked on add button
	Then the languages showed in the table

	Examples: 
	| language |
	| Telugu   |
	| Hindi    |
	| English  |
	| Tamil    |

	