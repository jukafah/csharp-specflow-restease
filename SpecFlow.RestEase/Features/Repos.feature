Feature: Repos
  As a Consumer of the GitHub Repos endpoint,
  I can retrieve data about Repositories
  
  Scenario: List user repositories - returns repositories
    Given username "jukafah"
    When I get a list of repositories
    Then repository "csharp-specflow-restease" is in the list
    
  Scenario: List user repositories - handles not found
    Given username "blargblablargblarg"
    When I get repositories
    Then the repos endpoint returns not found
    
  Scenario: List user repositories - sort by created - ascending
    Given username "jukafah"
    And query parameters
      | Parameter | Value     |
      | sort      | created   |
      | direction | asc       |
    When I get a list of repositories
    Then repositories are sorted by when they were created in ascending direction

  Scenario: List user repositories - sort by created - defaults to descending
    Given username "jukafah"
    And query parameters
      | Parameter | Value   |
      | sort      | created |
    When I get a list of repositories
    Then repositories are sorted by when they were created in descending direction
    
  Scenario: List user repositories - sort by updated - ascending
    Given username "jukafah"
    And query parameters
      | Parameter | Value     |
      | sort      | updated   |
      | direction | asc       |
    When I get a list of repositories
    Then repositories are sorted by last updated in ascending direction
    
  Scenario: List user repositories - sort by updated - defaults to descending
    Given username "jukafah"
    And query parameters
      | Parameter | Value   |
      | sort      | updated |
    When I get a list of repositories
    Then repositories are sorted by last updated in descending direction
    
  Scenario: List user repositories - sort by pushed - ascending
    Given username "jukafah"
    And query parameters
      | Parameter | Value   |
      | sort      | pushed  |
      | direction | asc     |
    When I get a list of repositories
    Then repositories are sorted by last pushed in ascending direction
    
  Scenario: List user repositories - sort by pushed - defaults to descending
    Given username "jukafah"
    And query parameters
      | Parameter | Value   |
      | sort      | pushed  |
    When I get a list of repositories
    Then repositories are sorted by last pushed in descending direction
    
  Scenario: List user repositories - sort by full name - defaults to ascending
    Given username "jukafah"
    And query parameters
      | Parameter | Value     |
      | sort      | full_name |
    When I get a list of repositories
    Then repositories are sorted by full name in ascending direction
    
  Scenario: List user repositories - sort by full name - descending
    Given username "jukafah"
    And query parameters
      | Parameter  | Value     |
      | sort       | full_name |
      | direction  | desc      |
    When I get a list of repositories
    Then repositories are sorted by full name in descending direction
    
  Scenario: List user repositories - type - by all
    Given username "jukafah"
    And query parameters
      | Parameter | Value |
      | type      | all   |
    When I get a list of repositories
    Then the list contains repositories not owned by user "jukafah"
    And the list contains repositories owned by user "jukafah"
    
  Scenario: List user repositories - type - by owner
    Given username "jukafah"
    And query parameters
      | Parameter | Value |
      | type      | owner |
    When I get a list of repositories
    Then the list only contains repositories owned by user "jukafah"
    
  Scenario: List user repositories - type - by member
    Given username "jukafah"
    And query parameters
      | Parameter | Value   |
      | type      | member  |
    When I get a list of repositories
    Then the list only contains repositories not owned by user "jukafah"
    
  Scenario: List user repositories - type - defaults to owner
    Given username "jukafah"
    When I get a list of repositories
    Then the list only contains repositories owned by user "jukafah"
    
  Scenario: List all public repositories - returns all public repositories in order they were created
    When I get a list of all public repositories
    Then the list contains repositories sorted by date created
    
  Scenario: List all public repositories - returns all public repositories in order they were created since last repository id viewed
    Given query parameters
      | Parameter | Value |
      | since     | 2000  |
    When I get a list of all public repositories
    Then the list contains repositories starting with id "2000"
    And the list contains repositories sorted by date created
    
  Scenario: List all public repositories - basic information is available
    When I get a list of all public repositories
    Then the list of repositories have basic information available
    