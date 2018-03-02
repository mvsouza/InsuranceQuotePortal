docker-compose build --force-rm
docker login --username=_ --password=$(api_key) registry.heroku.com
docker tag insurancequoteportal registry.heroku.com/insurancequoteportal/web
docker push registry.heroku.com/insurancequoteportal/web