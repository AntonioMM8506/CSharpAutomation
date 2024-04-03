Feature: Populates form with Excel data
    As a user, I want to read from an excel file, copy its data and paste it into a text area.

@ReadExcel
Scenario: User fulfills text area form with excel data
    Given user navigates to online text editor
    When user fulfills the form with the excel data
    