#!/bin/bash
if [ "$TRAVIS_BRANCH" == "prod" ]; then
  docker login -e $DOCKER_EMAIL -u $DOCKER_USER -p $DOCKER_PASS
  export REPO=scottmcfarlane/docker-webapi-local
  export TAG=`if [ "$TRAVIS_BRANCH" == "master" ]; then echo "latest"; else echo $TRAVIS_BRANCH ; fi`
  docker build -f Dockerfile -t $REPO:$COMMIT .
  docker tag $REPO:$COMMIT $REPO:$TAG
  docker tag $REPO:$COMMIT $REPO:travis-$TRAVIS_BUILD_NUMBER
  docker push $REPO
fi