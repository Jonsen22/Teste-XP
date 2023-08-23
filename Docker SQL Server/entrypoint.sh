#!/bin/bash
wait_time=15s
password=XPTest123

# Iniciar servidor SQL
echo importing data will start in $wait_time...
sleep $wait_time
echo executing script...

# run no setup inicial do banco de dados(definido em setup.sql)
#/opt/mssql-tools/bin/sqlcmd -S 0.0.0.0 -U sa -P $password -i ./setup.sql