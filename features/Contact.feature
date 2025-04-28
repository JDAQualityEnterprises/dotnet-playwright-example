Feature: JDA Quality Enterprises website contact page
User should able to view JDA contact page with correct details
Note: these examples are just to demonstrate framework structure

@sanity
Scenario: Contact page has correct title
    Given User has site details
    When User navigates to the contact page
    Then the correct title is displayed for the contact page

Scenario: Contact page has correct links
    Given User has site details
    When User navigates to the contact page
    And the contact email is displayed correctly