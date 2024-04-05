Feature: Google Search
    As a user
    I want to perform a search on Google
    So that I can find relevant information

    @GoogleSearch
    Scenario: Perform a Google search
        Given I am on the Google search page
        When I enter "WarHammer 40000" into the search box
        And I click the search button
        #Then I should see results for 42,400,000
    
    @GoogleSearch
    Scenario Outline: Perform multiple Google searches
        Given I am on the Google search page
        When I enter <toLookFor> into the search box
        And I click the search button
    Examples:
    | toLookFor  |
    | Spawn      |
    | Batman     |
    | Spiderman  |