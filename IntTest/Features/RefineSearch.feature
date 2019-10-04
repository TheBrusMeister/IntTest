Feature: RefineSearch
	In order to ensure that I can perform searches from the explore results search bars
	As a candidate
	I want to be able to perform searches of different variations

Scenario Outline: Perform key search types via refine search
	Given I am on the TotalJobs search results page
	When I perform a search via refine search with <keyword>, <location>, <radius>
	Then the results page should be present

Examples: 
	| keyword | location | radius |
	| Tester  |          |        |
	|         | London   |        |
	| Tester  | London   |        |
	|         | London   | 20     |
	| Tester  | London   | 20     |
