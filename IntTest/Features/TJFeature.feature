Feature: TJFeature
	On the Totaljobs homepage, do a search for a Tester of at least £30,000 annually, based in London and is permanent returns results

Scenario Outline: Results displayed for advanced search
	Given I am on the Total Jobs homepage
	When I make a search with details <Role>, <Location>, <Radius>
	And I add additional criteria <salary>, <salaryAmount>, <jobType>, <recruiterType>
	And I click the search button
	Then I am shown job results https://www.totaljobs.com/jobs/tester/in-london?salary=30000&salarytypeid=1&radius=10

	Examples: 
	| Role   | Location | Radius   | salary | salaryAmount | jobType | recruiterType |
	| Tester | London   | 10 miles | Annual | 30000        | All     | Any           |

Scenario Outline: Results based on extra search criteria
	Given I am on the Total Jobs homepage
	When I make a search with details <Role>, <Location>, <Radius>
	And I add additional criteria <salary>, <salaryAmount>, <jobType>, <recruiterType>
	And I click the search button
	Then I am shown job results https://www.totaljobs.com/jobs/permanent/software-engineer/in-london?salary=30000&salarytypeid=1&radius=0

	Examples: 
	| Role              | Location | Radius  | salary | salaryAmount | jobType   | recruiterType |
	| Software Engineer | London   | 0 miles | Annual | 30000        | Permanent | Any           |