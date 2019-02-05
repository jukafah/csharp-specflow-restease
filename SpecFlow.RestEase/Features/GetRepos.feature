Feature: Get Repos,
  As a Consumer of the Repos endpoint,
  I can retrieve data about Repositories
  
  @repos
  Scenario: List user repositories - type - default returns user owned repos
#    Given the github api "https://api.github.com"
    When I get repos of "jukafah"
    Then the list of repos contains
      | Attribute       | Value |
      | Name            |       |
      | Full Name       |       |
      | Owner           |       |
      | Description     |       |
      | Url             |       |
      | Html Url        |       |
      | Default Branch  |       |
      | Has Projects    |       |
    
  Scenario: List user repositories - type - return repos user is member of
    
  Scenario: List user repositories - type - return all user repos
    
  Scenario: List user repositories - type - handles invalid option
    
  Scenario: List user repositories - sort - default returns when created in descending order
    
  Scenario: List user repositories - sort - by last updated
    
  Scenario: List user repositories - sort - by last pushed
    
  Scenario: List user repositories - sort - by full name
    
  Scenario: List user repositories - sort - handles invalid option
    
  Scenario: List user repositories - direction - ascending
    
  Scenario: List user repositories - direction - descending
    
  Scenario: List user repositories - direction - settings sort full name defaults direction to ascending
    
  Scenario: List user repositories - direction - handles invalid option
    
  Scenario: List user repositories - not found - is handled
    
  Scenario: List all public repositories - returns all public repositories
    
  Scenario: List all public repositories - returns all public repositories since last repository id viewed