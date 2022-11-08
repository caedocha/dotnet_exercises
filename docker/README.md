# HOW TO RUN THIS EXERCISE?

1. Build Docker image: 
`docker build . --tag=test_app`

2. Run Docker container with it: 
`docker run -p 8080:8080 test_app`

3. Open browser or curl make a request to this endpoint: 
`https://0.0.0.0:8080/weatherforecast`

4. Done
