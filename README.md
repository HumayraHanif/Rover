# Rover Submission

## Answer to questions:

1. In the assessment did you easily understand what was asked of you?

Yes, I had some confusion over the mapping part, but once i read it a few times it was a bit cleaer to me. 

2. In the assessment did you feel 2 hours was sufficient in completing the task?

No, I think with reading a few times, and thinking of test cases this took me longer than 2 hours. 3 hours is more accurate, again this is based on the number of test scenarios to think of.

3. Given more time was there any particular area you thought you could improve?
- Logging
- More detailed error handling
- Validating inputs, e.g. if the command string had "illegal characters", starting coordinates weren't on the grid etc..
- Splitting the `RoverMover.cs` out a bit more so there isn't too much code involved within the one class.
- Use IoC on some of the interfaces

4. Do you have any thoughts or feedback you would like to provide for this
assessment?
- It was an interesting problem to solve. Just the time expectation probably could be a bit larger.

## To run

Make sure nuget packages are updated.
I've created an API, although a console program also might've worked.
The solution can be tested through unit testing. I've also added swagger docs in case it needs to be tested directly. 

I've left unit tests without shared setup code as I think this can help with readability in this scenario.

Example POST Body:
````
{
  "startingPosition": {
    "x": 0,
    "y": -3
  },
  "facingDirection": "N",
  "command": "RRBB",
  "gridDimensions": {
    "x": 10,
    "y": 10
  },
  "obstacles": [
    {
      "x": 3,
      "y": 0
    },{
      "x": -2,
      "y": 0
    },{
      "x": 4,
      "y": -3
    },{
      "x": 0,
      "y": -1
    }
  ]
}
`````