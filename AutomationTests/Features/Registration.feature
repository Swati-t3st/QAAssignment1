Feature: User Registration
  As a new user
  I want to create an account on the Magento website
  So that I can access the website's features

  Scenario: Successful account creation
    Given I navigate to the Magento registration page
    When I create an account with email "testuser@example.com" and password "Password123"
    Then I should see a confirmation message indicating successful account creation