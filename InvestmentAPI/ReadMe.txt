Here's my working API for the Investment coding challenge. This was really fun to do and I actually learned quite a bit. I had a bit of a bump in the road because I had
the whole thing working on Saturday and was trying to understand how to get my changes submitted in git and I deleted the branch that had all of my work on it (long story). So I had
to do this projects TWO times, but that's okay because it was a good learning exercise. A couple of notes about the project:

- There's probably a much slicker way to set up the test data and there's not a defined schema but I went with what I could get to work and I wanted to focus on the API code.
- The test data is generated each time you run the API so you can hit an endpoint right away.
- To get the list of investments for our test user, use this endpoint: https://localhost:5001/api/investment/100 - The user ID for the test data is 100.
- For the second endpoint, you can pick any Id that gets returned from the list of investments. An example would look like: https://localhost:5001/api/investment/detail/3
- Feel free to use Chrome or Postman to test the API, but if you use Postman make sure to turn off SSL certs.
- I started to make some unit tests, but I was having trouble getting a few things set up so I let them be. Having to redo the whole thing set me back and I wanted to get this to y'all by Monday.
- If I had more time I would focus on getting the unit tests working properly as I've been writing tests in my current job.

Really appreciate the opportunity to submit this and hopefully chat to the team soon. Thanks!