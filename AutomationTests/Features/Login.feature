Feature: User Login
  As a registered user
  I want to log in to my account on the Magento website
  So that I can access my account features

  Scenario: Successful login
    Given I navigate to the Magento login page
    When I sign in with email "bellaniswati@gmail.com" and password "ShivSai@1019"
    Then I should be logged in and see my account dashboard
