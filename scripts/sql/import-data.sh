
# Wait to be sure that SQL Server came up
sleep 20s

# Run the setup script to create the DB and the schema in the DB
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P P@ssw0rd? -d master -i setup.sql
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P P@ssw0rd? -d ACDDatabase -i data.sql