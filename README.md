[![Build Status](https://travis-ci.org/pauloofmeta/CalcSoft.svg?branch=master)](https://travis-ci.org/pauloofmeta/CalcSoft)

# CalcSoft
> Calcsoft e uma aplicação de exemplo para prova de tecnologia na Softplan, que realiza o calculo de juros composto.

**Acesso**

 - Api : [http://padlock.gestvendas.com:9090/](http://padlock.gestvendas.com:9090/)
 - Documentação Api (Swagger): [http://padlock.gestvendas.com:9090/doc](http://padlock.gestvendas.com:9090/doc)
 - Cliente Web: [http://padlock.gestvendas.com:3000](http://padlock.gestvendas.com:3000)

**Infraestrutura**
A aplicação está dividida em API e cliente web

 - A aplicação API foi desenvolvida em .net C#;
 - A aplicação web foi desenvolvida em Reac Js.

**Deploy docker**
Para implantar o aplicativo no docker execute o passo abaixo:

    wget https://github.com/pauloofmeta/CalcSoft/releases/download/1.0/calcsoft.docker.zip \
	&& unzip calcsoft.docker.zip \
	&& rm calcsoft.docker.zip
Logo apos execute:

    docker-compose -d -build


