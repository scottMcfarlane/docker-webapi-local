OWNER=scottmcfarlane
IMAGE_NAME=docker-webapi-local
VCS_REF=`git rev-parse --short HEAD`
IMAGE_VERSION=0.0.$(TRAVIS_BUILD_NUMBER)
QNAME=$(OWNER)/$(IMAGE_NAME)

GIT_TAG=$(QNAME):$(VCS_REF)
BUILD_TAG=$(QNAME):$(IMAGE_VERSION)
LATEST_TAG=$(QNAME):latest

build:
	@echo "Building docker image"
	docker build \
		--build-arg VCS_REF=$(VCS_REF) \
		--build-arg IMAGE_VERSION=$(IMAGE_VERSION) \
		-t $(GIT_TAG) .

lint:
	@echo "Linting docker image"
	docker run -it --rm -v "$(PWD)/Dockerfile:/Dockerfile:ro" redcoolbeans/dockerlint

tag:
	@echo "tagging github repository - " $(IMAGE_VERSION)
	git tag $(IMAGE_VERSION)


login:
	@docker login -u "$(DOCKER_USER)" -p "$(DOCKER_PASS)"

push: login
	docker push $(GIT_TAG)
	docker push $(BUILD_TAG)
	docker push $(LATEST_TAG)
