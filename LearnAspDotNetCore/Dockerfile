FROM ubuntu:16.04

RUN apt-get update && apt-get install -y \
    apache2 \
    libunwind8

ENV dir learnaspnetcore
WORKDIR /$dir

COPY ./bin/Release/netcoreapp1.1/ubuntu.16.04-x64/publish/ \
    /learnaspnetcore

EXPOSE 5000

RUN chmod +x LearnAspDotNetCore

ENTRYPOINT  ./LearnAspDotNetCore