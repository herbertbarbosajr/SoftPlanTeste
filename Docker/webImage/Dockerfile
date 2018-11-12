FROM buildpack-deps:jessie-curl as repo
RUN mkdir /usr/repo
WORKDIR /usr/repo

RUN apt-get update \
    && apt-get install unzip

# Download artefatos
RUN curl -s https://api.github.com/repos/pauloofmeta/calcsoft/releases/latest \
  | grep "browser_download_url.*calcsoftWeb" \
  | cut -d ":" -f 2,3 \
  | tr -d \" \
  | wget -qi -
  
RUN unzip -a calcsoftWeb.zip
RUN rm calcsoftWeb.zip

FROM node:10-alpine as build
RUN mkdir /usr/app
WORKDIR /usr/app
COPY --from=repo /usr/repo /usr/app
ENV PATH /usr/app/node_modules/.bin:$PATH
ARG REACT_APP_URL_API="http://localhost:8080"
ENV REACT_APP_URL_API=$REACT_APP_URL_API
RUN npm install --silent
COPY . /app/repo
RUN npm run build

FROM nginx:stable-alpine AS final
COPY --from=build /usr/app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]