#!/bin/bash

docker run --name cb --privileged -v /dev/bus/usb:/dev/bus/usb -it --rm \
-v $PWD:/data/workspace \
--entrypoint=bash novice/android