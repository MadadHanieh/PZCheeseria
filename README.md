# PZCheeseria
Follow these steps to run this app in docker container
 1. Open a command prompt and navigate to your project folder (folder that contains Dockerfile)
 2. Run the following commands to build and your docker image
    <br/> `docker build -t pzcheeseriaimage . `
    <br/> `docker run -d -p 8080:80  --name pzcheeseriacontainer pzcheeseriaimage`
 3. Now go to `localhost:8080` to access this app in a web browser. The main page will show the API documentation in swaggerUI.
 
