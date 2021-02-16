[![Build Status](https://travis-ci.org/herbertbarbosajr/SoftPlanTeste.svg?branch=master)](https://travis-ci.org/herbertbarbosajr/SoftPlanTeste)

# DesafioSoftPlan
> DesafioSoftPlan e uma aplicação de exemplo para prova de tecnologia na Softplan, que realiza o calculo de juros composto.

**Acesso**

 - Api : [http://padlock.gestvendas.com:9090/](http://padlock.gestvendas.com:9090/)
 - Documentação Api (Swagger): [http://padlock.gestvendas.com:9090/doc](http://padlock.gestvendas.com:9090/doc)
 - Cliente Web: [http://padlock.gestvendas.com:3000](http://padlock.gestvendas.com:3000)

**Infraestrutura**
A aplicação está dividida em API e cliente web

 - A aplicação API foi desenvolvida em .net C#;
 - A aplicação web foi desenvolvida em React Js.

**Deploy docker**
Para implantar o aplicativo no docker execute o passo abaixo:

    wget https://github.com/herbertbarbosajr/SoftPlanTeste/releases/download/1.0/desafiosoftplan.docker.zip \
	&& unzip desafiosoftplan.docker.zip \
	&& rm desafiosoftplan.docker.zip
Logo apos execute:

    docker-compose -d -build


