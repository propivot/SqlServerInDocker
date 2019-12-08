FROM mcr.microsoft.com/mssql/server:latest

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Test@12345
ENV MSSQL_PID=Express
ENV MSSQL_TCP_PORT=1433 
        
WORKDIR /data
        
COPY ./data/test_db.bak /dbbackups/ 

# Run SQL Server process. & restore DB as Build step
 RUN (/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" && /opt/mssql-tools/bin/sqlcmd -S127.0.0.1 -Usa -PTest@12345  -Q"RESTORE DATABASE restored_test_db FROM DISK='/dbbackups/test_db.bak';" 