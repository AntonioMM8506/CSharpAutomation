Feature: API Testing
    Test GET and POST methods in public API JSONPlaceholder

    @API
    Scenario: Verify API Response
        Given I have a URL "https://jsonplaceholder.typicode.com/posts/1"
        When I send a GET request to the API
        Then the response status code should be "200"
    


    @API
    Scenario Outline: Test POST Request
        Given I have a valid payload to send
        When I send a POST request to "https://jsonplaceholder.typicode.com/posts"
        Then the response status code should be <expectedStatusCode>
        And the response body should contain <expectedContent>
    Examples:
    | expectedStatusCode | expectedContent      |
    | 200                | "success"            |
    | 400                | "error"              |