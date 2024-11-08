@Chrome

Feature: Weather Forecast for Bournemouth

  Scenario: Verify tomorrow's high temperature is greater than the low temperature
  Given I have navigated to the BBC Weather website
    When I search for '<City>'
    Then I should see the weather forecast for tomorrow
    And the high temperature should be greater than the low temperature
    Examples: 
    | City        |
    | Bournemouth |