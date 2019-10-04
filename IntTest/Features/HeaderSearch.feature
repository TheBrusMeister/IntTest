Feature: SearchResults
	In order to ensure that job searches can be done
	As a candidate
	I want to make multiple searches of different variations


Scenario Outline: Perform key search types
	Given I am on the TotalJobs search results page
	When I perform a search with <keyword>, <location>, <radius>
	Then the results page should be present

Examples: 
	| keyword | location | radius |
	| Tester  |          |        |
	|         | London   |        |
	| Tester  | London   |        |
	| Tester  | London   | 20     |
