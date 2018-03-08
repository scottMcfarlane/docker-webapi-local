Web Api Local
=====
[![Build Status](https://travis-ci.org/scottMcfarlane/docker-webapi-local.svg?branch=master)](https://travis-ci.org/scottMcfarlane/docker-webapi-local)

## What's the purpose?

If you are developing a microservice that has to call external API's, if you would have felt a pain.

If you are not, this is the time to close this window and move on.

The pain, being referred here is the need to call an external API and perform some action on the response, which can result in inconsistent and unpredictable results.


To overcome this issue, the approach we've previously taken was to Mock the API using application code to unit and integration tests.

The limitation with mocking the API using application code is, the need to write that application code. Chances of testing the correct boundaries or strain in the layer when to use mock vs not mock are all practical side affects of this system.

## What is the solution?
Running the API server locally along with your application in the same stack. Except, make it easy.

## How does this makes 'running the API locally' easy?

Follow the trail below to get the answer.


#### How to run an API locally?

`docker run scottMcfarlane/docker-webapi-local`

That`s it!

#### How to configure the API to simulate differnt endpoints

1. Create a docker file with the following content
```
FROM scottMcfarlane/docker-webapi-local
```
2. Create `Data\route-data.json` file at the same level as the docker file, with content similar to,
```
[{
    "RoutePath":"/Get/This/Route/",
    "HttpStatusCode":"401",
    "Content":"Whoops, you're not allowed here"
}]
```

#### How does the above configuration work?

It uses docker's ONBUILD trigger instruction, [docker reference](https://docs.docker.com/engine/reference/builder/#onbuild).

Refer to [dockerfile](https://github.com/scottMcfarlane/docker-webapi-local/blob/master/Dockerfile#L9) on how it is being used to understand better.

### Sample of how to set it all up

Assuming we are working on an internal Web API and we are intending to test that API. The docker-compose file for local and test environment will look like below.

**Example**

docker-compose.yml
```
version: "3"
services:
  api:
    build: ./api      
    ports:
      - 4000
    depends_on:
      - webApiLocal

  webApiLocal:
    build: ./webApiLocal
      dockerfile: docker-webapi-local
    ports:
      - 4050
```

By doing the above configuration, the internal API container will have an environment variable called `webApiLocal` set on it with value `http://webApiLocal:4050`, which is now the external API you can use.

Any test can then be run after `docker-compose up -d` in the technology of your choice.

### Questions, suggestions, opinions
Please discuss it in issues and tag @scottMcfarlane with it.
