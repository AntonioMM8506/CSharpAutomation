Feature: Upload a Document
    User tries to upload a document.

    @Guru99
    Scenario: Validate user can upload a document
        Given User navigates to Demo Guru 99
        When User navigates to "File Upload" Selenium section
        Then User uploads a document
