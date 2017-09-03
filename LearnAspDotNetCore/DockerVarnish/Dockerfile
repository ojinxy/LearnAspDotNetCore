FROM ubuntu:16.04

ENV dir var/temp
WORKDIR /$dir

RUN apt-get update && \
    apt-get -f install -y varnish curl

COPY ./varnish /etc/default/varnish
COPY ./default.vcl /etc/varnish/default.vcl
COPY ./run.sh /$dir/

EXPOSE 6081
EXPOSE 6082

RUN chmod +x run.sh
ENTRYPOINT ./run.sh
