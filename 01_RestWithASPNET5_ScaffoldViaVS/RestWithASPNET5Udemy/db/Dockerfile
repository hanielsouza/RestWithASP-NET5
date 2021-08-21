FROM mysql:5.7.22
EXPOSE 3306
COPY ./RestWithASPNET5Udemy/db/migrations/ /home/database/
COPY ./RestWithASPNET5Udemy/db/dataset/ /home/database/
COPY ./RestWithASPNET5Udemy/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh