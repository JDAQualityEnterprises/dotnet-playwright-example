Feature: JDA Quality Enterprises website home page
User should able to view JDA home page with correct details
Note: these examples are just to demonstrate framework structure 

@sanity
Scenario: Home page has correct title
    Given User has site details
    When User navigates to the home page
    Then the correct title is displayed for the home page

Scenario: Home page has correct links
    Given User has site details
    When User navigates to the home page
    Then the navigation links are correct
    And the email is displayed correctly
